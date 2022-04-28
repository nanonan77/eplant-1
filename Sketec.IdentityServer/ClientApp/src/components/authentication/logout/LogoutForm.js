import PropTypes from 'prop-types';
import { useEffect, useState } from 'react';
// Materail
import { Typography, Box, Stack, Paper } from '@material-ui/core';
// qs
import qs from 'qs';
// Util
import useAxios from '../../../hooks/useAxios';
import useAuth from '../../../hooks/useAuth';
//
import MButton from '../../@material-extend/MButton';

// .........................................................

LogoutForm.propTypes = {
  onFinish: PropTypes.func
};

export default function LogoutForm({ onFinish }) {
  const axios = useAxios();
  const { logout } = useAuth();
  const [showConfirm, setShowConfirm] = useState(false);
  const [loading, setLoading] = useState(false);
  const [logoutCtx, setLogoutCtx] = useState(null);
  const [iframeUrl, setIframeUrl] = useState(null);

  useEffect(() => {
    const { logoutId } = qs.parse(window.location.search, {
      ignoreQueryPrefix: true
    });

    async function getLogoutCtx(id) {
      try {
        setLoading(true);

        let logoutReq = null;
        let showSignOutPrompt = true;
        if (!id) {
          const resp = await axios.post(`/oidc/logout`);
          if (resp && resp.data) {
            logoutReq = resp.data;
          }
        } else {
          const resp = await axios.get(`/oidc/logout/${id}`);
          if (resp && resp.data) {
            logoutReq = resp.data;
          }
        }

        if (logoutReq) {
          showSignOutPrompt = logoutReq.showSignoutPrompt;
          if (!showSignOutPrompt) {
            logoutHandler(logoutReq);
          }
        }

        setShowConfirm(showSignOutPrompt);
        setLogoutCtx(logoutReq);
      } catch (ex) {
        console.log(ex);
      } finally {
        setLoading(false);
      }
    }
    getLogoutCtx(logoutId);

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const logoutHandler = async (logoutCtx) => {
    const { signOutIFrameUrl, postLogoutRedirectUri } = logoutCtx || {};
    setIframeUrl(signOutIFrameUrl);
    try {
      setLoading(true);
      await logout();
      setTimeout(() => {
        if (postLogoutRedirectUri) window.location = postLogoutRedirectUri;
        else window.location = '/Login';
      }, 3000);
    } catch (ex) {
      console.log(ex);
    } finally {
      setLoading(false);
      onFinish();
    }
  };

  const onConfirm = async () => {
    setShowConfirm(false);
    await logoutHandler(logoutCtx);
  };

  const onCancel = () => {
    setShowConfirm(false);
    const { postLogoutRedirectUri } = logoutCtx || {};
    if (postLogoutRedirectUri) window.location = postLogoutRedirectUri;
    else window.location = '/';
  };

  return (
    <>
      {loading && (
        <Typography align="center" variant="body1">
          Logging out...
        </Typography>
      )}

      <Box sx={{ display: showConfirm ? 'block' : 'none' }}>
        <Paper elevation={3} sx={{ padding: 3 }}>
          <Typography align="center" gutterBottom variant="h3">
            Are you sure to logged out?
          </Typography>

          <Stack
            sx={{ mt: 1 }}
            direction="row"
            spacing={2}
            justifyContent="center"
          >
            <MButton onClick={onConfirm} variant="contained">
              Confirm
            </MButton>
            <MButton onClick={onCancel} variant="outlined">
              Cancel
            </MButton>
          </Stack>
        </Paper>
      </Box>

      <Box component="iframe" src={iframeUrl} sx={{ display: 'none' }} />
    </>
  );
}
