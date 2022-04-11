using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialize_in_3_type_pdf
{
    [Serializable]
    public class Users
    {
        public List<Data> UserDataList { get; set; } = new List<Data>();
    }
    [Serializable]
    public class Data
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public Data()
        {

        }
        public Data(string name,string login,string password,string salt)
        {
            Name = name;
            Login = login;
            Password = password;
            Salt = salt;
        }

    }

}
