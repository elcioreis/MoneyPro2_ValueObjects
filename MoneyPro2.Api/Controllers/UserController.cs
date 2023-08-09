using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyPro2.Api.Services;
using MoneyPro2.Api.ViewModels;
using MoneyPro2.Api.ViewModels.User;
using MoneyPro2.Domain.Data;
using MoneyPro2.Domain.Entities;
using MoneyPro2.Domain.ValueObjects;

namespace MoneyPro2.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("v1/users/login")]
    public async Task<IActionResult> LoginAsync(
        [FromBody] LoginViewModel model,
        [FromServices] MoneyPro2DataContext context,
        [FromServices] TokenServices tokenService
    )
    {
        var temp = new Login(new UserName(model.UserName), new Password(model.Password));

        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x =>
                    x.UserName.Username == temp.UserName.Username
                    && x.Password.MD5 == temp.Password.MD5
            );

        if (user == null)
        {
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));
        }

        try
        {
            var token = tokenService.GenerateToken(user);
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch (Exception)
        {
            return StatusCode(
                500,
                new ResultViewModel<string>("00x03 - Falha interna no servidor")
            );
        }
    }

    [HttpPost("v1/users/")]
    public async Task<IActionResult> PostAsync(
        [FromBody] RegisterUserViewModel model,
        [FromServices] MoneyPro2DataContext context
    )
    {
        var user = new User(
            new UserName(model.UserName),
            new Name(model.FirstName, model.LastName),
            new Email(model.Email),
            new CPF(model.Cpf),
            new Password(model.Password)
        );

        if (!user.IsValid)
        {
            return BadRequest(
                new ResultViewModel<List<Flunt.Notifications.Notification>>(
                    user.Notifications.ToList()
                )
            );
        }

        try
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(
                new ResultViewModel<dynamic>(
                    new
                    {
                        username = user.UserName.Username,
                        name = user.Name.FullName,
                        email = user.Email.Address,
                        cpf = user.CPF.Valor
                    }
                )
            );
        }
        catch (DbUpdateException)
        {
            return StatusCode(
                500,
                new ResultViewModel<string>("00x01 - Usuário, cpf ou e-mail já cadastrados")
            );
        }
        catch
        {
            return StatusCode(
                500,
                new ResultViewModel<string>("00x02 - Falha interna no servidor")
            );
        }
    }
}
