using System;

namespace WindowsFormsApp2
{
    internal class DirectoryEntry
    {
        private string v;
        private string uName;
        private string password;

        public DirectoryEntry(string v, string uName, string password)
        {
            this.v = v;
            this.uName = uName;
            this.password = password;
        }

        public object Nativeobject { get; internal set; }

        internal static string[] GetFiles(string selectedPath)
        {
            throw new NotImplementedException();
        }
    }
}