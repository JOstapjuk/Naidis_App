using Microsoft.Maui.Graphics;
using System.Collections.ObjectModel;

namespace Naidis_App;

public partial class Riik_List : ContentPage
{
    public ObservableCollection<Riik> Riigid { get; set; }
    ListView riikideListView;

    public Riik_List()
	{
        Riigid = new ObservableCollection<Riik>
        {
            new Riik {Nimi="Prantsusmaa", Pealinn="Pariis", Rahvaarv=67000000, Lipp="france.png"},
            new Riik {Nimi="Saksamaa", Pealinn="Berliin", Rahvaarv=83100000, Lipp="germany.png"},
            new Riik {Nimi="Itaalia", Pealinn="Rooma", Rahvaarv=59000000, Lipp="italy.png"}
        };

        riikideListView = new ListView
        {
            HasUnevenRows = true,
            ItemsSource = Riigid,
            ItemTemplate = new DataTemplate(() =>
            {
                ImageCell imageCell = new ImageCell
                {
                    TextColor = Colors.Black,
                    DetailColor = Colors.Gray
                };
                imageCell.SetBinding(ImageCell.TextProperty, "Nimi");
                imageCell.SetBinding(ImageCell.DetailProperty, "Pealinn");
                imageCell.SetBinding(ImageCell.ImageSourceProperty, "Lipp");
                return imageCell;
            })
        };

        riikideListView.ItemTapped += RiikideListView_ItemTapped;

        Button lisaNupp = new Button { Text = "Lisa riik" };
        lisaNupp.Clicked += LisaRiik;

        Button kustutaNupp = new Button { Text = "Kustuta valitud" };
        kustutaNupp.Clicked += KustutaRiik;

        this.Content = new StackLayout { Children = { lisaNupp, kustutaNupp, riikideListView } };
    }

    private async void RiikideListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Riik valitudRiik = e.Item as Riik;
        if (valitudRiik != null)
        {
            await Navigation.PushAsync(new RiigiDetailPage(valitudRiik));
        }
    }

    private async void LisaRiik(object sender, EventArgs e)
    {
        string uusRiik = await DisplayPromptAsync("Lisa riik", "Sisesta riigi nimi:");
        if (!string.IsNullOrEmpty(uusRiik) && !Riigid.Any(r => r.Nimi.ToLower() == uusRiik.ToLower()))
        {
            Riigid.Add(new Riik { Nimi = uusRiik, Pealinn = "?", Rahvaarv = 0, Lipp = "default_flag.png" });
        }
        else
        {
            await DisplayAlert("Viga", "Riik on juba olemas või nimi on tühi!", "OK");
        }
    }

    private void KustutaRiik(object sender, EventArgs e)
    {
        if (riikideListView.SelectedItem != null)
        {
            Riik valitudRiik = (Riik)riikideListView.SelectedItem;
            Riigid.Remove(valitudRiik);
        }
    }

}