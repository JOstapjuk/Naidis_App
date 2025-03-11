
namespace Naidis_App;

public partial class Table_Page : ContentPage
{
	TableView tableView;
	SwitchCell sc;
	ImageCell ic;
	TableSection fotosection;
	public Table_Page()
	{
		sc = new SwitchCell { Text = "N�ita veel" };
		sc.OnChanged += Sc_onChanged;
		ic = new ImageCell
		{
			ImageSource = ImageSource.FromFile("cat.jpg"),
			Text = "Kass",
			Detail = "V�ga ilus kass"
		};
		fotosection = new TableSection();

		tableView = new TableView
		{
			Intent = TableIntent.Form,
			Root = new TableRoot("Andmete sisestamine")
			{
				new TableSection("P�hiandmed:")
				{
					new EntryCell
					{
						Label = "Nimi:",
						Placeholder = "Sisesta oma s�bra nimi",
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
            sc.Text = "N�ita veel";
        }
    }
}