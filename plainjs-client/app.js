const backendUrl = 'http://localhost:55476';
const backendAppId = 'abf3d6da-1ae2-459d-a1a8-febade9f9d67';

// Set up ADAL
const authContext = new AuthenticationContext({
  clientId: 'abf3d6da-1ae2-459d-a1a8-febade9f9d67',
  tenant: 'jayway.com',
  endpoints: [{ [backendAppId]: 'abf3d6da-1ae2-459d-a1a8-febade9f9d67' }],
  cacheLocation: 'localStorage'
});

// Make an AJAX request to the Microsoft Graph API and print the response as JSON.
function getCurrentUser(access_token) {
  document.getElementById('api_response').textContent = 'Fetching from API...';
  fetch(backendUrl, {
    headers: { Authorization: `Bearer ${access_token}` }
  })
    .then(response => response.json())
    .then(texts => {
      document.getElementById('hello').textContent = texts[0];
      document.getElementById('api_response').textContent = JSON.stringify(texts, null, 2);
    });
};
if (authContext.isCallback(window.location.hash)) {
  // Handle redirect after token requests
  authContext.handleWindowCallback();
  const err = authContext.getLoginError();
  if (err) {
    // TODO: Handle errors signing in and getting tokens
    document.getElementById('api_response').textContent = 'ERROR:\n\n' + err;
  }
} else {
  // If logged in, get access token and make an API request
  const user = authContext.getCachedUser();
  if (user) {
    document.getElementById('username').textContent =
      'Signed in as: ' + user.userName;
    document.getElementById('api_response').textContent =
      'Getting access token...';

    // Get an access token to the Microsoft Graph API
    authContext.acquireToken(backendAppId, function(
      error,
      token
    ) {
      if (error || !token) {
        // TODO: Handle error obtaining access token
        document.getElementById('api_response').textContent =
          'ERROR:\n\n' + error;
        return;
      }
      console.log(token)
      // Use the access token
      getCurrentUser(token);
    });
  } else {
    document.getElementById('username').textContent = 'Not signed in.';
  }
}
