public class Data
{
    public string Name;
    public string Login;
    public string Password;
    public string Salt;

    public Data(string name, string login, string password, string salt)
    {
        Name = name;
        Login = login;
        Password = password;
        Salt = salt;
    }
}
