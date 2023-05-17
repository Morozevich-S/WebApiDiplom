using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiDiplom.Controllers;
using WebApiDiplom.Data;

namespace WebApiDiplom.Filters
{
    public class InitializeUserActionFilter : IAsyncActionFilter
    {
        private readonly DataContext _context;

        public InitializeUserActionFilter(DataContext context)
        {
            _context = context;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = (BaseApiController)context.Controller;

            if (context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value == null)
            {
                await next?.Invoke();
                return;
            }

            var userId = int.Parse(context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value);

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.User.Id == userId);
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.User.Id == userId);

            controller.CurrentClient = client;
            controller.CurrentEmployee = employee;

            await next?.Invoke();
        }
    }
}
