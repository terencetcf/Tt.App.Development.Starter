import { combineReducers } from 'redux';
import { History } from 'history';
import { RouterState, connectRouter } from 'connected-react-router';
import { appReducer } from './reducers/appReducer';
import { AppState } from './actions/actionTypes';

const createRootReducer = (history: History) =>
  combineReducers({
    router: connectRouter(history),
    app: appReducer
  });

export interface State {
  router: RouterState;
  app: AppState;
}

export default createRootReducer;