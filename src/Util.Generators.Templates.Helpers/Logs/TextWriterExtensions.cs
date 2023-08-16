using System;

namespace Util.Generators.Helpers.Logs; 

/// <summary>
/// 来源： Microsoft.Extensions.Logging.Console/src/SimpleConsoleFormatter.cs
/// </summary>
public static class TextWriterExtensions {
    public static void WriteColoredMessage( this TextWriter textWriter, string message, ConsoleColor? background, ConsoleColor? foreground ) {
        if ( background.HasValue ) {
            textWriter.Write( AnsiParser.GetBackgroundColorEscapeCode( background.Value ) );
        }
        if ( foreground.HasValue ) {
            textWriter.Write( AnsiParser.GetForegroundColorEscapeCode( foreground.Value ) );
        }
        textWriter.Write( message );
        if ( foreground.HasValue ) {
            textWriter.Write( AnsiParser.DefaultForegroundColor ); // reset to default foreground color
        }
        if ( background.HasValue ) {
            textWriter.Write( AnsiParser.DefaultBackgroundColor ); // reset to the background color
        }
    }
}