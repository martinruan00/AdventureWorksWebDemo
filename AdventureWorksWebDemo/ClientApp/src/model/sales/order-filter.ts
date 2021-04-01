export interface OrderFilter {
  revisionNumber: number;
  orderFrom: string;
  orderTo: string;
  shipDate: string | null;
  status: number;
}
