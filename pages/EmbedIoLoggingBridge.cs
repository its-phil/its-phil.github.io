internal class EmbedIoLoggingBridge : Swan.Logging.ILogger

internal class EmbedIoLoggingBridge : Swan.Logging.ILogger
{
  private readonly ILogger _log;

  public EmbedIoLoggingBridge(string namespaze, ILoggerFactory loggerFactory)
  {
    _log = loggerFactory.CreateLogger(namespaze);
  }

  public Swan.Logging.LogLevel LogLevel => Swan.Logging.LogLevel.Trace;

  public void Dispose()
  {
    // Nothing to do
  }

  public void Log(Swan.Logging.LogMessageReceivedEventArgs logEvent)
  {
    switch (logEvent.MessageType)
    {
      case Swan.Logging.LogLevel.Debug: _log.LogDebug(logEvent.Message); break;
      case Swan.Logging.LogLevel.Error: _log.LogError(logEvent.Exception, logEvent.Message); break;
      case Swan.Logging.LogLevel.Fatal: _log.LogCritical(logEvent.Exception, logEvent.Message); break;
      case Swan.Logging.LogLevel.Info: _log.LogInformation(logEvent.Message); break;
      case Swan.Logging.LogLevel.None: _log.LogDebug(logEvent.Message); break;
      case Swan.Logging.LogLevel.Trace: _log.LogTrace(logEvent.Message); break;
      case Swan.Logging.LogLevel.Warning: _log.LogWarning(logEvent.Message); break;
      default: _log.LogError($"Cannot bridge log message because log level {logEvent.MessageType} is unknown"); break;
    }
  }
}