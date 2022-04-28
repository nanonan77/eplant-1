// ----------------------------------------------------------------------

function path(root, sublink) {
  return `${root}${sublink}`;
}

const AUTH_ROOT = '';

// ----------------------------------------------------------------------

export const PATH_AUTH = {
  login: path(AUTH_ROOT, '/login'),
  logout: path(AUTH_ROOT, '/logout'),
  register: path(AUTH_ROOT, '/register'),
  resetPassword: path(AUTH_ROOT, '/reset-password'),
  changePassword: path(AUTH_ROOT, '/change-password'),
  consent: path(AUTH_ROOT, '/consent')
};

export const PATH_OIDC = {
  error: path(AUTH_ROOT, '/error'),
  errorMessage: path(AUTH_ROOT, '/errorMessage')
};
