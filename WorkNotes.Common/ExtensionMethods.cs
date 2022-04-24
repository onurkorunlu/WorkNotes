using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkNotes.Common
{
    public static class ExtensionMethods
    {
        public static string SafeTrim(this string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }
            return word.Trim();
        }
    }
}
