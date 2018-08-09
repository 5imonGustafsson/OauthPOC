import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import {  runWithAdal} from 'react-adal';
import { authContext} from './adalConfig';

runWithAdal( authContext, () => {
    ReactDOM.render(<App />, document.getElementById('root'));
    registerServiceWorker();
});
