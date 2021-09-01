using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class MyAsyncResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context,
                                             ResultExecutionDelegate next)
    {
        if (!(context.Result is EmptyResult))
        {
            await next();
        }
        else
        {
            context.Cancel = true;
        }

    }

    Task IAsyncResultFilter.OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        throw new System.NotImplementedException();
    }
}