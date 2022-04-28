import { useEffect } from 'react';
// router
import { Link as RouterLink, useLocation } from 'react-router-dom';
// material
import { experimentalStyled as styled } from '@material-ui/core/styles';
import {
  Box,
  Card,
  Link,
  Alert,
  Hidden,
  Container,
  Typography,
  Stack,
  Divider
} from '@material-ui/core';
// qs
import qs from 'qs';
// icons
import { Icon } from '@iconify/react';
import microsoft from '@iconify/icons-logos/microsoft';
// routes
import { PATH_AUTH } from '../../routes/paths';
// components
import Page from '../../components/Page';
import Logo from '../../components/Logo';
import MButton from '../../components/@material-extend/MButton';
import { LoginForm } from '../../components/authentication/login';

// ----------------------------------------------------------------------

const RootStyle = styled(Page)(({ theme }) => ({
  [theme.breakpoints.up('md')]: {
    display: 'flex'
  }
}));

const HeaderStyle = styled('header')(({ theme }) => ({
  top: 0,
  zIndex: 9,
  lineHeight: 0,
  width: '100%',
  display: 'flex',
  alignItems: 'center',
  position: 'absolute',
  padding: theme.spacing(3),
  justifyContent: 'space-between',
  [theme.breakpoints.up('md')]: {
    alignItems: 'flex-start',
    padding: theme.spacing(7, 5, 0, 7)
  }
}));

const SectionStyle = styled(Card)(({ theme }) => ({
  width: '100%',
  maxWidth: 464,
  display: 'flex',
  flexDirection: 'column',
  justifyContent: 'center',
  margin: theme.spacing(2, 0, 2, 2)
}));

const ContentStyle = styled('div')(({ theme }) => ({
  maxWidth: 480,
  margin: 'auto',
  display: 'flex',
  minHeight: '100vh',
  flexDirection: 'column',
  justifyContent: 'center',
  padding: theme.spacing(0, 0)
}));

// ----------------------------------------------------------------------

const MicrosoftLoginUrl = '/Account/Microsoft-Login';

export default function Login() {
  const location = useLocation();

  useEffect(() => {
    const query = qs.parse(location.search, {
      ignoreQueryPrefix: true
    });

    if (query.ReturnUrl) {
      // ? check login_hint in return url
      const returnUrl = decodeURIComponent(query.ReturnUrl);
      const returnUrlSet = returnUrl.split('?');
      if (returnUrlSet.length > 1) {
        const returnUrlQuery = qs.parse(returnUrlSet[1], {
          ignoreQueryPrefix: true
        });

        if (
          returnUrlQuery.login_hint &&
          returnUrlQuery.login_hint.endsWith('-ms-')
        ) {
          // * auto redirect to login with microsoft
          returnUrlQuery.login_hint = returnUrlQuery.login_hint.substring(
            0,
            returnUrlQuery.login_hint.length - 4
          );

          const newReturnUrlQuery = qs.stringify(returnUrlQuery);
          const newReturnUrl = `${returnUrlSet[0]}?${newReturnUrlQuery}`;

          const redirectUrl = `${MicrosoftLoginUrl}?redirectUri=${encodeURIComponent(
            newReturnUrl
          )}&loginhint=${encodeURIComponent(returnUrlQuery.login_hint)}`;

          // console.log(redirectUrl);
          window.location = redirectUrl;
        }
      }
    }
  }, [location]);

  const handlerMicrosoftLogin = () => {
    const query = qs.parse(window.location.search, { ignoreQueryPrefix: true });
    let location = MicrosoftLoginUrl;
    if (query.ReturnUrl && query.ReturnUrl[0] === '/') {
      location += `?redirectUri=${encodeURIComponent(query.ReturnUrl)}`;
    }

    window.location = location;
  };

  return (
    <RootStyle title="Login | E-Plant">
      {/* <HeaderStyle>
        <RouterLink to="/">
          <Logo />
        </RouterLink>
        <Hidden smDown>
          <Typography
            variant="body2"
            sx={{
              mt: { md: -2 }
            }}
          >
            Don’t have an account? &nbsp;
            <Link
              underline="none"
              component={RouterLink}
              variant="subtitle2"
              to={PATH_AUTH.register + location.search}
            >
              Get started
            </Link>
          </Typography>
        </Hidden>
      </HeaderStyle> */}

      {/* <Hidden mdDown>
        <SectionStyle>
          <Typography variant="h3" sx={{ px: 5, mt: 15, mb: 15 }}>
            Hi, Welcome Back
          </Typography>
          <img src="/static/illustrations/illustration_login.svg" alt="login" />
        </SectionStyle>
      </Hidden> */}

      <Container maxWidth="sm">
        <ContentStyle>
          {/* <Box sx={{ mb: 5, display: 'flex', alignItems: 'center' }}>
            <Box sx={{ flexGrow: 1 }}>
              <Typography variant="h4" gutterBottom>
                Sign in to E-Plant
              </Typography>
              <Typography sx={{ color: 'text.secondary' }}>
                Enter your credential below.
              </Typography>
            </Box>
          </Box> */}

          <Stack direction="row" spacing={1}>
            <MButton
              onClick={handlerMicrosoftLogin}
              color="inherit"
              variant="outlined"
              fullWidth
            >
              <Icon icon={microsoft} color="#DF3E30" height={24} />
            </MButton>
          </Stack>
          <Alert severity="info" sx={{ my: 2 }}>
            Only <strong>Microsoft Organization</strong> account type.
          </Alert>
          <Divider sx={{ my: 2 }} variant="fullWidth">
            <Typography color="inherit" variant="subtitle1">
              OR
            </Typography>
          </Divider>

          <LoginForm />

          {/* <Hidden smUp>
            <Typography variant="body2" align="center" sx={{ mt: 3 }}>
              Don’t have an account?&nbsp;
              <Link
                variant="subtitle2"
                component={RouterLink}
                to={PATH_AUTH.register}
              >
                Get started
              </Link>
            </Typography>
          </Hidden> */}
        </ContentStyle>
      </Container>
    </RootStyle>
  );
}
