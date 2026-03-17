namespace MauiApp9
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            string pathToFile = Path.Combine(FileSystem.AppDataDirectory, "moj_plik.txt");
            string noteText = textEntry.Text;
            if (!string.IsNullOrWhiteSpace(noteText))
            {
                if (File.Exists(pathToFile))
                {
                    await File.WriteAllTextAsync(pathToFile, noteText);
                    resultLabel.Text = "Zapisano do pliku.";
                }
                else
                {
                    resultLabel.Text = "Nie można znaleźć pliku.";
                }
            }
            else
            {
                resultLabel.Text = "Nie można zapisać pustego tekstu.";
            }
        }
        private async void OnReadButtonClicked(object? sender, EventArgs e)
        {
            string pathToFile = Path.Combine(FileSystem.AppDataDirectory, "moj_plik.txt");
            
            if (File.Exists(pathToFile))
            {
                string noteText = await File.ReadAllTextAsync(pathToFile);
                resultLabel.Text = $"Zawartość pliku: {noteText}";
            }
            else
            {
                resultLabel.Text = "Nie można znaleźć pliku.";
            }
        }
    }
}
