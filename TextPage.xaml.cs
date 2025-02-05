namespace Naidis_App;

public partial class TextPage : ContentPage
{
    Label lbl, charCountLabel;
    Editor editor;
    HorizontalStackLayout hsl;
    List<string> buttons = new List<string> { "Tagasi", "Avaleht", "Edasi" };
    private int charLimit = 50; 

    public TextPage(int k)
    {
        lbl = new Label()
        {
            Text = "Pealkiri",
            TextColor = Color.FromRgb(100, 10, 10),
            FontFamily = "OpenSans-Regular",
            FontAttributes = FontAttributes.Bold,
            TextDecorations = TextDecorations.Underline,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
            FontSize = 28
        };

        editor = new Editor()
        {
            Placeholder = "Vihje: Sissesta siia tekst",
            PlaceholderColor = Color.FromRgb(250, 200, 100),
            TextColor = Color.FromRgb(255, 200, 100), 
            BackgroundColor = Color.FromRgb(100, 50, 200),
            FontSize = 28,
            FontAttributes = FontAttributes.Italic
        };

        charCountLabel = new Label()
        {
            Text = $"Märkide arv: 0 / {charLimit}",
            TextColor = Color.FromRgb(255, 200, 100), 
            FontSize = 18,
            HorizontalTextAlignment = TextAlignment.Center
        };

        editor.TextChanged += Teksti_sissestamine;

        hsl = new HorizontalStackLayout();
        for (int i = 0; i < 3; i++)
        {
            Button b = new Button()
            {
                Text = buttons[i],
                ZIndex = i,
                WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / 8.3
            };
            hsl.Add(b);
            b.Clicked += Liikumine;
        }

        VerticalStackLayout vst = new VerticalStackLayout
        {
            Children = { lbl, editor, charCountLabel, hsl },
            VerticalOptions = LayoutOptions.End
        };
        Content = vst;
    }

    private void Teksti_sissestamine(object? sender, TextChangedEventArgs e)
    {
        lbl.Text = editor.Text;
        charCountLabel.Text = $"Märkide arv: {editor.Text.Length} / {charLimit}";

        if (editor.Text.Length > charLimit)
        {
            editor.Text = editor.Text.Substring(0, charLimit);
        }
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

    private async void Tagasi_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
