namespace Isas.Models.InsurerViewModels
{
    public class NavBarItemViewModel
    {
        public string Text { get; set; }
        public string Url { get; set; }

        public NavBarItemViewModel(string text, string url)
        {
            Text = text;
            Url = url;
        }
    }
}
