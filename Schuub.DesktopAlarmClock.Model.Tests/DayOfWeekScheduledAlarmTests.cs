// This is free and unencumbered software released into the public domain under The Unlicense.
// You have complete freedom to do anything you want with the software, for any purpose.
// Please refer to <http://unlicense.org/>

using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;

namespace Schuub.DesktopAlarmClock.Model.Tests
{
  public class DayOfWeekScheduledAlarmTests
  {
    [Test]
    public void GivenItIsBedTime_WhenISetAlarmForTomorrowMorning_ThenItWouldRingTomorrowMorning()
    {
      for (int i = 1; i <= 30; i++)
      {
        // ask at 10:00pm in the evening
        DateTimeOffset start = DateTimeOffset.Parse(
          $"2024-11-{i:D2}T22:00:00+08:00", CultureInfo.InvariantCulture);

        // set alarm for 8:00am next morning
        DateTimeOffset alarmTime = start.AddHours(10);
        var alarm = new DayOfWeekScheduledAlarm
        {
          Day = alarmTime.DayOfWeek,
          TimeOfDay = TimeSpan.FromHours(8),
        };

        // verify that every minute up to that alarm time says the alarm time is the alarm time
        for (var now = start; now < alarmTime; now = now.AddMinutes(1))
        {
          var result = alarm.GetNextAlarmTime(now);
          if (result != alarmTime)
          {
            Assert.That(result, Is.EqualTo(alarmTime), $"When asking at {now} " +
              $"about my alarm set with i={i} for {alarmTime}");
          }
        }
      }
    }

    [Test]
    public void FromVariousTimesDuringTheMonth_WhenISetAlarmForVariousTimesInTheNextWeek_ThenAlarmWillRingWhenTold()
    {
      const int minutesInOneWeek = 60 * 24 * 7;

      Random random = new Random(1337);
      for (int askingDay = 1; askingDay <= 30; askingDay++)
      {
        // ask at five random hours on that day
        foreach (int askingHour in Enumerable.Range(0, 5).Select(x => random.Next(0, 24)))
        {
          // ask at four random minutes on that day
          foreach (int askingMinute in Enumerable.Range(0, 4).Select(x => random.Next(0, 60)))
          {
            DateTimeOffset start = new DateTimeOffset(2024, 11, askingDay, askingHour, askingMinute, 0, TimeSpan.FromHours(8));

            // ask about random alarm times in the next week
            for (int minutesInFuture = 0; minutesInFuture < minutesInOneWeek; minutesInFuture += random.Next(15, 100))
            {
              DateTimeOffset alarmTime = start.AddMinutes(minutesInFuture);
              var alarm = new DayOfWeekScheduledAlarm
              {
                Day = alarmTime.DayOfWeek,
                TimeOfDay = alarmTime.TimeOfDay,
              };

              // verify for random points between 'start' and 'alarmTime'
              // that the alarm will go off at the desired alarm time
              for (var now = start; now < alarmTime; 
                now = now.AddMinutes(random.Next(1, Math.Max(2, Math.Min(100, 
                  (int)(alarmTime - now).TotalMinutes)))))
              {
                var result = alarm.GetNextAlarmTime(now);
                if (result != alarmTime)
                {
                  Assert.That(result, Is.EqualTo(alarmTime), $"When asking at {now} about " +
                    $"my alarm set with i={askingDay} askingHour={askingHour} " +
                    $"askingMinute={askingMinute} minutesInFuture={minutesInFuture} " +
                    $"for {alarmTime}");
                }
              }
            }
          }
        }
      }
    }
  }
}