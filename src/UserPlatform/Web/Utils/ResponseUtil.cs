namespace UserPlatform.Web.Utils
{
    /// <summary>
    /// Generic error message return format
    /// </summary>
    public class ResponseUtil
    {
        public static object ErrorResponse(string key, string value)
        {
            return new
            {
                Error = new Dictionary<string, object>()
                {
                    {key, value },
                }
            };
        }

    }
}
