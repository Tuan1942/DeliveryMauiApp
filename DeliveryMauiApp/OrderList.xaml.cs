using Microsoft.Maui.Platform;

namespace ShoesStoreMauiApp;

public partial class OrderList : ContentPage
{
    string UserID;
    private Microsoft.Maui.Controls.WebView webView;
    ScrollView scrollView = new ScrollView();
    public OrderList() 
	{
        InitializeComponent();
    }
    public string GetUserID(string UserID)
    {
        this.UserID = UserID;
        return UserID;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshContent();

    }
    private void RefreshContent()
    {
        webView = new Microsoft.Maui.Controls.WebView()
        {
            Source = new Uri("http://192.168.1.124:3001/Home/DeliveryHistory"),
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