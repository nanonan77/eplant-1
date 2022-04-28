import { useEffect, useState } from 'react';
import qs from 'qs';
// Material
import {
  Box,
  Typography,
  Stack,
  CardHeader,
  CardContent,
  Card
} from '@material-ui/core';
// Hooks
import useAxios from '../../../hooks/useAxios';
// Components
import MButton from '../../@material-extend/MButton';

// ---------------------------------------------------------------------

export default function ConsentForm() {
  const axios = useAxios();
  const [isLoading, setLoading] = useState(false);
  const [isSubmiting, setSubmiting] = useState(false);
  const [authRequest, setAuthRequest] = useState(null);
  useEffect(() => {
    const { returnUrl } = qs.parse(window.location.search, {
      ignoreQueryPrefix: true
    });

    async function fetch(returnUrl) {
      try {
        setLoading(true);
        const resp = await axios.get('/oidc/Authorization', {
          params: { returnUrl }
        });
        setAuthRequest(resp.data);
      } catch (ex) {
        console.log(ex);
      } finally {
        setLoading(false);
      }
    }
    if (returnUrl) fetch(returnUrl);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const onSubmit = (accept) => async () => {
    const { returnUrl } = qs.parse(window.location.search, {
      ignoreQueryPrefix: true
    });
    async function submit() {
      try {
        setSubmiting(true);
        await axios.post('/oidc/consent', {
          accept,
          returnUrl
        });
        window.location = returnUrl;
      } catch (ex) {
        console.log(ex);
      } finally {
        setSubmiting(false);
      }
    }

    submit();
  };

  return (
    <Box>
      {(isLoading && (
        <Typography component="h3" align="center">
          Loading Consent...
        </Typography>
      )) ||
        (authRequest && authRequest.validatedResources.succeeded && (
          <Box>
            <Card sx={{ mb: 3 }}>
              <CardHeader title="Current Loggedin Account" />
              <CardContent>
                <Stack spacing={1} sx={{ mt: 2 }}>
                  <Typography variant="body1">
                    <strong>Username</strong> {authRequest.username}
                  </Typography>
                  <Typography variant="body1">
                    <strong>Email</strong> {authRequest.email}
                  </Typography>
                </Stack>
              </CardContent>
            </Card>
            <Card sx={{ mb: 3 }}>
              <CardHeader
                title="Application"
                subheader={authRequest.description}
              />
              <CardContent>
                <Stack spacing={1} sx={{ mt: 2 }}>
                  <Typography variant="body1">
                    <strong>Application</strong> {authRequest.clientName}
                  </Typography>
                  <Typography variant="body1">
                    <strong>Application's Site:</strong> {authRequest.clientUri}
                  </Typography>
                </Stack>
              </CardContent>
            </Card>
            <Card>
              <CardHeader title="Permission" />
              <CardContent>
                <Stack spacing={1} sx={{ mt: 2 }}>
                  {authRequest.validatedResources.resources.apiResources
                    .concat(authRequest.validatedResources.resources.apiScopes)
                    .concat(
                      authRequest.validatedResources.resources.identityResources
                    )
                    .map(({ displayName, name, description }, idx) => (
                      <div key={idx}>
                        <Typography>- {displayName || name}</Typography>
                        {!!description && (
                          <Typography
                            sx={{ pl: 1 }}
                            color="text.secondary"
                            variant="subtitle2"
                          >
                            {description}
                          </Typography>
                        )}
                      </div>
                    ))}
                </Stack>
              </CardContent>
            </Card>
            <Stack
              sx={{ pt: 3 }}
              direction="row"
              justifyContent="center"
              spacing={5}
            >
              <MButton
                variant="outlined"
                onClick={onSubmit(false)}
                disabled={isSubmiting}
              >
                Decline
              </MButton>
              <MButton onClick={onSubmit(true)} disabled={isSubmiting}>
                Accept
              </MButton>
            </Stack>
          </Box>
        )) || (
          <Typography align="center" variant="h4" color="error">
            Invalid Auth.
          </Typography>
        )}
    </Box>
  );
}
