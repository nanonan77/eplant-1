import { useEffect, useState } from 'react';
// Material
import { Typography, Container } from '@material-ui/core';
// QS
import qs from 'qs';
// Axios
import useAxios from '../hooks/useAxios';
//
import Page from '../components/Page';

// ............................................................

export default function Error() {
  const axios = useAxios();
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  useEffect(() => {
    console.log('err');
    const query = qs.parse(window.location.search, {
      ignoreQueryPrefix: true
    });
    const { errorId } = query || {};

    async function fetch() {
      try {
        setIsLoading(true);
        const resp = await axios.get(`/Oidc/Error/${errorId}`);
        console.log(resp);
        setError(resp.data);
      } finally {
        setIsLoading(false);
      }
    }

    if (errorId) fetch();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <Page title="Error">
      <Container maxWidth="sm">
        <Typography component="h2" varaint="h4" gutterBottom>
          Error Occur
        </Typography>
        {(isLoading && <Typography>Loading...</Typography>) ||
          (Boolean(error) && (
            <>
              <Typography variant="body1">{error.error}</Typography>
              <Typography variant="body1">{error.errorDescription}</Typography>
            </>
          )) || <Typography>Error between get error</Typography>}
      </Container>
    </Page>
  );
}
