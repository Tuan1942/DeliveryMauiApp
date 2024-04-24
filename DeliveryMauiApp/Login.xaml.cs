
namespace ShoesStoreMauiApp;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        //webView.Navigating += OnNavigating;
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
            Source = new Uri("http://192.168.1.124:3001/Identity/Account/Manage"),
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
        var stackLayout = new StackLayout();
        stackLayout.Children.Add(webView);
        Content = stackLayout;
    }
    private async void OnNavigating(object sender, WebNavigatingEventArgs e)
    {
        var orderList = new OrderList();
        orderList.GetUserID(await GetUserID());
        // Ngăn chặn chuyển hướng
        //e.Cancel = true;
    }
    private async Task<string> GetUserID()
    {
        string result = "";
        try
        {
            string apiUrl = "http://192.168.1.124:3001/Home/GetUserID";
            using (HttpClient client = new HttpClient())
            {
                result = await client.GetStringAsync(apiUrl);
            }
        }
        catch (Exception)
        {
        }
        return result;
    }
}