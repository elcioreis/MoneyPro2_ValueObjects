using Money2.Domain.Entities;
using Money2.Domain.ValueObjects;

namespace Money2.Tests.Entities;

[TestClass]
public class UserTest
{
    private readonly UserName _userName = new UserName("Silva");
    private readonly Name _name = new Name("Jose", "Silva");
    private readonly Email _email = new Email("jose.silva@gmail.com");
    private readonly CPF _cpf = new CPF("02197034855");
    private readonly Password _password = new Password("ABCabc123@!#");

    [TestMethod]
    [TestCategory("Domain.Entities")]
    public void Usuario_Com_UserName_Invalido_Deve_Falhar()
    {
        UserName invalidUserName = new UserName("");
        User user = new User(invalidUserName, _name, _email, _cpf, _password);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [TestCategory("Domain.Entities")]
    public void Usuario_Com_Nome_Invalido_Deve_Falhar()
    {
        var invalidName = new Name("Jose", "");
        User user = new User(_userName, invalidName, _email, _cpf, _password);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [TestCategory("Domain.Entities")]
    public void Usuario_Com_Email_Invalido_Deve_Falhar()
    {
        var invalidEmail = new Email("email com espacos@gmail.com");
        User user = new User(_userName, _name, invalidEmail, _cpf, _password);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [TestCategory("Domain.Entities")]
    public void Usuario_Com_Senha_Fraca_Deve_Falhar()
    {
        Password weakPassword = new Password("1234567890");
        User user = new User(_userName, _name, _email, _cpf, weakPassword);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [TestCategory("Domain.Entities")]
    public void Usuario_Com_CPF_Invalido_Deve_Falhar()
    {
        CPF badCPF = new CPF("02197034800");
        User user = new User(_userName, _name, _email, badCPF, _password);
        Assert.IsFalse(user.IsValid);
    }

    [TestMethod]
    [TestCategory("Domain.Entities")]
    public void Usuario_Valido_Deve_Passar()
    {
        User user = new User(_userName, _name, _email, _cpf, _password);
        Assert.IsTrue(user.IsValid);
    }

    [TestMethod]
    [TestCategory("Domain.Entities")]
    public void Usuario_ToString_Valido_Deve_Passar()
    {
        User user = new User(_userName, _name, _email, _cpf, _password);
        Assert.AreEqual($"{user.Name.FirstName} {user.Name.LastName}", user.Name.ToString());
    }
}
