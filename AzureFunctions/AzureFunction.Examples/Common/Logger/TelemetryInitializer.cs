using System.Diagnostics.CodeAnalysis;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;

namespace Common.Logger;

/// <summary>
/// Represents an object that initializes <see cref="ITelemetry"/> objects.
/// </summary>
[ExcludeFromCodeCoverage]
public class TelemetryInitializer : ITelemetryInitializer
{
    private const string ApplicationNameSetting = "ApplicationName";
    private const string ApplicationNameProperty = "ApplicationName";

    private readonly IConfiguration _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="TelemetryInitializer"/> class.
    /// </summary>
    /// <param name="config">Represents a set of key/value application configuration properties.</param>
    public TelemetryInitializer(IConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Adds custom application name custom property into telemetry event.
    /// </summary>
    /// <param name="telemetry">An instacne of <see cref="ITelemetry"/> object.</param>
    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry is ISupportProperties itemProperties
            && !itemProperties.Properties.ContainsKey(ApplicationNameProperty))
        {
            itemProperties.Properties[ApplicationNameProperty] = _config[ApplicationNameSetting];
        }
    }
}