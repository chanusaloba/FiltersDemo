using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FiltersDemo
{
    public class MySampleAsyncActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _name;

        public MySampleAsyncActionFilterAttribute(string name)
        {
            _name = name;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Action - Before Async - {_name}");

            await next();

            Console.WriteLine($"Action - After Async - {_name}");
        }
    }
}
