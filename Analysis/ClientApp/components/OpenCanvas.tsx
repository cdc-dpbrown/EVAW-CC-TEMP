import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as CanvasStore from '../store/Canvas';
import * as WeatherForecasts from '../store/WeatherForecasts';

type CanvasProps =
    CanvasStore.CanvasState
    & typeof CanvasStore.actionCreators
    & RouteComponentProps<{}>;

class OpenCanvas extends React.Component<CanvasProps, {}> {
    public render() {
        return <div>
            <h1>Open Recent</h1>

            <p>...list of resent files...</p>

            <h1>Browse</h1>

            <p>...browse inputs...</p>

            <p>Current count: <strong>{/*this.props.count*/}</strong></p>

            <button onClick={() => {/* this.props.increment() */}}>Increment</button>
        </div>;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.canvas, // Selects which state properties are merged into the component's props
    CanvasStore.actionCreators                 // Selects which action creators are merged into the component's props
)(OpenCanvas) as typeof OpenCanvas;

