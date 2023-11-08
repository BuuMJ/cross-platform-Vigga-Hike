using System.Collections.ObjectModel;
using System.Data.Common;

namespace cross_platform
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        App thisApp = Microsoft.Maui.Controls.Application.Current as App;
        private SQLiteDatabase db;

        public MainPage()
        {
            InitializeComponent();
            thisApp.HikeList = new ObservableCollection<Hike>();
            db = new SQLiteDatabase();
        }
        private async void addNewHike(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                await DisplayAlert("Warning", "Please enter a hike of name.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtDesti.Text))
            {
                await DisplayAlert("Warning", "Please enter a destination.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtLength.Text))
            {
                await DisplayAlert("Warning", "Please enter a distances.", "OK");
                return;
            }
            else if (dtpStartDate.Date < DateTime.Today)
            {
                await DisplayAlert("Warning", "Please select a current or future start date.", "OK");
                return;
            }
            else if (txtParking.SelectedIndex == -1)
            {
                await DisplayAlert("Reminder", "Please select the parking lot.", "OK");
                return;
            }
            else if (txtLevel.SelectedIndex == -1) {
                await DisplayAlert("Reminder", "Please select the level of difficulty before submitting.", "OK");
                return;
            }
            var response = await DisplayAlert("Confirmation", "Do you agree with the above information?", "OK", "Cancle");
            if (response) {
                Hike hike = new Hike(count++,
                                            this.txtName.Text,
                                            this.txtDesti.Text,
                                            this.txtLength.Text,
                                            this.dtpStartDate.Date.ToString(),
                                            this.txtLevel.SelectedItem.ToString(),
                                            this.txtParking.SelectedItem.ToString(),
                                            this.txtDesc.Text);
                thisApp.HikeList.Add(hike);
                db.insertHike(hike);
                await DisplayAlert("Notification", txtName.Text + " has been created", "OK");
                txtName.Text = "";
                txtDesc.Text = "";
                txtDesti.Text = "";
                txtParking.SelectedIndex = -1;
                txtLevel.SelectedIndex = -1;
                txtLength.Text = "";
                dtpStartDate.Date = DateTime.Today;
            }

        }
        private void goHikeList(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HikeList(), true);

        }
        private void getHikeList(object sender, EventArgs e) { 
            thisApp.HikeList = db.getHikeList();
        }
    }
}