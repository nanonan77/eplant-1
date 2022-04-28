import useAxios from './useAxios';

// ...................................................

export default function useAuth() {
  const axios = useAxios();
  return {
    login: async (credential) => {
      const resp = await axios.post('/account/login', credential);
      return resp.data;
    },
    logout: () => axios.post('/account/logout'),
    register: async (account) => {
      const resp = await axios.post('/account/register', account);
      return resp.data;
    },
    resetPassword: async (email) => {
      const resp = await axios.post('/account/reset-password', {
        email
      });
      return resp.data;
    },
    changePassword: async (data) => {
      const resp = await axios.post('/account/change-password', data);
      return resp.data;
    }
  };
}
