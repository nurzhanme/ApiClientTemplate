using Microsoft.Extensions.Logging;

namespace ApiClientTemplate.Handlers;

public class ExceptionHandler : DelegatingHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            return base.SendAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }
}