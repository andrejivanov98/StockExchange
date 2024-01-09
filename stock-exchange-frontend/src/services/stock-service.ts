import AxiosService from "./axios-service";

export const getAllStocks = async () => {
  return await AxiosService.get('/stocks');
};

export const getStockDetails = async (stockId: string) => {
  return await AxiosService.get(`/stocks/${stockId}`);
};
