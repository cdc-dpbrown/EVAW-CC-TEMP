import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
                <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <img src="/Content/Images/ei.png" id='ei-icon' /><Link className='navbar-brand' to={'/'}>Epi Info Analysis</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink exact to={ '/' } activeClassName='active'>Options</NavLink>
                        </li>
                        <li>
                            <NavLink to={ '/set-data-source' } activeClassName='active'>Set Data Source</NavLink>
                        </li>
                        <li>
                            <NavLink to={'/open'} activeClassName='active'>Open</NavLink>
                        </li>
                        <li>
                            <NavLink to={'/save'} activeClassName='active'>Save</NavLink>
                        </li>
                        <li>
                            <NavLink to={'/save-as'} activeClassName='active'>Save As</NavLink>
                        </li>
                        <li>
                            <NavLink to={'/variables'} activeClassName='active'>Variables</NavLink>
                        </li>
                        <li>
                            <NavLink to={'/fetchdata'} activeClassName='active'>Filter</NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}
