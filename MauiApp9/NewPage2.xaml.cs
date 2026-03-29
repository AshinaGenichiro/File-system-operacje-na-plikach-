namespace MauiApp9;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}
	async void onExportButtonClicked(object sender, EventArgs e)
	{
		string pathToFile = Path.Combine(FileSystem.Current.AppDataDirectory, "notatki_eksport.txt");
        if(!string.IsNullOrWhiteSpace(FileEditor.Text))
        {
		string note = $"[{DateTime.Now:dd.MM.yyyy HH:mm}] {FileEditor.Text}";
            await File.WriteAllTextAsync(pathToFile, note);
            await DisplayAlertAsync("Powiadomienie", "Udało się zapisać plik", "Ok");
        }
        else
        {
            await DisplayAlertAsync("Powiadomienie", "Nie udało się zapisać plik", "Ok");

        }
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
                if(fileName.Contains(".txt"))
                {
				await DisplayAlertAsync("Wybrano plik", $"Nazwa:{fileName}", "OK");
				infoLabel.Text= $"Został wybrany plik {fileName}";
                FileEditor.Text= await File.ReadAllTextAsync(fullPath);
                }
                else
                {
                    await DisplayAlertAsync("Powiadomienie", "Aplikacja obsługuje tylko pliki tekstowe", "Ok");
                }

            }
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Błąd", $"Nie udało sie wybrać pliku: {ex.Message}", "OK");
		}
		}

}
