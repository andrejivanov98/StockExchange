import axios from 'axios';

const AxiosService = axios.create({
  baseURL: 'https://localhost:7255/api',
});

export default AxiosService;
