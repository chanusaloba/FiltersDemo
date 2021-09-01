using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace FiltersDemo
{
    public class MySampleResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<MySampleResultFilterAttribute> _logger;
        private readonly Guid _randomId;
        private readonly string _name;

        public MySampleResultFilterAttribute(ILogger<MySampleResultFilterAttribute> logger, string name = "Global")
        {
            _logger = logger;
            _randomId = Guid.NewGuid();
            _name = name;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($"Result Filter - After - {_name} {_randomId}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($"Result Filter - Before - {_name} {_randomId}");
        }
    }
}
