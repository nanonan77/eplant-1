import { useContext } from 'react';
import { AxiosContext } from '../components/AxiosProvider';

// ................................................................

export default function useAxios() {
  const axios = useContext(AxiosContext);

  return axios;
}
