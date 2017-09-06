using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Constants
{
    public class ValidationConstants
    {
        public static string ServiceNumberPattern
        {
            get
            {
                return @"^[a-zA-Z]\d{8}";
            }
        }
    }
}
