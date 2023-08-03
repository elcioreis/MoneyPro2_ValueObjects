namespace MoneyPro2.Api.ViewModels.User;

public class RegisterUserViewModel
{
    //[Required(ErrorMessage = "O username é obrigatório")]
    public string UserName { get; set; } = null!;

    //[Required(ErrorMessage = "O primeiro nome é obrigatório")]
    public string FirstName { get; set; } = null!;

    //[Required(ErrorMessage = "O sobrenome é obrigatório")]
    public string LastName { get; set; } = null!;

    //[Required(ErrorMessage = "O e-mail é obrigatório")]
    //[EmailAddress(ErrorMessage = "O e-mail é inválido")]
    public string Email { get; set; } = null!;

    //[Required(ErrorMessage = "O CPF é obrigatório")]
    public string Cpf { get; set; } = null!;

    //[Required(ErrorMessage = "A senha é obrigatória")]
    public string Password { get; set; } = null!;
}
