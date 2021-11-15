import { v4 as uuidv4 } from 'uuid';

export interface IBasket {
        id?: string;
        items: IBasketItem[];
}
    
    export  interface IBasketItem {
        id: number;
        name?: string;
        brand?: string;
        vehicle?: string;
        supplier?: string;
        price: number;
        pictureULR?: string;
        partCategory?: string;
        partCode?: string;
        vehicleModel?: string;
        partNumber?: number;
        quantity: number;
    }

     
export class Basket implements IBasket {
    id= uuidv4();
    items: IBasketItem[] = [];
}

export interface IBasketTotals {
    shipping?: number;
    subtotal?: number;
    total?: number;
}
