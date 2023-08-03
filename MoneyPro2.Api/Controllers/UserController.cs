using Microsoft.AspNetCore.Mvc;
using Money2.Domain.Data;
using Money2.Domain.Entities;
using Money2.Domain.ValueObjects;
using MoneyPro2.Api.ViewModels;
using MoneyPro2.Api.ViewModels.User;

namespace MoneyPro2.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("v1/users/")]
    public async Task<IActionResult> PostAsync(
        [FromBody] RegisterUserViewModel model,
        [FromServices] MoneyPro2DataContext context
    )
    {
        //if (!ModelState.IsValid)
        //    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = new User(
            new UserName(model.UserName),
            new Name(model.FirstName, model.LastName),
            new Email(model.Email),
            new CPF(model.Cpf),
            new Password(model.Password)
        );

        if (!user.IsValid)
        {
            var notifications = user.Notifications.ToList();
            return BadRequest(new ResultViewModel<List<Flunt.Notifications.Notification>>(user.Notifications.ToList())); // .ToList()));
        }
        //return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        return Ok(new ResultViewModel<dynamic>(new
        {
            username = user.UserName.Username,
            name = user.Name.FullName,
            email = user.Email.Address,
            cpf = user.CPF.Valor
        }));
    }

    //// GET: UserController
    ////public ActionResult Index()
    ////{
    ////    return View();
    ////}

    //// GET: UserController/Details/5
    ////public ActionResult Details(int id)
    ////{
    ////    return View();
    ////}

    //// GET: UserController/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: UserController/Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create(IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: UserController/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: UserController/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: UserController/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: UserController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
}
