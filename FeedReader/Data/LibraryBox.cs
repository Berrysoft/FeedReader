namespace FeedReader.Data
{
    public class LibraryBox
    {
        public LibraryBox(string name, string? url, string license, string? licenseUrl)
        {
            Name = name;
            Url = url;
            License = license;
            LicenseUrl = licenseUrl;
        }

        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? License { get; set; }
        public string? LicenseUrl { get; set; }
    }
}
