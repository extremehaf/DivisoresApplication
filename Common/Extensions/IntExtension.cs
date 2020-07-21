using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public static class IntExtension
    {
        public static bool EPrimo(this int num)
        {
            var div = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                    div++;
            }
            return div == 2;
        }
    }
}
