using System;
using System.IO;
using System.Threading.Tasks;
using SimpleServer.Interfaces;

namespace SimpleServer
{
    public class Logger : ILog
    {
        private static readonly string _defaultPath = "clientLog";
        private static readonly string _extension = ".txt";
        private readonly string _path;

        public Logger(int id)
        {
            _path = _defaultPath + id + _extension;
        }

        public void Write(string message)
        {
            if (!File.Exists(_path))
                File.Create(_path);

            using (var fs = new FileStream(_path, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                try
                {
                   writer.WriteLine(message);
                }
                finally
                {
                   writer.Close();
                   fs.Close();
                }
             }
            
        }
    }
}
