using System;
using System.IO;
using System.Reflection;

namespace DA.SS
{
    public static class Directorio
    {
        public static string GetExecutingDirectoryName()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return new FileInfo(location.LocalPath).Directory.FullName;
        }
    }
}
