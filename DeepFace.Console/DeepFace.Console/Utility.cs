using System.Reflection;
using System;

namespace DeepFace.Console
{
    internal static class Utility
    {
        internal static byte[] ReadEmbeddedResource(Assembly assembly, string searchPattern)
        {
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(x => x.Contains(searchPattern));
            using var stream = assembly.GetManifestResourceStream(resourceName);
            byte[] ba = new byte[stream.Length];
            stream.Read(ba, 0, ba.Length);
            return ba;
        }

        internal static void LogProperties<T>(string title, T obj)
        {
            System.Console.WriteLine("\n" + title + "\n");

            Type t = obj?.GetType();
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo p in pi)
            {
                System.Console.WriteLine(p.Name + " : " + p.GetValue(obj));
            }
        }
    }
}
