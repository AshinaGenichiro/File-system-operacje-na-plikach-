namespace MauiApp9;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}
	async void onExportButtonClicked(object sender, EventArgs e)
	{

	}

    async void onImportButtonClicked(object sender, EventArgs e)
	{
		try
		{
			var wynik = await FilePicker.Default.PickAsync();
			if (wynik != null)
			{
				string fileName = wynik.FileName;
				string fullPath = wynik.FullPath;

				await DisplayAlertAsync("Wybrano plik", $"Nazwa:{fileName}", "OK");
				infoLabel.Text= $"Został wybrany plik {fileName}";
                FileEditor.Text= await File.ReadAllTextAsync(fullPath);

            }
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Błąd", $"Nie udało sie wybrać pliku: {ex.Message}", "OK");
		}
		}

}
