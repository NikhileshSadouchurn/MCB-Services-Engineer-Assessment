using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WindowsFormsApp2
{
         class myForm
        {
             static void Main()
            {
            var watcher = new FileSystemWatcher(@"shared path of organisation");//shared path of organisation

                watcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Security
                                     | NotifyFilters.Size;

                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;
                watcher.Error += OnError;

                watcher.Filter = "*.txt";
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }

            private static void OnChanged(object sender, FileSystemEventArgs e)
            {
                if (e.ChangeType != WatcherChangeTypes.Changed)
                {
                    return;
                }
                Console.WriteLine($"Changed: {e.FullPath}");//raise alert when file has been modified
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Files changed";
                popup.ContentText = "Files have been mofified";
                popup.Popup();
            }

            private static void OnCreated(object sender, FileSystemEventArgs e)
            {
                string value = $"Created: {e.FullPath}";//raise alert when file has been delivered
            Console.WriteLine(value);
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "New files";
                popup.ContentText = "New files have been delivered";
                popup.Popup();
            }

            private static void OnDeleted(object sender, FileSystemEventArgs e) =>
                Console.WriteLine($"Deleted: {e.FullPath}");//raise alert when file has been deleted

        private static void OnRenamed(object sender, RenamedEventArgs e)
            {
                Console.WriteLine($"Renamed:");
                Console.WriteLine($"    Old: {e.OldFullPath}");
                Console.WriteLine($"    New: {e.FullPath}");
            }

            private static void OnError(object sender, ErrorEventArgs e) =>
                PrintException(e.GetException());

            private static void PrintException(Exception ex)
            {
                if (ex != null)
                {
                    Console.WriteLine($"Message: {ex.Message}");
                    Console.WriteLine("Stacktrace:");
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine();
                    PrintException(ex.InnerException);
                }
            }
        }
    }

