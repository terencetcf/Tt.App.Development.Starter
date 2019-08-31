using System;

namespace Tt.App.Extensions
{
    public static class StringExtensions
    {
        public static string RemovePostFix(this string str, params string[] postFixes)
        {
            if (str == null)
            {
                return null;
            }

            if (str == string.Empty)
            {
                return string.Empty;
            }

            if (postFixes.IsNullOrEmpty())
            {
                return str;
            }

            foreach (var postFix in postFixes)
            {
                if (str.EndsWith(postFix))
                {
                    return str.Left(str.Length - postFix.Length);
                }
            }

            return str;
        }

        public static bool IsNullOrEmpty(this string[] str)
        {
            return str == null || str.Length < 1;
        }

        public static string Left(this string str, int length)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.Length < length)
            {
                throw new ArgumentException("Length argument is greater than str's length!");
            }

            return str.Substring(0, length);
        }
    }
}
