using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vuelingDomain.Helper
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Returns list of all Enum values for a specific Enum
        /// </summary>
        /// <typeparam name="T"> Type of Enum</typeparam>
        /// <returns> an Enumerable of the specified Enum</returns>
        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }


    }
}
