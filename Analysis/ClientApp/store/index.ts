import * as DashboardStore from './Dashboard';
import * as ChartStore from './Chart';
import * as CounterStore from './Counter';
import * as WeatherForecastsStore from './WeatherForecasts';
import * as SettingsStore from './Counter';

// The top-level state object
export interface ApplicationState {
    dashboard: DashboardStore.DashboardState,
    chart: ChartStore.ChartState,
    counter: CounterStore.CounterState,
    settings: SettingsStore.CounterState,
    weatherForecasts: WeatherForecastsStore.WeatherForecastsState
}

// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    dashboard: DashboardStore.reducer,
    chart: ChartStore.reducer,
    counter: CounterStore.reducer,
    settings: SettingsStore.reducer,
    weatherForecasts: WeatherForecastsStore.reducer
};

// This type can be used as a hint on action creators so that its 'dispatch' and 'getState' params are
// correctly typed to match your store.
export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
