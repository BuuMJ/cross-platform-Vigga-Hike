using System.Collections.ObjectModel;
namespace cross_platform;

public partial class HikeList : ContentPage
{
	App thisApp = Microsoft.Maui.Controls.Application.Current as App;
	public HikeList()
	{
		InitializeComponent();
        collectionView.ItemsSource = thisApp.HikeList;
	}
    private void goAddNew(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage(), true);
    }
    private void notYet(object sender, EventArgs e)
    {
        DisplayAlert("Notification", "The feature is currently being updated and developed", "Close");
    }
}