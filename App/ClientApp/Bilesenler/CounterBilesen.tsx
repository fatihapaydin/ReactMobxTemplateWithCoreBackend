import { observable, action, computed } from "mobx";
import { observer } from "mobx-react";
import * as React from "react";


export class AppState {
    @observable private _sayac: number = 0;

    constructor(number?: number) {
        this._sayac = number || this._sayac;
    }

    @action
    sifirla() {
        this._sayac = 0;
    }

    @action
    arttir() {
        this._sayac++;
    }

    @action
    azalt() {
        this._sayac--;
    }

    @computed
    get sayac() {
        return this._sayac;
    }
}

interface IAppState {
    nesne: AppState;
}

@observer
export class CounterBilesen extends React.Component<IAppState, {}>{
    private BilesenDurum: AppState;

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


