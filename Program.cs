using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySQLexe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            agants agants = new agants();
            employeesDHL dhl = new employeesDHL();
            dhl.addAgant(agants);
            agants.Location = "a";
            agants.Status = "b";
            agants.CodeName = "t";
            agants.RealName = "i";
            agants.MissionsCompleted = 2;
        }
    }
}

