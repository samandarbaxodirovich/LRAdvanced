using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LRAdvanced.Service.Common.Attributes
{
    public class InputAtributes
    {
        public static bool IsValid(string s)
        {
            return s.Length >= 8 && Regex.IsMatch(s, @"^(?=.*\p{Lu})(?=.*\p{N})[\p{L}\p{N}]+$");
        }
    }
}
