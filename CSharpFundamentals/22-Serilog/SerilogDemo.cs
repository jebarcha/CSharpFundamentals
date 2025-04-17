using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Formatting;
using System.IO;
using Serilog.Exceptions;
using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text.Json;

namespace CSharpFundamentals._22_Serilog;
public static class SerilogDemo
{
    public static void Demo()
    {
        var logger = Log.Logger = new LoggerConfiguration()
          .Enrich.WithExceptionDetails()
          .Enrich.WithProperty("App", "MyApp")
          .Enrich.WithProperty("Env", "Prod")
          .WriteTo.File(
            new CustomJsonFormatter(),
            //new FlattenedJsonFormatter(), 
            //new JsonFormatter(),
            @"C:\Logs\Demo.txt"
        ).CreateLogger();
        
        Log.Information("This is a test Info log", "moduloDemo");

        //Log.Warning("This is a test Warning log", "moduloDemo");

        //Log.Fatal("This is a test Fatal log", "moduloDemo");

        //try
        //{
        //    throw new InvalidOperationException("This is a test exception");
        //}
        //catch (Exception ex)
        //{
        //    logger.ForContext("Module", "moduleDemoDesc")
        //        .ForContext("StackTrace", ex.StackTrace)
        //        .Debug(ex, "Exception occurred");

        //    Log.Error(ex, "An error occurred while processing the operation");
        //}
    }
}


public class CustomJsonFormatter : ITextFormatter
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = null , //JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = false
    };

    public void Format(LogEvent logEvent, TextWriter output)
    {
        var auditLog = CreateAuditLog(logEvent);

        var logObject = new Dictionary<string, object>
        {
            ["Timestamp"] = logEvent.Timestamp.ToString("o"),
            ["Level"] = logEvent.Level.ToString(),
            ["MessageTemplate"] = logEvent.MessageTemplate.Text,
            ["RenderedMessage"] = logEvent.RenderMessage(),
            ["AuditLog"] = auditLog
        };

        var json = JsonSerializer.Serialize(logObject, _jsonOptions);
        output.WriteLine(json);
    }

 

    private AuditLogEvent CreateAuditLog(LogEvent logEvent)
    {
        var auditLog = new AuditLogEvent
        {
            Topic = "event_stream2",
            Environment = "test",
            EventType = "data-manager-demo",
            EventId = null,
            Origin = "data-manager2",
            EventTypeVersion = 2,
            Data = logEvent.Properties.ToDictionary(p => p.Key, p => SimplifyData(p.Value))
        };

        AddExceptionToAuditLog(logEvent, auditLog);
        
        return auditLog;
    }

    private void AddExceptionToAuditLog(LogEvent logEvent, AuditLogEvent auditLog)
    {
        if (logEvent.Exception is null) return;

        var exception = new Dictionary<string, object>
        {
            ["ExceptionMessage"] = logEvent.Exception.Message,
            ["ExceptionType"] = logEvent.Exception.GetType().FullName,
            ["StackTrace"] = logEvent.Exception.StackTrace
        };
        auditLog.Data["Exception"] = exception;
    }

    private object SimplifyData(LogEventPropertyValue value)
    {
        // Extract and transform the structured data from log events into a more basic, serializable format
        switch (value)
        {
            case ScalarValue scalar:
                return scalar.Value;
            case SequenceValue sequence:
                return sequence.Elements.Select(SimplifyData).ToArray();
            case StructureValue structure:
                return structure.Properties.ToDictionary(p => p.Name, p => SimplifyData(p.Value));
            case DictionaryValue dict:
                return dict.Elements.ToDictionary(
                    e => e.Key.Value?.ToString() ?? "",
                    e => SimplifyData(e.Value)
                );
            default:
                return value.ToString();
        }
    }
}


//public class FlattenedJsonFormatter : ITextFormatter
//{
//    private readonly JsonValueFormatter _valueFormatter = new JsonValueFormatter(typeTagName: null);

//    public void Format(LogEvent logEvent, TextWriter output)
//    {
//        output.Write("{");

//        // Core fields
//        output.Write($"\"Timestamp\":\"{logEvent.Timestamp:O}\",");
//        output.Write($"\"Level\":\"{logEvent.Level}\",");
//        output.Write("\"MessageTemplate\":");
//        JsonValueFormatter.WriteQuotedJsonString(logEvent.MessageTemplate.Text, output);
//        output.Write(",");

//        output.Write("\"RenderedMessage\":");
//        JsonValueFormatter.WriteQuotedJsonString(logEvent.RenderMessage(), output);

//        // Exception block
//        if (logEvent.Exception != null)
//        {
//            output.Write(",");

//            output.Write("\"Exception\":");
//            JsonValueFormatter.WriteQuotedJsonString(logEvent.Exception.ToString(), output);

//            output.Write(",");

//            output.Write("\"ExceptionType\":");
//            JsonValueFormatter.WriteQuotedJsonString(logEvent.Exception.GetType().FullName, output);
//        }

//        // Flatten all properties
//        foreach (var prop in logEvent.Properties)
//        {
//            output.Write(",");
//            JsonValueFormatter.WriteQuotedJsonString(prop.Key, output);
//            output.Write(":");
//            _valueFormatter.Format(prop.Value, output);
//        }

//        output.Write("}");
//        output.WriteLine();
//    }
//}

public class AuditLogEvent
{
    public string EventType { get; set; } = "data-manager_"; // replace with dynamic value or settings value. "data-manager_(create|update|delete|error)"

    public Guid? EventId { get; set; } // The UUID of the event that caused the log

    public string Origin { get; set; } = "data-manager"; // "(RRS|DM_Consumer)"

    //public string Destination { get; set; }

    public Dictionary<string, object> Data { get; set; } // {<metadata related to type>}

    public Guid MessageId { get; set; } = new Guid(); // A unique Guid generated for each audit log

    public long Timestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // <milliseconds_since_epoch>

    public string Environment { get; set; } = "dev"; // dynamic "dev" | "staging" | "prod"

    public int EventTypeVersion { get; set; } = 1; // Represent changes to 'data' based on event type as those evolve

    public string Topic { get; set; } = "event_stream"; // from settings or constant
}
