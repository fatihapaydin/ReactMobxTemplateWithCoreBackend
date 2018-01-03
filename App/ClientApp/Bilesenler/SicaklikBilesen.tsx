import * as React from "react";
import { SicaklikStore } from "./../Stores/SicaklikStore";
import { observer } from "mobx-react";


export interface ISicaklikDurum {
    nesne: SicaklikStore;
}

@observer
export class SicaklikBilesen extends React.Component<ISicaklikDurum, {}>{

    private BilesenDurum: SicaklikStore;

    constructor(props: ISicaklikDurum) {
        super(props);
        this.BilesenDurum = this.props.nesne;
    }

    render() {
        return <div>
            <button onClick={() => this.BilesenDurum.sicaklikBiriminiDegistir()}>Sıcaklık Hesapla</button>
            <h3>Counter: {this.BilesenDurum.sicaklik}</h3>
            <h6>Durum : {this.BilesenDurum.mesaj}</h6>
            <br />
        </div>;
    }
}
