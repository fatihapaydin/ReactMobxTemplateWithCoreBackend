import { observable, action, computed } from "mobx";
export class SicaklikStore {
    @observable private unit: string = "C";

    @observable private temperatureCelcius: number = 25;

    @observable private _mesaj: string = "";

    constructor(unit: string, sicaklik: number) {
        this.unit = unit;
        this.temperatureCelcius = sicaklik;
    }

    harfler = ["C", "F", "K"];

    @action
    sicaklikBiriminiDegistir() {
        let indeks = Math.floor(Math.random() * 3);
        this.unit = this.harfler[indeks];
        this._mesaj = "yeni birim " + this.unit;
    }

    @computed
    get kelvinSicaklikHesapla() {
        return this.temperatureCelcius * (9 / 5) + 32;
    }

    @computed
    get fahrenheitSicaklikHesapla() {
        return this.temperatureCelcius + 273.15;
    }

    @computed
    get sicaklik() {
        switch (this.unit) {
            case "K":
                return this.kelvinSicaklikHesapla + " K";
            case "F":
                return this.fahrenheitSicaklikHesapla + " F";
            case "C":
                return this.temperatureCelcius + " C";
        }
    }

    @computed
    get mesaj() {
        return this._mesaj;
    }
}