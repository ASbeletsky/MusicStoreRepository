using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Domain.Helpers
{
    public static class PriceHelper
    {
        public static string ToPrice(this string str)
        {
            string result = null;
            for(int i = str.Length; i-3 >= 0;)
            {
                i-=3;
                result = str.Insert(i, " ");
            }
            return result + " грн";
        }
    }
}