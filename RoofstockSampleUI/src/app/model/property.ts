import { Address } from "./address";
import { Financial } from "./financial";
import { Physical } from "./physical";

export interface Property {
    id: number;
    address: Address;
    financial?: Financial;
    physical?: Physical;
    [k : string] : any;
}
