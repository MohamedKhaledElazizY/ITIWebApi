using ITIWebApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITIWebApi.Filters
{
    public class LocationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("departmentDto", out var dto) && dto is DepartmentDto department)
            {
                if (department.Location?.ToLower() != "eg" && department.Location?.ToLower()!="us")
                {
                    context.Result = new BadRequestObjectResult("Location must be 'eg' or 'us'.");
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
