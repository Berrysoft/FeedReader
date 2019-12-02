using WebWindows.Blazor;

namespace FeedReader
{
    public class Program
    {
        public static void Main()
        {
            ComponentsDesktop.Run<Startup>("FeedReader", "wwwroot/index.html");
        }
    }
}
