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
        var pattern = @"((?<width>[0-9]{1,4})x(?<height>[0-9]{1,4}))";
        foreach (Match match in Regex.Matches(resolutions, pattern: pattern)) {
            var width = int.Parse(match.Groups["width"].Value.Trim());
            var height = int.Parse(match.Groups["height"].Value.Trim());
            yield return (width, height);
        }
    }
    
    public static IEnumerable<string> InnerText(string html, string tag) {
        var pattern = $"(<{tag}>(?<inner>.*?)<\\/{tag}>)";
        foreach (Match match in Regex.Matches(html, pattern: pattern)) {
            var innerText = match.Groups["inner"].Value.Trim();
            innerText = Regex.Replace(innerText,"(</?\\w*>)*","");
            yield return innerText;
        }

    }

    public static IEnumerable<string> Url(string html) {
        var pattern = $"<a.*?(title=[\"'](?<title>.*?)[\"'])?>(?<inner>.*?)<\\/a>";
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