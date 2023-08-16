using System;

namespace Util.Generators.Helpers.Logs; 

/// <summary>
/// 来源： Microsoft.Extensions.Logging.Console/src/SimpleConsoleFormatter.cs
/// </summary>
public static class ConsoleUtils {
    private static volatile int s_emitAnsiColorCodes = -1;
    public static bool EmitAnsiColorCodes {
        get {
            int emitAnsiColorCodes = s_emitAnsiColorCodes;
            if ( emitAnsiColorCodes != -1 ) {
                return Convert.ToBoolean( emitAnsiColorCodes );
            }
            bool enabled = !Console.IsOutputRedirected;
            if ( enabled ) {
                enabled = Environment.GetEnvironmentVariable( "NO_COLOR" ) is null;
            }
            else {
                string? envVar = Environment.GetEnvironmentVariable( "DOTNET_SYSTEM_CONSOLE_ALLOW_ANSI_COLOR_REDIRECTION" );
                enabled = envVar is not null && ( envVar == "1" || envVar.Equals( "true", StringComparison.OrdinalIgnoreCase ) );
            }
            s_emitAnsiColorCodes = Convert.ToInt32( enabled );
            return enabled;
        }
    }
}