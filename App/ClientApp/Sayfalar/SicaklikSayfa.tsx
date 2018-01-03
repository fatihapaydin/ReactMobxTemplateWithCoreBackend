import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { SicaklikBilesen } from "./../Bilesenler/SicaklikBilesen";
import { SicaklikStore } from "./../Stores/SicaklikStore";

const appState = new SicaklikStore("F", 200);

export class SicaklikSayfa extends React.Component<RouteComponentProps<{}>, {}> {

    public render() {
        return <div>
            <h1>Sıcaklık Ölçme</h1>
            <SicaklikBilesen nesne={appState} />
        </div>;
    }

}
