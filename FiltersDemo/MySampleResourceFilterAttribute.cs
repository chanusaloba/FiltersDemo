using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FiltersDemo
{
    public class MySampleResourceFilterAttribute : Attribute, IResourceFilter
    {
        private readonly string _name;

        public MySampleResourceFilterAttribute(string name)
        {
            _name = name;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Resource - After - {_name}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Resource - Before - {_name}");
            context.Result = new ContentResult()
            {
                Content = "Shortcircuit"
            };
        }
    }
}
