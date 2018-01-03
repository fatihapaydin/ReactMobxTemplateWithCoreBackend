import { CounterStore } from "./../Stores/CounterStore";
import { observer } from "mobx-react";
import * as React from "react";



interface IAppState {
    nesne: CounterStore;
}

@observer
export class CounterBilesen extends React.Component<IAppState, {}>{
    private BilesenDurum: CounterStore;

    constructor(props: IAppState) {
        super(props);
        this.BilesenDurum = this.props.nesne;
    }

    render() {
        return <div>
            <button onClick={() => this.BilesenDurum.sifirla()}>
                Sayacın değeri: {this.BilesenDurum.sayac}
            </button>
            <br />
            <button onClick={() => this.BilesenDurum.arttir()}>
                1 arttır
            </button>
            <button onClick={() => this.BilesenDurum.azalt()}>
                1 azalt
            </button>
        </div>;
    }


}


