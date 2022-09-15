using System.Text.RegularExpressions;
namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) {
            var pattern = @"\w+";
            foreach (var line in lines) {
                foreach (var match in Regex.Matches(line, pattern: pattern)) {
                    yield return match.ToString();
                }
            }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) {
        string pattern = @"(?<reso_one>\d{3,4})x(?<reso_two>\d{3,4})";
        Regex regex = new Regex(pattern);
        foreach (Match match in regex.Matches(resolutions)) {
            yield return (Int32.Parse(match.Groups[1].Value), Int32.Parse(match.Groups[2].Value));
        }
    }
    
    public static IEnumerable<string> InnerText(string html, string tag) {
        tag = tag.ToLower();
        var pattern = $"<({tag}).*?>(?<inner>.*?)</\\1>";
        foreach (Match match in Regex.Matches(html, pattern: pattern)) {
            var innerText = match.Groups["inner"].Value.Trim();
            innerText = Regex.Replace(innerText,"(</?\\w*>)*","");
            yield return innerText;
        }

    }

    public static IEnumerable<string> Url(string html) {
        var pattern = "<a.*?(title=[\"'](?<title>.*?)[\"'])?>(?<inner>.*?)<\\/a>";
        foreach (Match match in Regex.Matches(html, pattern: pattern)) {
            var title = match.Groups["title"].Value.Trim().ToLower();
            var inner = match.Groups["inner"].Value.Trim().ToLower();
            if(title != String.Empty) 
                yield return title;
            else 
                yield return inner;
           
        }

    }

}