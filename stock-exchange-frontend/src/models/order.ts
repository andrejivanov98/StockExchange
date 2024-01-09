export interface OrderPreview {
  stockId: string;
  numberOfShares: number;
  accountId: string;
}

export interface OrderCreate {
  accountId: string;
  stockId: string;
  numberOfShares: number;
}

export interface OrderPreviewModel {
  stockId: string;
  stockName: string;
  numberOfShares: number;
  totalCost: number;
  isOrderValid: boolean;
}

