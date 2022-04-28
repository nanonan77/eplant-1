import { Typography, Container, Paper, Box } from '@material-ui/core';
// Components
import Page from '../../components/Page';
import { ConsentForm } from '../../components/authentication/consent';
// ...........................................................

export default function Consent() {
  return (
    <Page sx={{ pt: 6 }}>
      <Container maxWidth="sm">
        <Paper elevation={2} sx={{ p: 4 }}>
          <Box
            component="img"
            alt="logo"
            src="/static/icons/unauth.gif"
            width="100%"
            // height={80}
          />
          <Typography component="h1" variant="h2" align="center" gutterBottom>
            Unauthorize App
          </Typography>
          {/* <Typography variant="body1" gutterBottom>
            Would you like to give the following application access to your
            account ?
          </Typography>
          <ConsentForm /> */}
        </Paper>
      </Container>
    </Page>
  );
}
