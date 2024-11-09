namespace Schuub.HotelTransylvaniaAlarm
{
  public interface IScheduledAlarm
  {
    TimeSpan? GetDurationToNextAlarm(DateTimeOffset now);
  }
}
