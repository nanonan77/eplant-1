export default function getError(err) {
  if (!err) return '';
  if (err.response) {
    if (err.response.data && err.response.data.message) {
      return err.response.data.message;
    }
    return 'An Error occure';
  }
  if (err.message) return err.message;
  return 'Error occure.';
}
