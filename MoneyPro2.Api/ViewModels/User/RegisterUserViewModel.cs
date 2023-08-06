namespace MoneyPro2.Api.ViewModels.User;

public class RegisterUserViewModel
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Password { get; set; } = null!;
}
