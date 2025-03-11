namespace Naidis_App;

public partial class Table_Page : ContentPage
{
	TableView tableView;
	public Table_Page()
	{
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
				},
			}
		};
		Content = tableView;
	}
}