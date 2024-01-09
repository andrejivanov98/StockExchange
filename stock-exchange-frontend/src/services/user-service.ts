import AxiosService from "./axios-service";

export const getUserDetails = async (userId: string) => {
  return await AxiosService.get(`/users/${userId}`);
};
