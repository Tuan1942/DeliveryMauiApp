using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace ShoesStoreMauiApp
{
    public partial class MainPage : ContentPage
    {
        private Microsoft.Maui.Controls.WebView webView;
        private RefreshView refreshView;
        private ScrollView scrollView = new ScrollView();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshContent();
        }
        private void RefreshContent()
        {
            var webView = new Microsoft.Maui.Controls.WebView()
            {
                Source = new Uri("http://192.168.1.124:3001/Home/OrderDelivering"),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var stackLayout = new StackLayout();
            stackLayout.Children.Add(webView);
            Content = stackLayout;
        }
        protected override bool OnBackButtonPressed()
        {
            RefreshContent();
            return true;
        }
    }
}
