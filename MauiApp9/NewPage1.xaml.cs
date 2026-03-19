using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace MauiApp9;

public partial class NewPage1 : ContentPage
{

	public NewPage1()
	{
		InitializeComponent();
		entriesLabel.Text = $"{File.Exists(Path.Combine(FileSystem.AppDataDirectory, "dziennik.txt")) }";
    }
	private async void OnAddButtonClicked(object sender, EventArgs e)
	{
		string pathToFile = Path.Combine(FileSystem.AppDataDirectory, "dziennik.txt");

		if (File.Exists(pathToFile))
		{
			string noteText = $"{DateTime.Now:dd.MM.yyyy HH:mm}  {entryEditor.Text}";
			if (!string.IsNullOrWhiteSpace(noteText))
			{
				await File.AppendAllTextAsync(pathToFile, noteText );
				entryEditor.Text = "";
				await refreshNote();
			}
			else
			{
				await DisplayAlert("Błąd", "Nie można zapisać pustego tekstu.", "OK");
			}
		}
		else
		{
			await DisplayAlert("Błąd", "Plik nie istnieje.", "OK");
		}
	}

	private async Task refreshNote()
	{
        string pathToFile = Path.Combine(FileSystem.AppDataDirectory, "dziennik.txt");

        if (File.Exists(pathToFile))
		{
			string note = await File.ReadAllTextAsync(pathToFile);

			if(!string.IsNullOrWhiteSpace(note))
			{
				entriesLabel.Text = note;

			}
		}
	}
}