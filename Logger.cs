using System;
using System.IO;
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


            try
            {
                File.AppendAllText(_path, message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
