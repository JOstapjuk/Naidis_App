namespace Naidis_App;

public partial class RiigiDetailPage : ContentPage
{
    private Riik _riik;
    private Entry pealinnEntry, rahvaarvEntry;

    public RiigiDetailPage(Riik riik)
    {
        _riik = riik;
        Title = riik.Nimi;

        Image lipp = new Image { Source = riik.Lipp, HeightRequest = 100 };

        Label pealinnLabel = new Label { Text = "Pealinn:" };
        pealinnEntry = new Entry { Text = riik.Pealinn };

        Label rahvaarvLabel = new Label { Text = "Rahvaarv:" };
        rahvaarvEntry = new Entry { Text = riik.Rahvaarv.ToString(), Keyboard = Keyboard.Numeric };

        Button changeFlagButton = new Button { Text = "Muuda lipp" };
        changeFlagButton.Clicked += async (sender, args) =>
        {
            var result = await FilePicker.PickAsync();
            if (result != null)
            {
                _riik.Lipp = result.FullPath; 
                lipp.Source = ImageSource.FromFile(result.FullPath);
            }
        };

        Button updateButton = new Button { Text = "Uuenda" };
        updateButton.Clicked += UpdateRiik;

        Button tagasiNupp = new Button { Text = "Tagasi" };
        tagasiNupp.Clicked += async (sender, args) => await Navigation.PopAsync();

        Content = new StackLayout
        {
            Padding = 20,
            Children = { lipp, pealinnLabel, pealinnEntry, rahvaarvLabel, rahvaarvEntry, changeFlagButton, updateButton, tagasiNupp }
        };
    }

    private async void UpdateRiik(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(pealinnEntry.Text) && int.TryParse(rahvaarvEntry.Text, out int newPop))
        {
            _riik.Pealinn = pealinnEntry.Text;
            _riik.Rahvaarv = newPop;

            await DisplayAlert("Uuendatud!", "Riigi andmed uuendatud.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Viga", "Palun sisesta kehtivad andmed.", "OK");
        }
    }
}
