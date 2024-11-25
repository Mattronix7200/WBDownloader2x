using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WBDownloader2
{
    internal static class Program
    {
        private static StreamWriter? logWriter;
        public static readonly string rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));

        [STAThread]
        static void Main()
        {
            ConfigureLogging();
            try
            {
                ApplicationConfiguration.Initialize();
                LogEvent("Aplikacja uruchomiona.");
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                LogEvent("Wyj¹tek: " + ex.ToString());
                throw;
            }
            finally
            {
                LogEvent("Aplikacja zakoñczy³a dzia³anie.");
                TerminateProcesses(new[] {"ClipWatcher"});
                logWriter?.Close();
            }
        }

        private static void ConfigureLogging()
        {
            string logsDirectory = Path.Combine(rootPath, "data", "userdata", "logs");

            Directory.CreateDirectory(logsDirectory);
            string appLoggedEventsPath = Path.Combine(logsDirectory, "appevents_log.txt");
            logWriter = new StreamWriter(appLoggedEventsPath, true, Encoding.UTF8) { AutoFlush = true };

            Console.SetOut(logWriter);
            Console.SetError(logWriter);

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                LogEvent("Nieprzechwycony wyj¹tek: " + e.ExceptionObject.ToString());
            };
        }

        private static void TerminateProcesses(string[] processNames)
        {
            foreach (string processName in processNames)
            {
                try
                {
                    foreach (Process process in Process.GetProcessesByName(processName))
                    {
                        process.Kill();
                        process.WaitForExit();
                        LogEvent($"Proces {processName} zosta³ zamkniêty.");
                    }
                }
                catch (Exception ex)
                {
                    LogEvent($"B³¹d przy zamykaniu procesu {processName}: {ex.Message}");
                }
            }
        }

        public static void LogEvent(string message)
        {
            string logMessage = $"{DateTime.Now}: {message}";
            logWriter?.WriteLine(logMessage);
            logWriter?.Flush();
        }
    }
}
