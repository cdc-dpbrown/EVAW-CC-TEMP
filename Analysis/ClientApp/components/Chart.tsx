import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as ChartState from '../store/Chart';

type ChartProps = ChartState.ChartState
    & typeof ChartState.actionCreators
    & RouteComponentProps<{ id: string }>; 

class Chart extends React.Component<ChartProps, {}> {

    componentWillMount() {
        console.log('componentWillMount()_Chart');
        console.log(this);
    }

    componentWillReceiveProps(nextProps: ChartProps) {
        console.log('componentWillReceiveProps()_Chart');
        console.log(this);
        console.log("nextProps");
        console.log(nextProps);
        this.state = nextProps;
        console.log(this);
    }

    public render() {
        return <div>
            {this.renderChart()}
        </div>;
    }

    private renderChart() {
        if (this) {
            console.log("renderChart()");
            console.log(this);
            var wrapperDivClassName = "chartRender col-sm-3 cardstock";

            if (this.props.chart_isFullScreen) {
                wrapperDivClassName = "chartRender col-sm-12 cardstock";
            }

            return <div key={this.props.chart_id} className={wrapperDivClassName}>
                <div className='chart'>
                    <div className='chartSettingsButton' id='settingsButton' onClick={this.handleStartEdit.bind(this)}>...</div>
                    <h3>[ chart id={this.props.chart_id} ]</h3>
                </div>
                <div className='chartSettings'>
                    <button className='chartSettingsButton' id='settingsButton' onClick={this.handleStartEdit.bind(this)}>...</button>
                    <button className='chartFullButton' id='fullButton' onClick={() => {this.props.toggleFullScreen(this.props.chart_id).bind(this)}}>[]</button>
                    <p>[ chart id={this.props.chart_id} ]</p>
                    <p>[ chart_isFullScreen={this.props.chart_isFullScreen} ]</p>
                </div>
            </div>;
        }
    }

    handleStartEdit() {
    }
}

const mapStateToProps = (state: ApplicationState) => (state.chart);
const ChartContainer = connect(mapStateToProps, ChartState.actionCreators);
export default ChartContainer(Chart) as typeof Chart;