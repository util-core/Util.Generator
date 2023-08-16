using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;

namespace Util.Generators.Helpers.Logs; 

/// <summary>
/// 来源： Microsoft.Extensions.Logging.Console/src/SimpleConsoleFormatter.cs
/// 修改为自定义格式输出
/// </summary>
public class LogFormatter : ConsoleFormatter, IDisposable {
    private const string LoglevelPadding = ": ";
    private static readonly string _messagePadding = new( ' ', 4 );
    private static readonly string _newLineWithMessagePadding = Environment.NewLine + _messagePadding;

    private readonly IDisposable? _optionsReloadToken;

    public LogFormatter( IOptionsMonitor<SimpleConsoleFormatterOptions> options )
        : base( "default" ) {
        ReloadLoggerOptions( options.CurrentValue );
        _optionsReloadToken = options.OnChange( ReloadLoggerOptions );
    }

    [MemberNotNull( nameof( FormatterOptions ) )]
    private void ReloadLoggerOptions( SimpleConsoleFormatterOptions options ) {
        FormatterOptions = options;
    }

    public void Dispose() {
        _optionsReloadToken?.Dispose();
    }

    internal SimpleConsoleFormatterOptions FormatterOptions { get; set; }

    public override void Write<TState>( in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider, TextWriter textWriter ) {
        string message = logEntry.Formatter( logEntry.State, logEntry.Exception );
        if ( logEntry.Exception == null && message == null ) {
            return;
        }
        LogLevel logLevel = logEntry.LogLevel;
        ConsoleColors logLevelColors = GetLogLevelConsoleColors( logLevel );
        string logLevelString = GetLogLevelString( logLevel );

        string? timestamp = null;
        string? timestampFormat = FormatterOptions.TimestampFormat;
        if ( timestampFormat != null ) {
            DateTimeOffset dateTimeOffset = GetCurrentDateTime();
            timestamp = dateTimeOffset.ToString( timestampFormat );
        }
        if ( timestamp != null ) {
            textWriter.Write( timestamp );
        }
        if ( logLevelString != null ) {
            textWriter.WriteColoredMessage( logLevelString, logLevelColors.Background, logLevelColors.Foreground );
            textWriter.Write( LoglevelPadding );
        }
        CreateDefaultLogMessage( textWriter, logEntry, message );
    }

    private void CreateDefaultLogMessage<TState>( TextWriter textWriter, in LogEntry<TState> logEntry, string message ) {
        Exception? exception = logEntry.Exception;
        WriteMessage( textWriter, message );
        if ( exception != null ) {
            WriteMessage( textWriter, exception.ToString() );
        }
    }

    private static void WriteMessage( TextWriter textWriter, string message ) {
        if ( !string.IsNullOrEmpty( message ) ) {
            WriteReplacing( textWriter, Environment.NewLine, _newLineWithMessagePadding, message );
            textWriter.Write( Environment.NewLine );
        }
        static void WriteReplacing( TextWriter writer, string oldValue, string newValue, string message ) {
            string newMessage = message.Replace( oldValue, newValue );
            writer.Write( newMessage );
        }
    }

    private DateTimeOffset GetCurrentDateTime() {
        return FormatterOptions.UseUtcTimestamp ? DateTimeOffset.UtcNow : DateTimeOffset.Now;
    }

    private static string GetLogLevelString( LogLevel logLevel ) {
        return logLevel switch {
            LogLevel.Trace => "trace",
            LogLevel.Debug => "debug",
            LogLevel.Information => "info",
            LogLevel.Warning => "warn",
            LogLevel.Error => "error",
            LogLevel.Critical => "critical",
            _ => throw new ArgumentOutOfRangeException( nameof( logLevel ) )
        };
    }

    private ConsoleColors GetLogLevelConsoleColors( LogLevel logLevel ) {
        bool disableColors = ( FormatterOptions.ColorBehavior == LoggerColorBehavior.Disabled ) ||
                             ( FormatterOptions.ColorBehavior == LoggerColorBehavior.Default && ( !ConsoleUtils.EmitAnsiColorCodes ) );
        if ( disableColors ) {
            return new ConsoleColors( null, null );
        }
        return logLevel switch {
            LogLevel.Trace => new ConsoleColors( ConsoleColor.Gray, ConsoleColor.Black ),
            LogLevel.Debug => new ConsoleColors( ConsoleColor.Gray, ConsoleColor.Black ),
            LogLevel.Information => new ConsoleColors( ConsoleColor.DarkGreen, ConsoleColor.Black ),
            LogLevel.Warning => new ConsoleColors( ConsoleColor.Yellow, ConsoleColor.Black ),
            LogLevel.Error => new ConsoleColors( ConsoleColor.Black, ConsoleColor.DarkRed ),
            LogLevel.Critical => new ConsoleColors( ConsoleColor.White, ConsoleColor.DarkRed ),
            _ => new ConsoleColors( null, null )
        };
    }

    private readonly struct ConsoleColors {
        public ConsoleColors( ConsoleColor? foreground, ConsoleColor? background ) {
            Foreground = foreground;
            Background = background;
        }
        public ConsoleColor? Foreground { get; }
        public ConsoleColor? Background { get; }
    }
}