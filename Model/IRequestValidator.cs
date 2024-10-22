namespace Kaszanka.Model
{
    public interface IRequestValidator
    {
        public bool ValidateUrl(string url)
        {
            try
            {
                var uri = new UriBuilder(url);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
