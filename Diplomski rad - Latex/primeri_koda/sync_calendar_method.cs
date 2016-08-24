private void btnSyncCalendar_Click(object sender, EventArgs e)
{
	try
	{
		if (ValidateControls())
		{
			IICalendarCollection iCalCollection = GetCalendarEventsData();

			if (iCalCollection == null)
			{
				ShowMessage("There is no calendar with the name " + txtCalendarName.Text.Trim(), "ownCloud Calendar Sync Unavailable");
			}
			else
			{
				Hide();
				int? syncTimerInterval = null;
				if(!String.IsNullOrEmpty(txtTimerInterval.Text))
				{
					syncTimerInterval = Convert.ToInt32(txtTimerInterval.Text);
				}
				EventsList eventsList = 
					new EventsList(iCalCollection, cbAutomaticSync.Checked, syncTimerInterval, txtCalendarName.Text, serverUrl, username, password, serverAddress);
				eventsList.ShowDialog();
				if (eventsList.IsHiden)
				{
					HideForm();
				}
				else
				{
					Show();
				}
			}
		}
	}
	catch (Exception ex)
	{
		HandleException(ex);
	}
}
		
private IICalendarCollection GetCalendarEventsData()
{
	owdCloudCalendarConnector connector = new owdCloudCalendarConnector();

	string url = serverAddress 
					+ cCalDavUrlExtension 
						+ username 
							+ cCalDavUrlExtensionSlash 
								+ txtCalendarName.Text.Trim().ToLower() 
									+ cCalDavUrlExtensionExport;
	serverUrl = new Uri(url);

	return connector.ownCloudCalendar_GetEvents(serverUrl, username, password);
}