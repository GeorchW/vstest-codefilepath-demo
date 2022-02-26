using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

[FriendlyName("MyLogger")]
[ExtensionUri("some://uri/notsurewhatssupposedtogohere")]
public class MyLogger : ITestLogger
{
    public void Initialize(TestLoggerEvents events, string testRunDirectory)
    {
        StreamWriter writer = new StreamWriter("./output.txt");
        writer.AutoFlush = true;

        events.DiscoveredTests += (sender, e) =>
        {
            foreach (var testCase in e.DiscoveredTestCases)
            {
                writer.WriteLine($"FullyQualifiedName: {testCase.FullyQualifiedName}");
                writer.WriteLine($"Location: {testCase.CodeFilePath ?? "<null>"}:{testCase.LineNumber}");
                writer.WriteLine();
            }
        };
    }
}
