import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { CounterBilesen, AppState } from "./../Bilesenler/CounterBilesen";

const appState = new AppState(10);

export class Counter extends React.Component<RouteComponentProps<{}>, {}> {

    public render() {
        return <div>
            <h1>Sayaç Örneği</h1>
            <CounterBilesen nesne={appState} />
        </div>;
    }

}
