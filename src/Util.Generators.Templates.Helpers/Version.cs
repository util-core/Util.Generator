using Util.Helpers;

namespace Util.Generators.Helpers;

/// <summary>
/// 版本配置
/// </summary>
public static class Version {
    /// <summary>
    /// Util框架版本号
    /// </summary>
    public static string Util => "8.0.18";
    /// <summary>
    /// Microsoft.Extensions.Hosting版本号
    /// </summary>
    public static string Hosting => "8.0.0";
    /// <summary>
    /// Microsoft.AspNetCore.TestHost版本号
    /// </summary>
    public static string TestHost => "8.0.6";
    /// <summary>
    /// Microsoft.EntityFrameworkCore.Tools版本号
    /// </summary>
    public static string EntityFrameworkCoreTools => "8.0.6";
    /// <summary>
    /// Microsoft.EntityFrameworkCore.Design版本号
    /// </summary>
    public static string EntityFrameworkCoreDesign => "8.0.6";
    /// <summary>
    /// Microsoft.AspNetCore.Authentication.JwtBearer版本号
    /// </summary>
    public static string JwtBearer => "8.0.6";
    /// <summary>
    /// Microsoft.NET.Test.Sdk版本号
    /// </summary>
    public static string TestSdk => "17.10.0";
    /// <summary>
    /// xunit版本号
    /// </summary>
    public static string Xunit => "2.8.1";
    /// <summary>
    /// xunit.runner.visualstudio版本号
    /// </summary>
    public static string XunitRunner => "2.8.1";
    /// <summary>
    /// coverlet.collector版本号
    /// </summary>
    public static string Coverlet => "6.0.2";
    /// <summary>
    /// AutoBogus版本号
    /// </summary>
    public static string AutoBogus => "2.13.1";
    /// <summary>
    /// Moq版本号
    /// </summary>
    public static string Moq => "4.20.70";
    /// <summary>
    /// Xunit.DependencyInjection版本号
    /// </summary>
    public static string XunitDependencyInjection => "9.3.0";
    /// <summary>
    /// Xunit.DependencyInjection.Logging版本号
    /// </summary>
    public static string XunitLogging => "9.0.0";
    /// <summary>
    /// Swashbuckle.AspNetCore版本号
    /// </summary>
    public static string Swashbuckle => "6.6.2";
    /// <summary>
    /// Microsoft.TypeScript.MSBuild版本号
    /// </summary>
    public static string TypeScriptMsBuild => "5.4.4";

    /// <summary>
    /// 获取代码生成器版本号
    /// </summary>
    public static async Task<string> GetVersionAsync() {
        var path = GetVersionPath();
        var document = await Xml.LoadFileToDocumentAsync( path );
        var prefix = "Project/PropertyGroup";
        var major = document.XPathSelectElement( $"{prefix}/VersionMajor" )?.Value;
        var minor = document.XPathSelectElement( $"{prefix}/VersionMinor" )?.Value;
        var patch = document.XPathSelectElement( $"{prefix}/VersionPatch" )?.Value;
        return $"{major}.{minor}.{patch}";
    }

    /// <summary>
    /// 获取版本文件路径
    /// </summary>
    private static string GetVersionPath() {
        var parentPath = Common.GetParentDirectory( 5 );
        return $"{parentPath}/build/version.props";
    }
}