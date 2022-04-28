import PropTypes from 'prop-types';
import { createContext, useEffect } from 'react';
import Axios from 'axios';

// ............................................................

export const AxiosContext = createContext(null);

// ............................................................

AxiosProvider.propTypes = {
  children: PropTypes.node
};

export default function AxiosProvider({ children }) {
  const axiosInstance = Axios.create();

  useEffect(() => {
    async function get() {
      try {
        const resp = await axiosInstance.get('/home/csrf');
        const tokenSet = resp.data;
        if (tokenSet) {
          axiosInstance.defaults.headers.common[tokenSet.headerName] =
            tokenSet.requestToken;
        }
      } catch (error) {
        console.log(error);
      }
    }

    get();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <AxiosContext.Provider value={axiosInstance}>
      {children}
    </AxiosContext.Provider>
  );
}
