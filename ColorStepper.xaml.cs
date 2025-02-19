using Microsoft.Maui.Layouts;

namespace Naidis_App;

public partial class ColorStepper : ContentPage
{
    private Slider redSlider;
    private Slider greenSlider;
    private Slider blueSlider;
    private Stepper stepper;
    private Button randomButton;
    private BoxView colorBox;
    private Label colorLabel;
    private AbsoluteLayout abs;

    public ColorStepper()
    {
        abs = new AbsoluteLayout();

        redSlider = new Slider { Minimum = 0, Maximum = 255, Value = 0, MinimumTrackColor = Colors.Red, MaximumTrackColor = Colors.Gray, ThumbColor = Colors.Red };
        redSlider.ValueChanged += OnSliderValueChanged;

        greenSlider = new Slider { Minimum = 0, Maximum = 255, Value = 0, MinimumTrackColor = Colors.Green, MaximumTrackColor = Colors.Gray, ThumbColor = Colors.Green };
        greenSlider.ValueChanged += OnSliderValueChanged;

        blueSlider = new Slider { Minimum = 0, Maximum = 255, Value = 0, MinimumTrackColor = Colors.Blue, MaximumTrackColor = Colors.Gray, ThumbColor = Colors.Blue };
        blueSlider.ValueChanged += OnSliderValueChanged;

        stepper = new Stepper { Minimum = 0, Maximum = 100, Value = 100, Increment = 5 };
        stepper.ValueChanged += OnStepperValueChanged;

        randomButton = new Button { Text = "Juhuslik värv ja läbipaistvus", FontSize = 14, HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Colors.Purple, TextColor = Colors.White };
        randomButton.Clicked += OnRandomButtonClicked;

        colorBox = new BoxView { WidthRequest = 150, HeightRequest = 150, CornerRadius = 10, BackgroundColor = Colors.Red };

        colorLabel = new Label { Text = "RGB: 0, 0, 0", FontSize = 14, HorizontalTextAlignment = TextAlignment.Center };

        abs.Children.Add(redSlider);
        abs.Children.Add(greenSlider);
        abs.Children.Add(blueSlider);
        abs.Children.Add(stepper);
        abs.Children.Add(randomButton);
        abs.Children.Add(colorBox);
        abs.Children.Add(colorLabel);

        AbsoluteLayout.SetLayoutBounds(redSlider, new Rect(0.1, 0.05, 0.8, 0.07));
        AbsoluteLayout.SetLayoutFlags(redSlider, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(greenSlider, new Rect(0.1, 0.15, 0.8, 0.07));
        AbsoluteLayout.SetLayoutFlags(greenSlider, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(blueSlider, new Rect(0.1, 0.25, 0.8, 0.07));
        AbsoluteLayout.SetLayoutFlags(blueSlider, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(stepper, new Rect(0.1, 0.35, 0.8, 0.07));
        AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(randomButton, new Rect(0.1, 0.45, 0.8, 0.07));
        AbsoluteLayout.SetLayoutFlags(randomButton, AbsoluteLayoutFlags.All);

        AbsoluteLayout.SetLayoutBounds(colorBox, new Rect(0.5, 0.6, 0.3, 0.15));
        AbsoluteLayout.SetLayoutFlags(colorBox, AbsoluteLayoutFlags.PositionProportional);

        AbsoluteLayout.SetLayoutBounds(colorLabel, new Rect(0.1, 0.9, 0.8, 0.07));
        AbsoluteLayout.SetLayoutFlags(colorLabel, AbsoluteLayoutFlags.All);

        Content = abs;
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        int red = (int)redSlider.Value;
        int green = (int)greenSlider.Value;
        int blue = (int)blueSlider.Value;
        int labipaistvus = (int)stepper.Value;

        Color newColor = Color.FromRgba(red / 255f, green / 255f, blue / 255f, labipaistvus / 100f);
        colorBox.BackgroundColor = newColor;
        colorLabel.Text = $"RGB: {red}, {green}, {blue} (Läbipaistvus: {labipaistvus}%)";
    }

    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        OnSliderValueChanged(sender, e);
    }

    private async void OnRandomButtonClicked(object sender, EventArgs e)
    {
        Random random = new Random();
        await Task.Delay(200);

        int redValue = random.Next(0, 256);
        int greenValue = random.Next(0, 256);
        int blueValue = random.Next(0, 256);
        int labipaistvus = random.Next(0, 101);

        redSlider.Value = redValue;
        greenSlider.Value = greenValue;
        blueSlider.Value = blueValue;
        stepper.Value = labipaistvus;

        Color newColor = Color.FromRgba(redValue / 255f, greenValue / 255f, blueValue / 255f, labipaistvus / 100f);
        colorBox.BackgroundColor = newColor;
        colorLabel.Text = $"RGB: {redValue}, {greenValue}, {blueValue} (Läbipaistvus: {labipaistvus}%)";
    }
}
