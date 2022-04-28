import { Container, Paper, Typography } from '@material-ui/core';
// qs
import qs from 'qs';
// components
import Page from '../components/Page';
import MButton from '../components/@material-extend/MButton';

// -----------------------------------------------------------------------------

export default function ErrorMessage() {
  const query = qs.parse(window.location.search, { ignoreQueryPrefix: true });

  return (
    <Page>
      <Container maxWidth="sm">
        <Paper sx={{ mt: 10, p: 2, textAlign: 'center' }} elevation={3}>
          <Typography
            component="p"
            variant="body1"
            color="error"
            align="center"
            gutterBottom
          >
            {query.error}
          </Typography>
          <MButton variant="contained" onClick={() => (window.location = '/')}>
            Go To Home
          </MButton>
        </Paper>
      </Container>
    </Page>
  );
}
