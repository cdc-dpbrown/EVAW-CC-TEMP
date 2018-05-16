import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import SettingsDialog from '../components/SettingsDialog';
import * as SettingsStore from '../store/Settings';

type SettingsProps =
    SettingsStore.SettingsState
    & typeof SettingsStore.actionCreators
    & RouteComponentProps<{}>;

export default class SettingsDialogContainer extends React.Component<SettingsProps, {}> {

    public render() {
        return <SettingsDialog />;
    }
}

