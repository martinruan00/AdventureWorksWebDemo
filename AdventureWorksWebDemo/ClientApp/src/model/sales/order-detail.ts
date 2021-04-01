export interface OrderDetail {
  salesOrderId: number;
  salesOrderDetailId: number;
  carrierTrackingNumber: string;
  orderQty: number;
  productId: number;
  productName: string;
  specialOfferId: number;
  unitPrice: number;
  unitPriceDiscount: number;
  lineTotal: number;
}
