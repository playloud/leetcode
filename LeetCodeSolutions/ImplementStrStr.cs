using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    class ImplementStrStr
    {

        public int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
                return -1;

            if (needle.Length == 0)
                return 0;

            for (int i = 0; i < haystack.Length - needle.Length+1; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                    return i;
            }
            
            return -1;
        }

    }
}
