using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ApiClientTemplate.Handlers;

public class LoggingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;
    private readonly Stopwatch _stopwatch = new();

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Sending request to {request.RequestUri}");
        _stopwatch.Start();

        var response = base.SendAsync(request, cancellationToken);
        
        _stopwatch.Stop();
        _logger.LogInformation($"Request to {request.RequestUri} completed in {_stopwatch.ElapsedMilliseconds} ms");
        _stopwatch.Reset();

        return response;
    }
}