import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as DashboardState from '../store/Dashboard';
import Chart from '../components/Chart';
import * as ChartState from '../store/Chart';

type DashboardProps = DashboardState.DashboardState
    & typeof DashboardState.actionCreators
    & typeof ChartState.actionCreators
    & RouteComponentProps<{ id: string }>; 

class Dashboard extends React.Component<DashboardProps, {}> {

    componentWillMount() {
        console.log('componentWillMount()_Dashboard');
        console.log(this);
        let id = "";
        this.props.requestDashboard(id);
    }

    componentWillReceiveProps(nextProps: DashboardProps) {
        console.log('componentWillReceiveProps()_Dashboard');
        console.log(this);
        console.log("nextProps");
        console.log(nextProps);
        this.state = nextProps;
        console.log(this);
        this.props.requestDashboard(nextProps.id);
    }

    public render() {
        console.log('render()_Dashboard');
        console.log(this);
        return <div>
            {this.renderDashboard()}
        </div>;
    }

    private renderDashboard() {
        console.log('renderDashboard()');
        console.log(this);
        if (this.props.chartIds) {
            return <div>
                {console.log('has chartIds')}
                {
                    this.props.charts.map(chart =>
                        <Chart
                            {...chart }
                            key={chart.chart_id}
                            match={this.props.match}
                            location={this.props.location}
                            history={this.props.history}
                            toggleFullScreen={this.props.toggleFullScreen}
                        />
                    )
                }
            </div>;
        }
    }
}

const DashboardContainer = connect((state: ApplicationState) => state.dashboard, DashboardState.actionCreators);
export default DashboardContainer(Dashboard) as typeof Dashboard;



