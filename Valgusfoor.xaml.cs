namespace Naidis_App;

public partial class Valgusfoor : ContentPage
{
    private BoxView redLight, yellowLight, greenLight;
    private Label statusLabel;
    private bool isOn = false;
    private bool isBlinking = false;

    public Valgusfoor()
    {
        Title = "Valgusfoor";

        statusLabel = new Label
        {
            Text = "Kõigepealt lülitage valgusfoorid sisse",
            FontSize = 24,
            HorizontalOptions = LayoutOptions.Center
        };

        redLight = CreateLightBox(Colors.Gray);
        yellowLight = CreateLightBox(Colors.Gray);
        greenLight = CreateLightBox(Colors.Gray);

        var stackLayout = new StackLayout
        {
            Spacing = 10,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Children = { statusLabel, redLight, yellowLight, greenLight }
        };

        var turnOnButton = new Button { Text = "Sisse" };
        turnOnButton.Clicked += (s, e) => ToggleTrafficLight(true);

        var turnOffButton = new Button { Text = "Välja" };
        turnOffButton.Clicked += (s, e) => ToggleTrafficLight(false);

        var autoCycleButton = new Button { Text = "Automaatne reziim" };
        autoCycleButton.Clicked += (s, e) => StartTrafficLightCycle();

        redLight.GestureRecognizers.Add(CreateTapGestureRecognizer("Punane"));
        yellowLight.GestureRecognizers.Add(CreateTapGestureRecognizer("Kollane"));
        greenLight.GestureRecognizers.Add(CreateTapGestureRecognizer("Roheline"));

        Content = new StackLayout
        {
            Spacing = 20,
            Padding = new Thickness(20),
            Children = { stackLayout, turnOnButton, turnOffButton, autoCycleButton }
        };
    }

    private BoxView CreateLightBox(Color color)
    {
        return new BoxView
        {
            Color = color,
            WidthRequest = 100,
            HeightRequest = 100,
            CornerRadius = 50,
            HorizontalOptions = LayoutOptions.Center
        };
    }

    private TapGestureRecognizer CreateTapGestureRecognizer(string colorName)
    {
        return new TapGestureRecognizer
        {
            Command = new Command(() => ChangeLabelText(colorName))
        };
    }

    private void ToggleTrafficLight(bool turnOn)
    {
        isOn = turnOn;
        isBlinking = !turnOn;

        redLight.Color = turnOn ? Colors.Red : Colors.Gray;
        yellowLight.Color = turnOn ? Colors.Yellow : Colors.Gray;
        greenLight.Color = turnOn ? Colors.Green : Colors.Gray;

        statusLabel.Text = turnOn ? "Vali värv" : "Kõigepealt lülitage valgusfoorid sisse";
        if (!turnOn)
        {
            StartBlinkingYellow();
        }
    }

    private async void StartBlinkingYellow()
    {
        while (isBlinking)
        {
            yellowLight.Color = yellowLight.Color == Colors.Gray ? Colors.Yellow : Colors.Gray;
            await Task.Delay(1000);
        }
        yellowLight.Color = Colors.Gray;
    }

    private async void StartTrafficLightCycle()
    {
        if (!isOn) return;

        while (isOn)
        {
            redLight.Color = Colors.Red;
            yellowLight.Color = Colors.Gray;
            greenLight.Color = Colors.Gray;
            statusLabel.Text = "Stopp!";
            await Task.Delay(3000);

            for (int i = 0; i < 3; i++)
            {
                redLight.Color = Colors.Gray;
                yellowLight.Color = Colors.Yellow;
                statusLabel.Text = "Ole valmis!";
                await Task.Delay(500);

                redLight.Color = Colors.Gray;
                yellowLight.Color = Colors.Gray;
                await Task.Delay(500);
            }

            yellowLight.Color = Colors.Gray;
            greenLight.Color = Colors.Green;
            statusLabel.Text = "Mine!";
            await Task.Delay(3000);
        }
    }



    private void ChangeLabelText(string colorName)
    {
        if (isOn)
        {
            statusLabel.Text = colorName switch
            {
                "Punane" => "Stopp!",
                "Kollane" => "Ole valmis!",
                "Roheline" => "Mine!",
                _ => statusLabel.Text
            };
        }
        else
        {
            statusLabel.Text = "Kõigepealt lülitage valgusfoorid sisse";
        }
    }
}