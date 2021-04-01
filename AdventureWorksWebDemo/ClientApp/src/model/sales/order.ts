import { OrderDetail } from './order-detail';

export interface Order {
  salesOrderId: number;
  revisionNumber: number;
  orderDate: string;
  dueDate: string;
  shipDate: string | null;
  status: number;
  onlineOrderFlag: boolean | null;
  salesOrderNumber: string;
  purchaseOrderNumber: string;
  accountNumber: string;
  customerId: number;
  salesPersonId: number | null;
  territoryId: number | null;
  billToAddressId: number;
  shipToAddressId: number;
  shipMethodId: number;
  creditCardId: number | null;
  creditCardApprovalCode: string;
  currencyRateId: number | null;
  subTotal: number;
  taxAmt: number;
  freight: number;
  totalDue: number;
  comment: string;
  orderDetail: OrderDetail[];
}
