namespace Maui.Apps.Framework.Extensions;

public static class DateExtensions
{
    public static string ToTimeAgo(this DateTime baseTime)
    {
        var _timeSpan = DateTime.Now - baseTime;

        if (_timeSpan.TotalMinutes == 0)
            return "Just now";

        if (_timeSpan.TotalMinutes < 60)
            return Convert.ToInt32(_timeSpan.TotalMinutes).ToString() + " mins ago";

        if (_timeSpan.TotalHours < 2)
            return Convert.ToInt32(_timeSpan.TotalHours).ToString() + " hour ago";

        if (_timeSpan.TotalHours < 24)
            return Convert.ToInt32(_timeSpan.TotalHours).ToString() + " hours ago";

        if (_timeSpan.TotalDays < 2)
            return Convert.ToInt32(_timeSpan.TotalDays).ToString() + " day ago";

        if (_timeSpan.TotalDays < 365)
            return Convert.ToInt32(_timeSpan.TotalDays).ToString() + " days ago";

        if (Convert.ToDouble(_timeSpan.TotalDays / 365) < 2)
            return "1 year ago";

        return Convert.ToDouble(_timeSpan.TotalDays / 365).ToString("#") + " years ago";
    }

    public static string ToReadableString(this TimeSpan span) =>
        string.Format("{0}{1}{2}{3}",
            span.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", span.Days, span.Days == 1 ? string.Empty : "s") : string.Empty,
            span.Duration().Hours > 0 ? string.Format("{0:0} hr{1}, ", span.Hours, span.Hours == 1 ? string.Empty : "s") : string.Empty,
            span.Duration().Minutes > 0 ? string.Format("{0:0} min{1}, ", span.Minutes, span.Minutes == 1 ? string.Empty : "s") : string.Empty,
            span.Duration().Seconds > 0 ? string.Format("{0:0} sec{1}", span.Seconds, span.Seconds == 1 ? string.Empty : "s") : string.Empty);

    public static TimeSpan ToTimeSpan(this string isoDuration) =>
        System.Xml.XmlConvert.ToTimeSpan(isoDuration);
}


