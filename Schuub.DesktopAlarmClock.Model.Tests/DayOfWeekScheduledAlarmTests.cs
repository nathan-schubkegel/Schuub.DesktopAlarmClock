using Schuub.DesktopAlarmClock.Model;

namespace Schuub.DesktopAlarmClock.Model.Tests
{
  public class DayOfWeekScheduledAlarmTests
  {
    [Test]
    public void GetDurationToNextAlarm_WhenSameDayLaterThanNow_ThenNextAlarmIsInMoments()
    {
      var alarm = new DayOfWeekScheduledAlarm { Day = DayOfWeek.Tuesday }
      {
      }
    }
    
    [Test]
    public void GetDurationToNextAlarm_WhenSameDayEarlierThanNow_ThenNextAlarmIsNextWeek()
    {
        Assert.Pass();
    }
  }
}