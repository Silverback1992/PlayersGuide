using PlayersGuide.Notes.SubNotes.DateHelpers;
using System.Diagnostics;

namespace PlayersGuide.Notes.SubNotes;

public static class Date
{
    public static void Show()
    {
        Console.WriteLine("Date and Time:");

        // DateTime - DateTime = TimeSpan
        var myTimeSpan = new DateTime(2024, 1, 1) - new DateTime(2023, 1, 1);
        // DateTime + TimeSpan = DateTime
        var myDateTime = new DateTime(2024, 1, 1) + myTimeSpan;

        // DateOnly - date of birth
        var dob = new DateOnly(1990, 5, 15);

        // TimeOnly - store's daily opening and closing times
        TimeOnly opens = new(9, 0), closes = new(17, 30);
        var now = TimeOnly.FromDateTime(DateTime.Now);
        Console.WriteLine($"Is store open: {now.IsBetween(opens, closes)}");

        // TimeSpan - a request timeout / cache lifetime
        var httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromSeconds(30);

        // measuring elapsed time
        var sw = Stopwatch.StartNew();
        MyWorker.DoWork();
        var elapsed = sw.Elapsed;
        Console.WriteLine($"Elapsed time: {elapsed}");

        // DateTime
        var oder = new Order()
        {
            CreatedAtUtc = DateTime.UtcNow
        };
        // save to db..
        DateTime local = oder.CreatedAtUtc.ToLocalTime();
        // convert only at display

        // DateTimeOffset
        // Same instant, two places on Earth:
        DateTimeOffset utc = new(2024, 6, 1, 12, 0, 0, TimeSpan.Zero);      // 12:00 +00:00
        DateTimeOffset budapest = new(2024, 6, 1, 14, 0, 0, TimeSpan.FromHours(2)); // 14:00 +02:00

        Console.WriteLine(utc == budapest);   // True  ← same MOMENT in time

        var logEntry = new LogEntry()
        {
            Timestamp = DateTimeOffset.Now
        };

        DateTime asUtc = logEntry.Timestamp.UtcDateTime;

        // TimeZoneInfo
        var bp = TimeZoneInfo.FindSystemTimeZoneById("Europe/Budapest");
        DateTime localMeeting = new(2024, 7, 15, 9, 0, 0);
        DateTime utcToStore = TimeZoneInfo.ConvertTimeToUtc(localMeeting, bp);
        Console.WriteLine($"UTC time at store: {utcToStore}");
    }
}
