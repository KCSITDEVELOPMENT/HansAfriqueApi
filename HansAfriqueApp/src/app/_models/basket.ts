import { v4 as uuidv4 } from 'uuid';

export class IBasket {
        id: string = "";
        items: IBasketItem[] = [];
}
    
    export  class IBasketItem {
        id: number=0;
        name: string = "";
        brand: string = "";
        vehicle: string = "";
        supplier: string = "";
        price: number = 0;
        pictureULR: string = "";
        partCategory: string = "";
        partCode: string = "";
        vehicleModel: string = "";
        partNumber: number = 0;
        quantity: number=0;
    }

     
export class Basket implements IBasket {
    id= uuidv4();
    items: IBasketItem[] = [];
}
