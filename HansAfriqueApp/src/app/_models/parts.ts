import { Brand } from "./brand";
import { Supplier } from "./supplier";
import { Vehicle } from "./vehicle";

export interface Parts {
    name: string;
    oeM_Part_Number: string;
    hfR_Part_Number: string;
    pcB_Part_Number: string;
    luK_Part_Number: string;
    brand: Brand;
    brandid: number;
    vehicle: Vehicle;
    vehicleid: number;
    supplier: Supplier;
    supplierid: number;
    pictureULR: string;
    id: number;
}
