private void SetNotificationTimer()
{
	Timer timer = new Timer();
	int pingTimeInterval;

	pingTimeInterval = Convert.ToInt32(ConfigurationManager.AppSettings["notificationPingTimeInterval"].ToString());
	timer.Tick += new EventHandler(CheckEventStartTime);

	timer.Interval = pingTimeInterval;
	timer.Start();
	CheckEventStartTime(this, null);
}