using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Modelos
{
    public class Conection
    {
        public static MySqlConnection conn = new MySqlConnection("server=localhost; Uid=root; psw=; database=biblioteca");
    }
}
