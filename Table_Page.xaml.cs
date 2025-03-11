
namespace Naidis_App;

public partial class Table_Page : ContentPage
{
	TableView tableView;
	SwitchCell sc;
	ImageCell ic;
	TableSection fotosection;
	public Table_Page()
	{
		sc = new SwitchCell { Text = "Näita veel" };
		sc.OnChanged += Sc_onChanged;
		ic = new ImageCell
		{
			ImageSource = ImageSource.FromFile("cat.jpg"),
			Text = "Kass",
			Detail = "Väga ilus kass"
		};
		fotosection = new TableSection();

		tableView = new TableView
		{
			Intent = TableIntent.Form,
			Root = new TableRoot("Andmete sisestamine")
			{
				new TableSection("Põhiandmed:")
				{
					new EntryCell
					{
						Label = "Nimi:",
						Placeholder = "Sisesta oma sõbra nimi",
						Keyboard = Keyboard.Default
					}
				},
				new TableSection("Kontaktiandmed:")
				{
					new EntryCell
					{
						Label = "Telefon",
						Placeholder = "Sisesta tel. number",
						Keyboard = Keyboard.Telephone
					},
					new EntryCell
					{
						Label = "Email",
						Placeholder = "Sisesta email",
						Keyboard = Keyboard.Email
					},
					sc
				},
				fotosection
			}
		};
		Content = tableView;
	}

    private void Sc_onChanged(object? sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
			fotosection.Title = "Foto:";
			fotosection.Add(ic);
			sc.Text = "Peida";
        }
        else
        {
            fotosection.Title = "";
            fotosection.Remove(ic);
            sc.Text = "Näita veel";
        }
    }
}