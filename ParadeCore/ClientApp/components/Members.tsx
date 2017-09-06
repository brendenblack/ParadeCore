import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';

class Members extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Members</h1>
        </div>;
    }
}

export default Members;