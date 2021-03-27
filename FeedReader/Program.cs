using System;
using Photino.Blazor;

namespace FeedReader
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            ComponentsDesktop.Run<Startup>("FeedReader", "wwwroot/index.html");
        }
    }
}
