import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { SicaklikBilesen, Sicaklik } from "./../Bilesenler/SicaklikBilesen";

const appState = new Sicaklik("F", 200);

export class SicaklikSayfa extends React.Component<RouteComponentProps<{}>, {}> {

    public render() {
        return <div>
            <h1>Sıcaklık Ölçme</h1>
            <SicaklikBilesen nesne={appState} />
        </div>;
    }

}
