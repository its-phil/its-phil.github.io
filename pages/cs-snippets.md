---
layout: post
title:  "C# Snippets"
date:   2023-08-20 17:17:14 +0200
categories: dotnet C#
---
===

Chunks of code I use in many of my C# projects.

## Logging Configuration with Microsoft's Logging Framework

```cs
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
  builder.AddFilter("Microsoft", LogLevel.Warning)
         .AddFilter("System", LogLevel.Warning)
         .SetMinimumLevel(LogLevel.Debug)
         .AddSimpleConsole(options => 
         {
           options.IncludeScopes = true;
           options.SingleLine = true;
           options.TimestampFormat = "HH:mm:ss ";
         });
});
```

## Overwrite EmbedIO's Logger

```cs
try 
{
  Swan.Logging.Logger.UnregisterLogger<Swan.Logging.ConsoleLogger>();
}
catch {}
Swan.Logging.Logger.RegisterLogger(new EmbedIoLoggingBridge(nameof(SomeClass), loggerFactory));
```
[EmbedIoLoggingBridge](EmbedIoLoggingBridge.cs)
