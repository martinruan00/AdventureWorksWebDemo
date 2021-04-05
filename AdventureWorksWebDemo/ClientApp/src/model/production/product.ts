import { SafeResourceUrl } from '@angular/platform-browser';

export class Product {
    productId: number;
    name: string;
    productNumber: string;
    makeFlag: boolean | null;
    finishedGoodsFlag: boolean | null;
    color: string;
    safetyStockLevel: number;
    reorderPoint: number;
    standardCost: number;
    listPrice: number;
    size: string;
    sizeUnitMeasureCode: string;
    weightUnitMeasureCode: string;
    weight: number | null;
    daysToManufacture: number;
    productLine: string;
    class: string;
    style: string;
    productSubcategoryId: number | null;
    productModelId: number | null;
    sellStartDate: string;
    sellEndDate: string | null;
    discontinuedDate: string | null;
    photos: string[];
    safeResourcePhotos: SafeResourceUrl[];
}
