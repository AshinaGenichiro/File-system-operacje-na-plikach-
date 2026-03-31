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
		refreshNote();
    }
	private async void OnAddButtonClicked(object sender, EventArgs e)
	{
		string pathToFile = Path.Combine(FileSystem.AppDataDirectory, "dziennik.txt");

			if (!string.IsNullOrWhiteSpace(entryEditor.Text))
			{
				string noteText = $"[{DateTime.Now:dd.MM.yyyy HH:mm}] {entryEditor.Text} \n";
				await File.AppendAllTextAsync(pathToFile, noteText );
				
				entryEditor.Text = "";
				await refreshNote();
			}
			else
			{
				await DisplayAlert("Błąd", "Nie można zapisać pustego tekstu.", "OK");
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
			else
			{
				entriesLabel.Text = "Dziennik jest pusty.";
            }
		}
		else
		{
			entriesLabel.Text = "Brak wpisów w dzienniku.";
        }
	}
	private async void OnClearButtonClicked(object sender, EventArgs e)
	{

		string pathToFile = Path.Combine(FileSystem.AppDataDirectory, "dziennik.txt");
		bool confirm = await DisplayAlert("Potwierdzenie", "Czy na pewno chcesz wyczyścić dziennik?", "Tak", "Nie");
		
		if (confirm)
		{
			File.Delete(pathToFile);
			await refreshNote();
        }

    }
}
//******************************************************************
//Nazwa funkcji: OnAddButtonClicked
//Opis funkcji: Funkcja służy do dodania notatki, pobiera tekst z entryEditor i dodaje go do pliku tekstowego dziennik.txt
//Parametry Object sender obiekt wywołujacy zdarzenie, EventArgs e dane dotyczące zdarzenia 
//zwracany typ brak 
//*******************************************************************
//Nazwa funkcji: OnClearButtonClicked
//Opis funkcji: Podczas kliknięcia na przycisk, funkcja czyści dane.
//Parametry Object sender obiekt wywołujacy zdarzenie, EventArgs e dane dotyczące zdarzenia
//Zwracany typ brak
//*******************************************************************
