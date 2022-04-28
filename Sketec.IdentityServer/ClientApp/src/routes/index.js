import NProgress from 'nprogress';
import { Switch, Route, Redirect } from 'react-router-dom';
import { Suspense, Fragment, lazy, useEffect, useMemo } from 'react';
// material
import { makeStyles } from '@material-ui/core/styles';
// components
import LoadingScreen from '../components/LoadingScreen';
// path
import { PATH_AUTH, PATH_OIDC } from './paths';

// ----------------------------------------------------------------------

const nprogressStyle = makeStyles((theme) => ({
  '@global': {
    '#nprogress': {
      pointerEvents: 'none',
      '& .bar': {
        top: 0,
        left: 0,
        height: 2,
        width: '100%',
        position: 'fixed',
        zIndex: theme.zIndex.snackbar,
        backgroundColor: theme.palette.primary.main,
        boxShadow: `0 0 2px ${theme.palette.primary.main}`
      },
      '& .peg': {
        right: 0,
        opacity: 1,
        width: 100,
        height: '100%',
        display: 'block',
        position: 'absolute',
        transform: 'rotate(3deg) translate(0px, -4px)',
        boxShadow: `0 0 10px ${theme.palette.primary.main}, 0 0 5px ${theme.palette.primary.main}`
      }
    }
  }
}));

function RouteProgress(props) {
  nprogressStyle();

  NProgress.configure({
    speed: 500,
    showSpinner: false
  });

  useMemo(() => {
    NProgress.start();
  }, []);

  useEffect(() => {
    NProgress.done();
  }, []);

  return <Route {...props} />;
}

export function renderRoutes(routes = []) {
  return (
    <Suspense fallback={<LoadingScreen />}>
      <Switch>
        {routes.map((route, i) => {
          const Component = route.component;
          const Guard = route.guard || Fragment;
          const Layout = route.layout || Fragment;

          return (
            <RouteProgress
              key={i}
              path={route.path}
              exact={route.exact}
              render={(props) => (
                <Guard>
                  <Layout>
                    {route.routes ? (
                      renderRoutes(route.routes)
                    ) : (
                      <Component {...props} />
                    )}
                  </Layout>
                </Guard>
              )}
            />
          );
        })}
      </Switch>
    </Suspense>
  );
}

const routes = [
  // Auth
  {
    exact: true,
    path: PATH_AUTH.login,
    component: lazy(() => import('../views/authentication/Login'))
  },
  {
    exact: true,
    path: PATH_AUTH.logout,
    component: lazy(() => import('../views/authentication/Logout'))
  },
  {
    exact: true,
    path: PATH_AUTH.register,
    component: lazy(() => import('../views/authentication/Register'))
  },
  {
    exact: true,
    path: PATH_AUTH.resetPassword,
    component: lazy(() => import('../views/authentication/ResetPassword'))
  },
  {
    exact: true,
    path: PATH_AUTH.changePassword,
    component: lazy(() => import('../views/authentication/ChangePassword'))
  },
  {
    exact: true,
    path: PATH_AUTH.consent,
    component: lazy(() => import('../views/authentication/Consent'))
  },

  // OIDC Routes
  {
    exact: true,
    path: PATH_OIDC.error,
    component: lazy(() => import('../views/Error'))
  },
  {
    exact: true,
    path: PATH_OIDC.errorMessage,
    component: lazy(() => import('../views/ErrorMessage'))
  },

  // Others Routes
  {
    exact: true,
    path: '/404',
    component: lazy(() => import('../views/Page404'))
  },

  {
    component: () => <Redirect to="/404" />
  }
];

export default routes;
