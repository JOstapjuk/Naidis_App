using Microsoft.Maui.Layouts;

namespace Naidis_App;

public partial class Lumememm : ContentPage
{
    private BoxView bucket;
    private BoxView body;
    private BoxView head;
    private Label statusLabelControl;
    private AbsoluteLayout abs;
    private Button HideBtn;
    private Button ShowBtn;
    private Button RandomBtn;
    private Button MeltBtn;
    private Button RotateBtn;

    public Lumememm()
	{
        bucket = new BoxView { WidthRequest = 150, HeightRequest = 150, BackgroundColor = Colors.Gold };
        AbsoluteLayout.SetLayoutBounds(bucket, new Rect(0.5, 0.8, 0.2, 0.15));
        AbsoluteLayout.SetLayoutFlags(bucket, AbsoluteLayoutFlags.PositionProportional);

        body = new BoxView { WidthRequest = 150, HeightRequest = 150, BackgroundColor = Colors.White, CornerRadius = 10 };
        AbsoluteLayout.SetLayoutBounds(body, new Rect(0.5, 0.5, 0.3, 0.3));
        AbsoluteLayout.SetLayoutFlags(body, AbsoluteLayoutFlags.PositionProportional);

        head = new BoxView { WidthRequest = 150, HeightRequest = 150, BackgroundColor = Colors.White, CornerRadius = 10 };
        AbsoluteLayout.SetLayoutBounds(head, new Rect(0.5, 0.3, 0.25, 0.25));
        AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);

        HideBtn = new Button { Text = "Hide snowman", FontSize = 14, HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Colors.Purple, TextColor = Colors.White };
        HideBtn.Clicked += HideSnowman_Clicked;


        ShowBtn = new Button { Text = "Show snowman", FontSize = 14, HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Colors.Purple, TextColor = Colors.White };
        ShowBtn.Clicked += ShowSnowman_Clicked;

        RandomBtn = new Button { Text = "Random colors snowman", FontSize = 14, HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Colors.Purple, TextColor = Colors.White };
        RandomBtn.Clicked += RandomColor_Clicked;

        MeltBtn = new Button { Text = "Melt snowman", FontSize = 14, HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Colors.Purple, TextColor = Colors.White };
        MeltBtn.Clicked += MeltSnowman_Clicked;

        RotateBtn = new Button { Text = "Rotate snowman", FontSize = 14, HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Colors.Purple, TextColor = Colors.White };
        RotateBtn.Clicked += RotateSnowman_Clicked;

        abs.Children.Add(bucket);
        abs.Children.Add(body);
        abs.Children.Add(head);
        abs.Children.Add(ShowBtn);
        abs.Children.Add(HideBtn);
        abs.Children.Add(RandomBtn);
        abs.Children.Add(MeltBtn);
        abs.Children.Add(RotateBtn);

        Content = abs;
    }

    private async void HideSnowman_Clicked(object sender, EventArgs e)
    {
        await bucket.FadeTo(0, 500);
        await body.FadeTo(0, 500);
        await head.FadeTo(0, 500);
        statusLabelControl.Text = "status: hidden";
    }

    private async void ShowSnowman_Clicked(object sender, EventArgs e)
    {
        await bucket.FadeTo(1, 500);
        await body.FadeTo(1, 500);
        await head.FadeTo(1, 500);
        statusLabelControl.Text = "status: shown";
    }

    private async void RandomColor_Clicked(object sender, EventArgs e)
    {
        Random random = new Random();
        await Task.Delay(200);

        int r = random.Next(0, 256);
        int g = random.Next(0, 256);
        int b = random.Next(0, 256);

        bool vastus = await DisplayAlert("V‰rvi muutus",
            $"Kas tahad v‰rvi muuta? Uued v‰rvi v‰‰rtused punane: {r} roheline: {g} sinine: {b}",
            "Jah", "Ei");

        if (vastus)
        {
            Color newColor = Color.FromRgb(r, g, b);
            bucket.Color = newColor;
            body.Color = newColor;
            head.Color = newColor;
            statusLabelControl.Text = "status: random colors";
        }
        else
        {
            bucket.Color = Colors.Goldenrod;
            body.Color = Colors.White;
            head.Color = Colors.White;
        }
    }

    private async void MeltSnowman_Clicked(object sender, EventArgs e)
    {
        await Task.WhenAll(
            bucket.TranslateTo(0, 100, 1000, Easing.SinIn),
            body.TranslateTo(0, 100, 1000, Easing.SinIn),
            head.TranslateTo(0, 100, 1000, Easing.SinIn)
        );
        statusLabelControl.Text = "status: melted";
    }

    private async void RotateSnowman_Clicked(object sender, EventArgs e)
    {
        await Task.WhenAll(
            bucket.RotateTo(360, 1000),
            body.RotateTo(360, 1000),
            head.RotateTo(360, 1000)
        );
        statusLabelControl.Text = "status: rotated";
    }
}