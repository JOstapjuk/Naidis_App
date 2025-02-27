namespace Naidis_App;

public partial class PickerImagePage : ContentPage
{
	Grid gr4x1, gr3x3;
	Picker picker; // piltide valik
	Image img; //pilt
	Switch s_pilt, s_grid; // piltide kuvamine/peidamine ja grid 3x3 kuvamine/peidamine
	Random rnd = new Random();

	public PickerImagePage()
	{
		gr4x1 = new Grid
		{
            RowDefinitions =
			{
				new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
				new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
				new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
			},
			ColumnDefinitions =
			{
				new ColumnDefinition{Width=new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition{Width=new GridLength(1, GridUnitType.Star) }
            }
		};
		picker = new Picker
		{
			Title = "Pildid",
			HorizontalOptions = LayoutOptions.Center
		};
		picker.Items.Add("1. Pilt");
        picker.Items.Add("2. Pilt");
        picker.Items.Add("3. Pilt");
        picker.Items.Add("Enda valitud foto");

		picker.SelectedIndexChanged += Piltide_Valik;

		img = new Image
		{
			Source = "cat.jpg",
			HorizontalOptions = LayoutOptions.Center
		};

		s_pilt = new Switch
		{
			IsEnabled = true,
			IsToggled = true,
			HorizontalOptions = LayoutOptions.Center
		};
		s_pilt.Toggled += Kuva_Peida_pilt;

		s_grid = new Switch
		{
            IsEnabled = true,
            IsToggled = false,
            HorizontalOptions = LayoutOptions.Center
        };
		s_grid.Toggled += Kuva_Peida_grid;

		gr4x1.Add(picker,0,0);
		gr4x1.SetColumnSpan(picker, 2);
		gr4x1.Add(img, 0, 1);
		gr4x1.SetColumnSpan(img, 2);
		gr4x1.Add(s_pilt, 0, 3);
		gr4x1.Add(s_grid, 1, 3);
		Content = gr4x1;
    }

    private void Kuva_Peida_grid(object? sender, ToggledEventArgs e)
    {
		gr3x3 = new Grid();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
			{
				Frame f = new Frame
				{
					BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))
				};
				gr3x3.Add(f, i, j);
			}
        }
        if (e.Value)
        {
			gr4x1.Add(gr3x3, 0, 2);
			gr4x1.SetColumnSpan(gr3x3, 2);
        }
        else
        {
			gr4x1.RemoveAt(4);
        }
    }

    private void Kuva_Peida_pilt(object? sender, ToggledEventArgs e)
    {
		if (e.Value)
		{
			img.IsVisible = true;
		}
		else 
		{
			img.IsVisible = false;
		}
    }

    private async void Piltide_Valik(object? sender, EventArgs e)
    {
        if (picker.SelectedIndex==3)
        {
			var images = await FilePicker.Default.PickAsync(new PickOptions
			{
				FileTypes = FilePickerFileType.Images
			});
			var imageSource = images.FullPath.ToString();
			img.Source = imageSource;
        }
		else if (picker.SelectedIndex==2)
        {
			img.Source = "cat.jpg";
        }
        else if (picker.SelectedIndex == 1)
        {
            img.Source = "dog.jpg";
        }
        else if (picker.SelectedIndex == 0)
        {
            img.Source = "guinea.jpg";
        }
    }
}