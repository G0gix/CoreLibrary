using CoreLibrary.Launching.Exceptions;
using CoreLibrary.Launching.Interfaces;
using System.Diagnostics;
using System.IO;

namespace CoreLibrary.Launching
{
    /// <summary>
    /// Provides the ability to open a file with a standard program
    /// </summary>
    public class LaunchFile : ILaunch
    {
        public string FilePath { get; set; }
        
        public LaunchFile() { }
        
        public LaunchFile(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Run the file with a standard program.
        /// </summary>
        /// <exception cref="LaunchException">Represents errors that occur during file execution.</exception>
        public void Launch()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    throw new LaunchException("File not found");
                }

                using (Process p = new Process())
                {
                    p.StartInfo = new ProcessStartInfo(FilePath)
                    {
                        UseShellExecute = true
                    };

                    p.Start();
                }
            }
            catch (LaunchException)
            {
                throw;
            }
            catch (System.Exception ex)
            {
                throw new LaunchException(ex.Message);
            }
        }
    }
}
