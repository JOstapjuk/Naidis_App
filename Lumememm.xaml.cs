using Microsoft.Maui.Layouts;
using Microsoft.Maui.Graphics;

namespace Naidis_App;

public partial class Lumememm : ContentPage
{
    private BoxView bucket;
    private BoxView body;
    private BoxView head;
    private BoxView bodyBottom;  
    private Label statusLabelControl;
    private AbsoluteLayout snowmanLayout;

    public Lumememm()
    {
        Title = "lumemem";

        snowmanLayout = new AbsoluteLayout
        {
            HeightRequest = 380, 
            WidthRequest = 300,
            BackgroundColor = Colors.SkyBlue
        };

        bucket = new BoxView { Color = Colors.Gold, WidthRequest = 60, HeightRequest = 60, BackgroundColor = Colors.Transparent };
        body = new BoxView { Color = Colors.White, CornerRadius = 50, WidthRequest = 90, HeightRequest = 90, BackgroundColor = Colors.Transparent };
        head = new BoxView { Color = Colors.White, CornerRadius = 50, WidthRequest = 75, HeightRequest = 75, BackgroundColor = Colors.Transparent };
        bodyBottom = new BoxView { Color = Colors.White, CornerRadius = 50, WidthRequest = 60, HeightRequest = 60, BackgroundColor = Colors.Transparent };

        AbsoluteLayout.SetLayoutBounds(bucket, new Rect(145, 30, 45, 60));
        AbsoluteLayout.SetLayoutFlags(bucket, AbsoluteLayoutFlags.None);

        AbsoluteLayout.SetLayoutBounds(head, new Rect(125, 150, 75, 75));
        AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.None);

        AbsoluteLayout.SetLayoutBounds(body, new Rect(110, 220, 100, 100));
        AbsoluteLayout.SetLayoutFlags(body, AbsoluteLayoutFlags.None);

        AbsoluteLayout.SetLayoutBounds(bodyBottom, new Rect(135, 90, 60, 60));
        AbsoluteLayout.SetLayoutFlags(bodyBottom, AbsoluteLayoutFlags.None);

        snowmanLayout.Add(bucket);
        snowmanLayout.Add(body);
        snowmanLayout.Add(head);
        snowmanLayout.Add(bodyBottom);

        bucket.Opacity = 1;
        body.Opacity = 1;
        head.Opacity = 1;
        bodyBottom.Opacity = 1;

        Button hideButton = new Button { Text = "Peida", FontFamily="Loving Moment 400", FontSize = 32 };
        hideButton.Clicked += HideSnowman_Clicked;

        Button showButton = new Button { Text = "Näita", FontFamily = "Loving Moment 400", FontSize = 32 };
        showButton.Clicked += ShowSnowman_Clicked;

        Button randomColorButton = new Button { Text = "Värvi juhusliku värviga", FontFamily = "Loving Moment 400", FontSize = 32 };
        randomColorButton.Clicked += RandomColor_Clicked;

        Button meltButton = new Button { Text = "Sulata", FontFamily = "Loving Moment 400", FontSize = 32 };
        meltButton.Clicked += MeltSnowman_Clicked;

        Button rotateButton = new Button { Text = "Pööramine", FontFamily = "Loving Moment 400", FontSize = 32 };
        rotateButton.Clicked += RotateSnowman_Clicked;

        statusLabelControl = new Label { Text = "Staatus: ", FontSize = 32, FontFamily = "Loving Moment 400" };

        StackLayout stackLayout = new StackLayout
        {
            Padding = 20,
            Children = { snowmanLayout, hideButton, showButton, randomColorButton, meltButton, rotateButton, statusLabelControl }
        };

        Content = stackLayout;
    }

    private async void HideSnowman_Clicked(object sender, EventArgs e)
    {
        await Task.WhenAll(bucket.FadeTo(0, 500), body.FadeTo(0, 500), head.FadeTo(0, 500), bodyBottom.FadeTo(0, 500));
        statusLabelControl.Text = "Staatus: peidetud";
    }

    private async void ShowSnowman_Clicked(object sender, EventArgs e)
    {
        await Task.WhenAll(bucket.FadeTo(1, 500), body.FadeTo(1, 500), head.FadeTo(1, 500), bodyBottom.FadeTo(1, 500));

        await Task.WhenAll(
            bucket.TranslateTo(0, 0, 500),
            body.TranslateTo(0, 0, 500),
            head.TranslateTo(0, 0, 500),
            bodyBottom.TranslateTo(0, 0, 500)
        );

        bucket.Rotation = 0;
        body.Rotation = 0;
        head.Rotation = 0;
        bodyBottom.Rotation = 0;

        bucket.Color = Colors.Gold;
        body.Color = Colors.White;
        head.Color = Colors.White;
        bodyBottom.Color = Colors.White;

        statusLabelControl.Text = "Staatus: näidatud";
    }

    private async void RandomColor_Clicked(object sender, EventArgs e)
    {
        Random random = new Random();
        int r = random.Next(0, 256);
        int g = random.Next(0, 256);
        int b = random.Next(0, 256);

        bool answer = await DisplayAlert("Värvi muutus", $"Kas tahad värvi muuta? Uued värvi väärtused: R: {r}, G: {g}, B: {b}", "Jah", "Ei");

        if (answer)
        {
            Color newColor = Color.FromRgb(r, g, b);
            bucket.Color = newColor;
            body.Color = newColor;
            head.Color = newColor;
            bodyBottom.Color = newColor;
            statusLabelControl.Text = "Staatus: Muudetud värvus";
        }
        else
        {
            bucket.Color = Colors.Gold;
            body.Color = Colors.White;
            head.Color = Colors.White;
            bodyBottom.Color = Colors.White; 
        }
    }

    private async void MeltSnowman_Clicked(object sender, EventArgs e)
    {
        //https://learn.microsoft.com/en-us/dotnet/maui/user-interface/animation/easing?view=net-maui-9.0
        await Task.WhenAll(
            bucket.TranslateTo(0, 100, 1000, Easing.SinIn),
            body.TranslateTo(0, 100, 1000, Easing.SinIn),
            head.TranslateTo(0, 100, 1000, Easing.SinIn),
            bodyBottom.TranslateTo(0, 100, 1000, Easing.SinIn)
        );
        statusLabelControl.Text = "Staatus: sulanud";
    }

    private async void RotateSnowman_Clicked(object sender, EventArgs e)
    {
        await Task.WhenAll(
            bucket.RotateTo(360, 1000),
            body.RotateTo(360, 1000),
            head.RotateTo(360, 1000),
            bodyBottom.RotateTo(360, 1000)
        );
        statusLabelControl.Text = "Staatus: pööratud";
    }
}
