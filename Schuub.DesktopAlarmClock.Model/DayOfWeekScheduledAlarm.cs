// This is free and unencumbered software released into the public domain under The Unlicense.
// You have complete freedom to do anything you want with the software, for any purpose.
// Please refer to <http://unlicense.org/>

using System;

namespace Schuub.DesktopAlarmClock.Model
{
  /// <summary>
  /// An alarm that rings at a particular day of the week and time of the day.
  /// </summary>
  public class DayOfWeekScheduledAlarm : IScheduledAlarm
  {
    public DayOfWeek Day { get; set; }
    
    public TimeSpan TimeOfDay { get; set; }

    public DateTimeOffset? GetNextAlarmTime(DateTimeOffset now)
    {
      // DayOfWeek.Sunday == 0;
      // Find the most recent Sunday morning 12:00am
      var sundayMorning = now
        .Subtract(TimeSpan.FromDays((int)now.DayOfWeek))
        .Subtract(now.TimeOfDay);

      // Assume this alarm is always for the same time zone as 'now'
      var alarmTime = sundayMorning
        .Add(TimeSpan.FromDays((int)Day))
        .Add(TimeOfDay);
        
      // don't live in the past
      if (alarmTime < now)
      {
        alarmTime = alarmTime.Add(TimeSpan.FromDays(7));
      }
      
      return alarmTime;
    }
  }
}
