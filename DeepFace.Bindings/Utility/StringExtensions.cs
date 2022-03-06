using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace DeepFace.Bindings.Utility
{
    internal static class StringExtensions
    {
        internal static string ToInvarianTitleCase(this string self)
        {
            if (string.IsNullOrWhiteSpace(self))
            {
                return self;
            }

            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(self);
        }

        internal static bool IsBase64(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
                                                   || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);

                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

            return false;
        }
    }
}
