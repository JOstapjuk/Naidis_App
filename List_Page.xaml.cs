

namespace Naidis_App;

public partial class List_Page : ContentPage
{
	public List<Telefon> telefons {  get; set; }
	Label lbl_list;
	ListView list;
	public List_Page()
	{
		telefons = new List<Telefon>
		{
			new Telefon {Nimetus="Samsung Galaxy S22 Ultra", Tootja="Samsung", Hind=1399, Pilt = "Naidis_App.Images.Samsung"},
            new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G NE", Tootja="Xiaomi", Hind=399, Pilt = "Naidis_App.Images.Xiaomi_NE"},
            new Telefon {Nimetus="Xiaomi Mi 11 Lite 5G ", Tootja="Xiaomi", Hind=399, Pilt  ="Naidis_App.Images.Xiaomi"},
            new Telefon {Nimetus="Iphone 13", Tootja="Apple", Hind=1179, Pilt = "Naidis_App.Images.Iphone"},
        };

		list = new ListView()
		{
			HasUnevenRows = true,
			ItemsSource = telefons,
			ItemTemplate = new DataTemplate(()=>
			{
				ImageCell imageCell = new ImageCell { TextColor = new Color(1, 0, 0, 1), DetailColor = new Color(0, 1, 0, 1) };
				imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
				Binding companyBinding = new Binding { Path = "Tootja", StringFormat = $"Tore telefon firmalt " };
				imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
				imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
				return imageCell;
			})
		};
		list.ItemTapped += List_ItemTapped;
		this.Content = new StackLayout { Children = { lbl_list, list } };
	}

    private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		Telefon selectedPhine = e.Item as Telefon;
		if (selectedPhine != null)
            await DisplayAlert("Valitud model", $"{selectedPhine.Tootja} - {selectedPhine.Nimetus}", "OK");
    }
}