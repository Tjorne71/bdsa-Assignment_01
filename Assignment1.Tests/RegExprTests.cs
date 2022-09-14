using Xunit;
namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_With_One_Line() { 
        List<string> lines = new List<string>{"Hello, world!"};
        var regex = RegExpr.SplitLine(lines);
        Assert.Equal(new List<string>(){"Hello", "world"}, regex);
    }
    [Fact]
    public void SplitLine_With_More_Lines() { 
        List<string> lines = new List<string>{"Hello, world!", "yellow, blue!"};
        var regex = RegExpr.SplitLine(lines);
        Assert.Equal(new List<string>(){"Hello", "world", "yellow", "blue"}, regex);
    }
    
    [Fact]
    public void Resolution_Separated_String() { 
        string resolution = "1920x1080";
        var results = RegExpr.Resolution(resolution);
        foreach (var result in results) {
            Assert.Equal((1920, 1080), result);
        }
    }

    [Fact]
    public void Resolution_From_Comma_Separated_String() { 
        string resolution = "1024x768, 800x600, 640x480";
        var results = RegExpr.Resolution(resolution);
        Assert.Equal(new List<(int, int)>(){(1024, 768), (800, 600), (640, 480)}, results);
    }

    [Fact]
    public void Inner_Text_Of_Html_Tag_With_One_Result() { 
        string html = "<p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>";
        var results = RegExpr.InnerText(html, "p");
        Assert.Equal(new List<string>(){"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."}, results);
    }
    [Fact]
    public void Inner_Text_Of_Html_Tag_With_Several_Results() { 
        string html = $"<h3>Frequently asked questions</h3> <h2>Allgemeines</h2> <h3>Was sind die Kommunikationskanäle für die Übungen?</h3> <p>Allgemeine Fragen gehören in die Newsgroup, da wir sie da für alle Übungsteilnehmer gleichermaßen beantworten können. </p>";
        var results = RegExpr.InnerText(html, "h3");
        Console.WriteLine(results);
        Assert.Equal(new List<string>(){"Frequently asked questions","Was sind die Kommunikationskanäle für die Übungen?"}, results);
    }

    [Fact]
    public void Inner_Text_Of_Html_Tag_With_One_Result_And_Nested_Tags() { 
        string html = @"<div>
                            <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
                        </div>";
        var results = RegExpr.InnerText(html, "p");
        Console.WriteLine(results);
        Assert.Equal(new List<string>(){"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."}, results);
    }

    [Fact]
    public void UrlWithTitle() { 
        string html = $"<a href='/wiki/Biker-Jens' title='Biker-Jens'>Jens Romundstad</a>";
        var results = RegExpr.Url(html);
        foreach (var result in results) {
            Console.WriteLine(result);
        }
        Assert.Equal(new List<string>(){"biker-jens"}, results);
    }

    [Fact]
    public void UrlWithoutTitle() { 
        string html = $"<a href='/wiki/Biker-Jens'>Jens Romundstad</a>";
        var results = RegExpr.Url(html);
        Assert.Equal(new List<string>(){"jens romundstad"}, results);
    }

    [Fact]
    public void UrlWithMultipleAnchors() { 
        string html = @"<div>
                            <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='https://en.wikipedia.org/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='https://en.wikipedia.org/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='https://en.wikipedia.org/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='https://en.wikipedia.org/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='https://en.wikipedia.org/wiki/String_searching_algorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='https://en.wikipedia.org/wiki/String_(computer_science)'>strings</a>.</p>
                        </div>";
        var results = RegExpr.Url(html);
        Assert.Equal(new List<string>(){"theoretical computer science", "formal language", "character (computing)", "pattern matching", "string searching algorithm", "strings"}, results);
    }


}