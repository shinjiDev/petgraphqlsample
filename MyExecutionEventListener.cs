using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using System.Text;

namespace DemoChoco
{
    public class MyExecutionEventListener : ExecutionDiagnosticEventListener
    {
        private readonly ILogger<MyExecutionEventListener> _logger;

        public MyExecutionEventListener(ILogger<MyExecutionEventListener> logger)
            => _logger = logger;

        public override IDisposable ExecuteRequest(IRequestContext context)
        {
            var start = DateTime.UtcNow;

            return new RequestScope(start, _logger, context);
        }

        public override void RequestError(IRequestContext context,
            Exception exception)
        {
            _logger.LogError(exception, "A request error occured!");
        }
    }

    public class RequestScope : IDisposable
    {
        private readonly ILogger _logger;
        private readonly DateTime _start;
        private readonly IRequestContext _context;

        public RequestScope(DateTime start, ILogger logger,
                     IRequestContext context)
        {
            _start = start;
            _logger = logger;
            _context = context;
        }

        // this is invoked at the end of the `ExecuteRequest` operation
        public void Dispose()
        {
            var end = DateTime.UtcNow;
            var elapsed = end - _start;

            _logger.LogInformation("Request finished after {Ticks} ticks",
                elapsed.Ticks);

            // when the request is finished it will dispose the activity scope and
            // this is when we print the parsed query.
            if (_context.Document is not null)
            {
                // we just need to do a ToString on the Document which represents the parsed
                // GraphQL request document.
                StringBuilder stringBuilder = new(_context.Document.ToString(true));
                stringBuilder.AppendLine();

                if (_context.Variables != null)
                {
                    var variablesConcrete = _context.Variables!.ToList();
                    if (variablesConcrete.Count > 0)
                    {
                        stringBuilder.AppendFormat($"Variables {Environment.NewLine}");
                        try
                        {
                            foreach (var variableValue in _context.Variables!)
                            {
                                string PadRightHelper(string existingString, int lengthToPadTo)
                                {
                                    if (string.IsNullOrEmpty(existingString))
                                    {
                                        return "".PadRight(lengthToPadTo);
                                    }

                                    if (existingString.Length > lengthToPadTo)
                                    {
                                        return existingString.Substring(0, lengthToPadTo);
                                    }

                                    return existingString + " ".PadRight(lengthToPadTo - existingString.Length);
                                }
                                stringBuilder.AppendFormat(
                                    $"  {PadRightHelper(variableValue.Name, 20)} :  {PadRightHelper(variableValue.Value.ToString(), 20)}: {variableValue.Type}");
                                stringBuilder.AppendFormat($"{Environment.NewLine}");
                            }
                        }
                        catch
                        {
                            // all input type records will land here.
                            stringBuilder.Append("  Formatting Variables Error. Continuing...");
                            stringBuilder.AppendFormat($"{Environment.NewLine}");
                        }
                    }
                }
                _logger.LogInformation(stringBuilder.ToString());
            }
        }
    }
}
