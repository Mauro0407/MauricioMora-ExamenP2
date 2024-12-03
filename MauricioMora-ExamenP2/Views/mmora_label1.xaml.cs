namespace MauricioMora_ExamenP2.Views;

public partial class mmora_label1 : ContentPage
{
    private async void GoToGridLayout(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new mmora_label2());
    }
    private string filepath;
	public mmora_label1()
	{
		InitializeComponent();
		BindingContext = this;
		filepath = Path.Combine(FileSystem.AppDataDirectory, "MauricioMora.txt");
		CargarUltimaRecarga();
	}
	public string UltimaRecarga {  get; set; }

	private void CargarUltimaRecarga()
	{
		if (File.Exists(filepath))
		{
			UltimaRecarga = File.ReadAllText(filepath);
		}
		else
		{
			UltimaRecarga = "Sin recargas hechas previamente";
		}
		OnPropertyChanged(nameof(UltimaRecarga));
	}
	private async void OnRecargaClicked(object sender, EventArgs e)
	{
		string nombre = NameEntry.Text;
		string telefono = PhoneEntry.Text;

		if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(telefono))
		{
			await DisplayAlert("Error", "Debe llenar los campos", "Ok");
			return;
		}
		string recargaInfo = $"Nombre : {nombre}, Teléfono: {telefono}, Fecha: {DateTime.Now}";
		File.WriteAllText(filepath, recargaInfo);

		await DisplayAlert("Exito", "La recarga fue exitosa", "Ok");

		CargarUltimaRecarga();

		NameEntry.Text = string.Empty;
		PhoneEntry.Text = string.Empty;
    }

}