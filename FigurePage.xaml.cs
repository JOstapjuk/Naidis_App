namespace Naidis_App;

public partial class FigurePage : ContentPage
{
    BoxView bw;
    Label clickLabel;
    Random rnd = new Random();
    HorizontalStackLayout hsl;
    List<string> buttons = new List<string>() { "Tagasi", "Avaleht", "Edasi" };

    public FigurePage(int k)
    {
        int r = rnd.Next(0, 225);
        int g = rnd.Next(0, 225);
        int b = rnd.Next(0, 225);

        bw = new BoxView()
        {
            Color = Color.FromRgb(r, g, b),
            CornerRadius = 20,
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        clickLabel = new Label()
        {
            Text = "Klikid: 0",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center
        };

        TapGestureRecognizer tap = new TapGestureRecognizer();
        tap.Tapped += Klik_boksi_peal;
        bw.GestureRecognizers.Add(tap);

        hsl = new HorizontalStackLayout()
        {
            HorizontalOptions = LayoutOptions.Center
        };

        for (int i = 0; i < 3; i++)
        {
            Button nupp = new Button
            {
                Text = buttons[i],
                ZIndex = i,
                WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / 8.3, 
            };
            hsl.Add(nupp);
            nupp.Clicked += Liikumine;
        }

        VerticalStackLayout vsl = new VerticalStackLayout
        {
            Children = { bw, hsl, clickLabel },
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        Content = vsl;
    }

    private async void Liikumine(object? sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ZIndex == 0)
        {
            await Navigation.PushAsync(new TextPage(btn.ZIndex));
        }
        else if (btn.ZIndex == 1)
        {
            await Navigation.PushAsync(new StartPage());
        }
        else
        {
            await Navigation.PushAsync(new FigurePage(btn.ZIndex));
        }
    }

    private void Klik_boksi_peal(object? sender, TappedEventArgs e)
    {
        bw.Color = Color.FromRgb(rnd.Next(0, 225), rnd.Next(0, 225), rnd.Next(0, 225));
        bw.WidthRequest = bw.Width + 20;
        bw.HeightRequest = bw.Height + 20;

        if (bw.WidthRequest > (int)DeviceDisplay.Current.MainDisplayInfo.Width / 3)
        {
            bw.HeightRequest = 200;
            bw.WidthRequest = 200;
        }

        int klikid = int.Parse(clickLabel.Text.Split(' ')[1]) + 1;
        clickLabel.Text = $"Klikid: {klikid}";
    }
}
