using Discord;

namespace Catalyst.Common;

public class Logger
{
    public static async Task Log(LogSeverity severity, string source, string message, Exception? exception = null)
    {
        await Log(new LogMessage(severity, source, message, exception));
    }
    
    public static Task Log(LogMessage message)
    {
        switch (message.Severity)
        {
            case LogSeverity.Critical:
            case LogSeverity.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogSeverity.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case LogSeverity.Info:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case LogSeverity.Verbose:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case LogSeverity.Debug:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
        }
        Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} [{message.Severity}] {message.Source}: {message.Message} {message.Exception}");
        Console.ResetColor();
        
        // If you get an error saying 'CompletedTask' doesn't exist,
        // your project is targeting .NET 4.5.2 or lower. You'll need
        // to adjust your project's target framework to 4.6 or higher
        // (instructions for this are easily Googled).
        // If you *need* to run on .NET 4.5 for compat/other reasons,
        // the alternative is to 'return Task.Delay(0);' instead.
        return Task.CompletedTask;
    }
}
