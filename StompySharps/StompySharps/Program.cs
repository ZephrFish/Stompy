using System;
using System.IO;
using System.Security.Principal;

namespace StompySharps
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            DateTime newTimestamp = DateTime.Now;
            bool recurse = false;
            string username = "";
            string password = "";

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "-path":
                        path = args[++i];
                        break;
                    case "-newtimestamp":
                        newTimestamp = DateTime.Parse(args[++i]);
                        break;
                    case "-recurse":
                        recurse = true;
                        break;
                    case "-username":
                        username = args[++i];
                        break;
                    case "-password":
                        password = args[++i];
                        break;
                }
            }

            if (string.IsNullOrEmpty(path) || newTimestamp == DateTime.Now)
            {
                Console.WriteLine("Usage: StompySharps.exe -path <path> -newTimestamp <datetime> [-recurse] [-username <username> -password <password>]");
                return;
            }

            if (!string.IsNullOrEmpty(username))
            {
                using (new Impersonation(username, password))
                {
                    StompTime(path, newTimestamp, recurse);
                }
            }
            else
            {
                StompTime(path, newTimestamp, recurse);
            }
        }

        private static void StompTime(string path, DateTime newTimestamp, bool recurse)
        {
            if (recurse && Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    UpdateTimestamp(file, newTimestamp);
                }
            }
            else
            {
                UpdateTimestamp(path, newTimestamp);
            }
        }

        private static void UpdateTimestamp(string path, DateTime newTimestamp)
        {
            if (File.Exists(path))
            {
                File.SetCreationTime(path, newTimestamp);
                File.SetLastAccessTime(path, newTimestamp);
                File.SetLastWriteTime(path, newTimestamp);
                Console.WriteLine($"Modified timestamps for file: {path}");
            }
            else if (Directory.Exists(path))
            {
                Directory.SetCreationTime(path, newTimestamp);
                Directory.SetLastAccessTime(path, newTimestamp);
                Directory.SetLastWriteTime(path, newTimestamp);
                Console.WriteLine($"Modified timestamps for directory: {path}");
            }
            else
            {
                Console.WriteLine($"Path not found: {path}");
            }
        }
    }

    public class Impersonation : IDisposable
    {
        private WindowsImpersonationContext _context;

        public Impersonation(string username, string password)
        {
            var identity = new WindowsIdentity(username, password);
            _context = identity.Impersonate();
        }

        public void Dispose()
        {
            _context.Undo();
        }
    }
}
