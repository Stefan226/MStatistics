using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.KPI
{
    public class DAU
    {
        public DAU()
        {

        }

        public string GetDailyActiveUsers(string path)
        {
            string finalPath = "Analytics/" + path;

            if (Directory.Exists(finalPath) && path != "")
                return Directory.GetFiles(finalPath).Length + "";
            return "";
        }

        public int GetDailyActiveUsersInt(string path)
        {
            string finalPath = "Analytics/" + path;

            if (Directory.Exists(finalPath) && path != "")
                return Directory.GetFiles(finalPath).Length;
            return -1;
        }
    }
}
