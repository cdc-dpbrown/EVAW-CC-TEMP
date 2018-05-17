import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';
import { ChartState } from 'ClientApp/store/Chart';

export interface DashboardState {
    id: string;
    isLoading: boolean;
    json: any;
    chartIds: string[];
    charts: ChartState[];
}

interface RequestDashboardAction {
    type: 'REQUEST_DASHBOARD';
    id: string;
}

interface ReceiveDashboardAction {
    type: 'RECEIVE_DASHBOARD';
    id: string;
    json: any;
    charts: any;
}

type DashboardActions = RequestDashboardAction | ReceiveDashboardAction;

export const actionCreators = {
    requestDashboard: (id: string): AppThunkAction<DashboardActions> => (dispatch, getState) => {
        if (id !== getState().dashboard.id) {
            let fetchTask = fetch(`/api/SettingsData/Dashboard?id=${ id }`)
                .then(response => response.json() as Promise<any>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_DASHBOARD', id: id, json:data, charts: null });
                });

            addTask(fetchTask); 
            dispatch({ type: 'REQUEST_DASHBOARD', id: id });
        }
    }
};

const unloadedState: DashboardState = {
    id: '',
    isLoading: false,
    json: '',
    chartIds: [],
    charts: []
};

export const reducer: Reducer<DashboardState> = (state: DashboardState, incomingAction: Action) => {
    const action = incomingAction as DashboardActions;
    switch (action.type) {

        case 'REQUEST_DASHBOARD':
            console.log("REQUEST_DASHBOARD");
            console.log("state");
            console.log(state);
            console.log("action");
            console.log(action);

            return {
                id: action.id,
                json: state.json,
                isLoading: true,
                chartIds: state.chartIds,
                charts: state.charts
            };

        case 'RECEIVE_DASHBOARD':
            console.log("RECEIVE_DASHBOARD");
            console.log("state");
            console.log(state);
            console.log("action");
            console.log(action);

            let ids: string[] = [];
            let chartStates: ChartState[] = []; 

            action.json.canvas.charts.forEach((c: any) => {
                ids.push(c.chart_id as string);
            })

            action.json.canvas.charts.forEach((c: any) => {
                chartStates.push({
                    chart_id: c.chart_id,
                    chart_type: c.chart_type,
                    chart_inEdit: c.chart_inEdit,
                    chart_loading: c.chart_loading === true ? true : false,
                    chart_isFullScreen: c.chart_isFullScreen === true ? true : false,
                    chart_isFullWidth: c.chart_isFullWidth === true ? true : false,
                });
            })

            console.log('print chartStates');
            console.log(chartStates);

            return {
                id: action.json.canvas.id,
                json: action.json,
                isLoading: false,
                chartIds: ids,
                charts: chartStates
            };

        default:
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
