import { observable, action, computed } from "mobx";

export class CounterStore {
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