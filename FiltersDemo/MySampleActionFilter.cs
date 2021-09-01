using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class MySampleActionFilter : Attribute, IActionFilter, IOrderedFilter
{
    private readonly string _name;
    public int Order { get; set; }

    public MySampleActionFilter(string name, int order = 0)
    {
        _name = name;
        Order = order;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Do something before the action executes.
        Console.WriteLine($"Action - Before - {_name}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Do something after the action executes.
        Console.WriteLine($"Action - After - {_name}");
    }
}