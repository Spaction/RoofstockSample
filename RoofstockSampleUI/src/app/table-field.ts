import { Property } from "./model/property";
import { Address } from "./model/address";

export class TableField {
    id: number;
    address: Address;
    yearBuilt?: string;
    listPrice: number;
    monthlyRent: number;
    grossYieldPerc: number;

    constructor(row: Property){
        this.id = row.id;
        this.address = row.address;
        this.yearBuilt = row.physical?.yearBuilt.toString();
        this.listPrice = row.financial?.listPrice??0;
        this.monthlyRent = row.financial?.monthlyRent??0;
        this.grossYieldPerc = this.monthlyRent * 12 / (this.listPrice == 0 ? 1: this.listPrice);
    }    
}
