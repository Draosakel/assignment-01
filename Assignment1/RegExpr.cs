using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            foreach (var word in Iterators.Filter(Regex.Split(line, @"[^a-zA-Z0-9]+"), s => s.Length != 0))
            {
                yield return word;
            } 
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        foreach (var item in resolutions)
        {
            foreach (Match match in Regex.Matches(item, @"(\d+)x(\d+)"))
            {
                yield return (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
            }
        }
    }

    private static string InnerTextSingle(string html, string tag)
    {
        return Regex.Replace(html, @$"(<({tag})[^>]*>)([^<]*)(<\/\2>)", m => m.Groups[3].Value);
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        foreach (Match match in Regex.Matches(html, @$"<{tag}[\S\s]*?>(.*?)<\/{tag}>"))
        {
            yield return InnerTextSingle(match.Groups[1].Value, @$"(?!{tag})\w+");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        foreach (Match match in Regex.Matches(html, @"<a(title=""(?<title>.*?)""|href=""(?<href>.*?)""|[\S\s])*?>(?<inner>.*?)<\/a>"))
        {
            var uri = new Uri(match.Groups["href"].Value);
            if (match.Groups["title"].Success)
            {
                yield return (uri, match.Groups["title"].Value);
            } else
            {
                yield return (uri, InnerTextSingle(match.Groups[0].Value, "a"));
            }
        }
    }
}
