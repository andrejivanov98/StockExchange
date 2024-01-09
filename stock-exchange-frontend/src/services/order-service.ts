import { OrderCreate, OrderPreview } from "../models/order";
import AxiosService from "./axios-service";

export const previewOrder = async (orderPreview: OrderPreview) => {
  return await AxiosService.post('/orders/preview', orderPreview);
};

export const createOrder = async (orderCreate: OrderCreate) => {
  return await AxiosService.post('/orders/create', orderCreate);
};
