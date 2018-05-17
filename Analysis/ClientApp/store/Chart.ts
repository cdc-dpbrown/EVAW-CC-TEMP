import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

export interface ChartState {
    chart_id: string;
    chart_type: string;
    chart_inEdit: string;
    chart_loading: boolean;
    chart_isFullScreen: boolean;
    chart_isFullWidth: boolean;
}

interface RequestChartAction {
    type: 'REQUEST_CHART';
    chart_id: string;
}

interface ReceiveChartAction {
    type: 'RECEIVE_CHART';
    chart_id: string;
    chart_json: any;
}

interface GetChartAction {
    type: 'GET_CHART';
    chart_id: string;
    chart_type: string;
    chart_inEdit: string;
    chart_loading: boolean;
}

interface ToggleFullScreen {
    type: 'TOGGLE_FULL_SCREEN';
    chart_id: string;
}

type ChartActions = RequestChartAction | ReceiveChartAction | GetChartAction | ToggleFullScreen;

export const actionCreators = {
    toggleFullScreen: (id: string): AppThunkAction<ChartActions> => (dispatch, getState) => {
        dispatch({ type: 'TOGGLE_FULL_SCREEN', chart_id: id });
    }
};

const unloadedState: ChartState = {
    chart_id: '',
    chart_type: '',
    chart_inEdit: '',
    chart_loading: false,
    chart_isFullScreen: false,
    chart_isFullWidth: false,
};

export const reducer: Reducer<ChartState> = (state: ChartState, incomingAction: Action) => {
    const action = incomingAction as ChartActions;
    switch (action.type) {

        case 'REQUEST_CHART':
            return {
                chart_id: state.chart_id,
                chart_type: state.chart_type,
                chart_inEdit: state.chart_inEdit,
                chart_loading: true,
                chart_isFullScreen: false,
                chart_isFullWidth: false
            };

        case 'RECEIVE_CHART':
            return {
                chart_id: action.chart_id,
                chart_json: action.chart_json,
                chart_type: '',
                chart_inEdit: '',
                chart_loading: false,
                chart_isFullScreen: false,
                chart_isFullWidth: false
            };

        case 'TOGGLE_FULL_SCREEN':
            console.log("TOGGLE_FULL_SCREEN");
            console.log("state");
            console.log(state);
            console.log("action");
            console.log(action);
            return {
                chart_id: action.chart_id,
                chart_type: state.chart_type,
                chart_inEdit: state.chart_inEdit,
                chart_loading: false,
                chart_isFullScreen: state.chart_isFullScreen === true ? false : true,
                chart_isFullWidth: false
            };

        case 'GET_CHART':
            return {
                chart_id: action.chart_id,
                chart_type: action.chart_type,
                chart_inEdit: action.chart_inEdit,
                chart_loading: false,
                chart_isFullScreen: false,
                chart_isFullWidth: false
            };

        default:
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
