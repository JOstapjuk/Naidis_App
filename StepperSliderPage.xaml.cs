namespace Naidis_App;

public partial class StepperSliderPage : ContentPage
{
    Label lbl;
    Slider sl;
    Stepper st;
    AbsoluteLayout abs;

    public StepperSliderPage()
    {
        lbl = new Label();
        sl = new Slider();
        st = new Stepper();
        abs = new AbsoluteLayout();

        lbl.BackgroundColor = Color.FromRgb(120, 144, 133);
        lbl.HorizontalTextAlignment = TextAlignment.Center;

        sl.Minimum = 0;
        sl.Maximum = 100;
        sl.Value = 25;
        sl.MinimumTrackColor = Color.FromRgb(55, 55, 55);
        sl.MaximumTrackColor = Color.FromRgb(0, 0, 0);
        sl.ThumbColor = Color.FromRgb(155, 155, 155);

        st.Minimum = 0;
        st.Maximum = 100;
        st.Increment = 5;
        st.Value = 25;
        st.HorizontalOptions = LayoutOptions.CenterAndExpand;

        sl.ValueChanged += Sl_ValueChanged;
        st.ValueChanged += Sl_ValueChanged;

        abs.Children.Add(lbl);
        abs.Children.Add(sl);
        abs.Children.Add(st);

        AbsoluteLayout.SetLayoutBounds(lbl, new Rect(10, 100, 300, 50));
        AbsoluteLayout.SetLayoutBounds(sl, new Rect(10, 300, 300, 50));
        AbsoluteLayout.SetLayoutBounds(st, new Rect(10, 400, 300, 50));

        Content = abs;
    }

    private void Sl_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        lbl.Text = String.Format("{0:F1}", e.NewValue);
        lbl.FontSize = e.NewValue;
        lbl.Rotation = e.NewValue;
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {

    }
}