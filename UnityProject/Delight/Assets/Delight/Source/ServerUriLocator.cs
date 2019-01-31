namespace Delight
{
    /// <summary>
    /// Defeault server uri locator.
    /// </summary>
    public class ServerUriLocator
    {
        public virtual string GetServerUri(string bundleName)
        {
            return Assets.ServerUri;
        }
    }
}