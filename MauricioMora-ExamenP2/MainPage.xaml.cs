namespace MauricioMora_ExamenP2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToRecargasPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.mmora_label1());
        }
    }

}
