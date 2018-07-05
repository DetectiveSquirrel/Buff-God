using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Buff_God.Structs
{
    public class CustomSearcher
    {
        public static List<string> GetDirectories(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }

            var directories = new List<string>(GetDirectories(path, searchPattern));

            foreach (var directory in directories)
            {
                directories.AddRange(GetDirectories(directory, searchPattern));
            }

            return directories;
        }

        private static List<string> GetDirectories(string path, string searchPattern)
        {
            try
            {
                return Directory.GetDirectories(path, searchPattern).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                return new List<string>();
            }
        }
    }
}