import { useState } from 'react';
// Materail
import { Container, Typography } from '@material-ui/core';
//
import Page from '../../components/Page';
import { LogoutForm } from '../../components/authentication/logout';

// ............................................................................

export default function Logout() {
  const [isFinished, setIsFinished] = useState(false);

  return (
    <Page title="Logout">
      <Container maxWidth="sm" sx={{ mt: 10 }}>
        <LogoutForm onFinish={() => setIsFinished(true)} />

        {isFinished && (
          <>
            <Typography
              align="center"
              variant="h5"
              gutterBottom
              color="primary"
            >
              Logged out Success.
            </Typography>
            <Typography align="center" variant="body1" gutterBottom>
              We will redirect you in second.
            </Typography>
            <Typography align="center" variant="body2">
              Please wait...
            </Typography>
          </>
        )}
      </Container>
    </Page>
  );
}
