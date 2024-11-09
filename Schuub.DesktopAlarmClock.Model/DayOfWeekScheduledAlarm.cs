using System;

namespace Schuub.HotelTransylvaniaAlarm
{
  public class DayOfWeekScheduledAlarm : IScheduledAlarm
  {
    public DayOfWeek Day { get; set; }
    
    public TimeSpan Time { get; set; }

    public TimeSpan? GetDurationToNextAlarm(DateTimeOffset now)
    {
      // DayOfWeek.Sunday == 0;
      // Find the most recently passed Sunday morning
      var sundayMorning = now
        .Subtract(TimeSpan.FromDays((int)now.DayOfWeek))
        .Subtract(now.TimeOfDay);

      // Assume this alarm is always for the same time zone as 'now'
      var alarmTime = sundayMorning
        .Add(TimeSpan.FromDays((int)Day))
        .Add(Time);
        
      // don't live in the past
      if (alarmTime < now)
      {
        alarmTime = alarmTime.Add(TimeSpan.FromDays(7));
      }
      
      return alarmTime;
    }
  }
}
