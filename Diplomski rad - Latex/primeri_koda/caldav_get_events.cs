public IICalendarCollection ownCloudCalendar_GetEvents(Uri server, string username, string password)
{
	IICalendarCollection iCalCollection = null;
	try
	{
		iCalCollection = iCalendar.LoadFromUri(server, username, password);
	}
	catch (Exception ex)
	{
		Logging.LogError(ex, LoggingCategories.Controller);
		throw new LoggedException(ex);
	}
	return iCalCollection;
}