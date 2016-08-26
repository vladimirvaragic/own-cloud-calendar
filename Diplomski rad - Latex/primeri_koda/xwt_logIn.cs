using Xwt;
using Xwt.Drawing;

public class LogIn : BaseForm
{
	#region Private fields

	Label lblTitle = new Label("Connect to ownCloud")
	{
		Font = Font.SystemFont.WithWeight(Xwt.Drawing.FontWeight.Bold).WithSize(14)
    };
    Label lblServerAddress = new Label("Server address");
    TextEntry txtServerAddress = new TextEntry();
    Label lblUserName = new Label("Username");
    TextEntry txtUsername = new TextEntry();
    Label lblPassword = new Label("Password");
    PasswordEntry txtPassword = new PasswordEntry();
    Button btnLogIn = new Button("Log in");

	#endregion Private fields
	
	#region Constructors

	public LogIn()
	{
		try
		{
			DrawControls();

			btnLogIn.Clicked += delegate
			{
				btnLogIn_Click();
			};
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}
	
	#endregion Constructors
	
	#region Nonvirtual methods

	private void DrawControls()
	{
		lblTitle.MinWidth = 220;
		AddChild(lblTitle, 13, 13);
		AddChild(lblServerAddress, 13, 60);
		txtServerAddress.WidthRequest = 278;
		AddChild(txtServerAddress, 96, 57);

		AddChild(lblUserName, 13, 90);
		txtUsername.WidthRequest = 278;
		AddChild(txtUsername, 96, 87);

		AddChild(lblPassword, 13, 120);
		txtPassword.WidthRequest = 278;
		AddChild(txtPassword, 96, 117);

		btnLogIn.MinWidth = 90;
		btnLogIn.MinHeight = 30;
		btnLogIn.BackgroundColor = Xwt.Drawing.Color.FromBytes(68, 187, 238);
		AddChild(btnLogIn, 382, 170);
	}

	#endregion Nonvirtual methods
}