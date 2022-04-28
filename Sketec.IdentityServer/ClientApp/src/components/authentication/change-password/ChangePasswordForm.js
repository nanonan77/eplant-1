import * as Yup from 'yup';
import PropTypes from 'prop-types';
import { Form, FormikProvider, useFormik } from 'formik';
// material
import { TextField } from '@material-ui/core';
import { LoadingButton } from '@material-ui/lab';
// hooks
import useAuth from '../../../hooks/useAuth';
import useIsMountedRef from '../../../hooks/useIsMountedRef';
// Utils
import getError from '../../../utils/getError';

// ----------------------------------------------------------------------

ResetPasswordForm.propTypes = {
  onChanged: PropTypes.func
};

export default function ResetPasswordForm({ onChanged }) {
  const { changePassword } = useAuth();
  const isMountedRef = useIsMountedRef();

  const ResetPasswordSchema = Yup.object().shape({
    password: Yup.string().required('New Password is required'),
    confirmPassword: Yup.string().required('Confirm New Password is required')
  });

  const formik = useFormik({
    initialValues: {
      password: '',
      confirmPassword: ''
    },
    validationSchema: ResetPasswordSchema,
    onSubmit: async (values, { setErrors, setSubmitting }) => {
      if (values.password !== values.confirmPassword) {
        setErrors({
          confirmPassword: 'Confirm New Passowrd must match with New Password.'
        });
        return;
      }
      try {
        await changePassword(values.email);
        if (isMountedRef.current) {
          onChanged();
          setSubmitting(false);
        }
      } catch (error) {
        if (isMountedRef.current) {
          setErrors({ email: getError(error) });
          setSubmitting(false);
        }
      }
    }
  });

  const { errors, touched, isSubmitting, handleSubmit, getFieldProps } = formik;

  return (
    <FormikProvider value={formik}>
      <Form autoComplete="off" noValidate onSubmit={handleSubmit}>
        <TextField
          fullWidth
          {...getFieldProps('password')}
          type="password"
          label="New Password"
          error={Boolean(touched.password && errors.password)}
          helperText={touched.password && errors.password}
          sx={{ mb: 3 }}
        />
        <TextField
          fullWidth
          {...getFieldProps('confirmPassword')}
          type="password"
          label="Confirm New Password"
          error={Boolean(touched.confirmPassword && errors.confirmPassword)}
          helperText={touched.confirmPassword && errors.confirmPassword}
          sx={{ mb: 3 }}
        />
        <LoadingButton
          fullWidth
          size="large"
          type="submit"
          variant="contained"
          loading={isSubmitting}
        >
          Reset Password
        </LoadingButton>
      </Form>
    </FormikProvider>
  );
}
