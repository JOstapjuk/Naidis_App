using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System;

namespace Naidis_App;

public partial class lumemem : ContentPage
{
    private BoxView bucket;
    private BoxView body;
    private BoxView head;
    private Label statusLabelControl;

    public lumemem()
    {
        InitializeComponent();

        bucket = (BoxView)FindByName("bucket");
        body = (BoxView)FindByName("body");
        head = (BoxView)FindByName("head");

        AbsoluteLayout.SetLayoutBounds(bucket, new Rect(0.5, 0.8, 0.2, 0.15));
        AbsoluteLayout.SetLayoutFlags(bucket, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(body, new Rect(0.5, 0.5, 0.3, 0.3));
        AbsoluteLayout.SetLayoutFlags(body, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(head, new Rect(0.5, 0.3, 0.25, 0.25));
        AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);

        statusLabelControl = statusLabelControl;
    }

    private async void HideSnowman_Clicked(object sender, EventArgs e)
    {
        await bucket.FadeTo(0, 500);
        await body.FadeTo(0, 500);
        await head.FadeTo(0, 500);
        statusLabelControl.Text = "??????: ?????";
    }

    private async void ShowSnowman_Clicked(object sender, EventArgs e)
    {
        await bucket.FadeTo(1, 500);
        await body.FadeTo(1, 500);
        await head.FadeTo(1, 500);
        statusLabelControl.Text = "??????: ???????";
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
            statusLabelControl.Text = "??????: ????????? ????";
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
        statusLabelControl.Text = "??????: ?????????";
    }

    private async void RotateSnowman_Clicked(object sender, EventArgs e)
    {
        await Task.WhenAll(
            bucket.RotateTo(360, 1000),
            body.RotateTo(360, 1000),
            head.RotateTo(360, 1000)
        );
        statusLabelControl.Text = "??????: ????????";
    }
}