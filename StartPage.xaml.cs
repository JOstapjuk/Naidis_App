namespace Naidis_App;

public partial class StartPage : ContentPage
{
    public List<ContentPage> lehed = new List<ContentPage>()
    {
        new TextPage(0),
        new FigurePage(1),
        new Valgusfoor(),
        new DateTime_Page(2),
        new StepperSliderPage(),
        new ColorStepper(),
        new Lumememm()
    };

    public List<string> tekstid = new List<string>
    {
        "Tee lahti TextPage",
        "Tee lahti FigurePage",
        "Tee lahti Valgusfoor",
        "Tee lahti DateTime_Page",
        "Tee lahti StepperSliderPage",
        "Tee lahti ColorStepper",
        "Tee lahti Lumemmem"
    };

    ScrollView sv;
    VerticalStackLayout vst;

    public StartPage()
    {
        Title = "Avaleht";
        vst = new VerticalStackLayout() { BackgroundColor = Color.FromRgb(180, 100, 20) };

        for (int i = 0; i < tekstid.Count; i++)
        {
            Button nupp = new Button
            {
                Text = tekstid[i],
                BackgroundColor = Color.FromRgb(20, 100, 200),
                TextColor = Color.FromRgb(10, 20, 15),
                FontFamily = "OpenSans-Regular",
                BorderWidth = 10,
                ZIndex = i
            };
            vst.Add(nupp);
            nupp.Clicked += Nupp_Clicked;
        }

        sv = new ScrollView { Content = vst };
        Content = sv;
    }

    private async void Nupp_Clicked(object? sender, EventArgs e)
    {
        Button btn = sender as Button;

        if (btn.ZIndex < lehed.Count)
        {
            await Navigation.PushAsync(lehed[btn.ZIndex]);
        }
    }
}
