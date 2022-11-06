using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementAPI.Shared
{
    public class Common
    {
        public string createCode(int id)
        {
            int characterCount = id.ToString().Length;
            string code = "";
            switch (characterCount)
            {
                case 1:
                    code = "000" + id;
                    break;
                case 2:
                    code = "00" + id;
                    break;
                case 3:
                    code = "0" + id;
                    break;
                default:
                    code = id.ToString();
                    break;
            }

            return code;

        }
    }
}