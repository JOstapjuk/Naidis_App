using Microsoft.Maui.Controls;
using System;

namespace Naidis_App;

public partial class lumemem : ContentPage
{
    private BoxView bucket;
    private CircleView body;
    private CircleView head;
    private Label statusLabel;

    public lumemem()
	{
		InitializeComponent();
	}
}