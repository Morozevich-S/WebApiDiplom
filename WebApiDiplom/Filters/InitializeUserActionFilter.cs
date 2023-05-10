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

            var userId = int.Parse(context.HttpContext.User.FindFirst(JwtRegisteredClaimNames.NameId)?.Value);

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.UserId == userId);
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.UserId == userId);

            controller.CurrentClient = client;
            controller.CurrentEmployee = employee;
        }
    }
}
