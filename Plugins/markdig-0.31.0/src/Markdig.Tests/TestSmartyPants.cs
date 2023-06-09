using Markdig.Extensions.SmartyPants;

namespace Markdig.Tests;

public class TestSmartyPants
{
    [Test]
    public void MappingCanBeReconfigured()
    {
        var options = new SmartyPantOptions();
        options.Mapping[SmartyPantType.LeftAngleQuote] = "foo";
        options.Mapping[SmartyPantType.RightAngleQuote] = "bar";

        var pipeline = new MarkdownPipelineBuilder()
            .UseSmartyPants(options)
            .Build();

        TestParser.TestSpec("<<test>>", "<p>footestbar</p>", pipeline);
    }

    [Test]
    public void MappingCanBeReconfigured_HandlesRemovedMappings()
    {
        var options = new SmartyPantOptions();
        options.Mapping.Remove(SmartyPantType.LeftAngleQuote);
        options.Mapping.Remove(SmartyPantType.RightAngleQuote);

        var pipeline = new MarkdownPipelineBuilder()
            .UseSmartyPants(options)
            .Build();

        TestParser.TestSpec("<<test>>", "<p>&laquo;test&raquo;</p>", pipeline);
    }
}
