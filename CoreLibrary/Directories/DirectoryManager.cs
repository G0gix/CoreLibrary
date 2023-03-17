using CoreLibrary.Directories.Exceptions;
using CoreLibrary.Directories.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreLibrary.Directories
{
    /// <summary>
    /// Provides access to directory files
    /// </summary>
    public static class DirectoryManager
    {
        /// <summary>
        /// Get all files from directory with full path
        /// </summary>
        /// <param name="directoryPath">Full path to directory</param>
        /// <returns>Full path of files</returns>
        /// <exception cref="DirectoryManagerException">Represents errors that occur while working with directories.</exception>
        public static IEnumerable<string> GetFiles(string directoryPath)
        {
             try
             {
                 return GetFilesFromDir(directoryPath);
             }
             catch (Exception ex)
             {
                 throw new DirectoryManagerException(ex.Message);
             }
        }

        /// <summary>
        /// Get filenames from directory with file extension
        /// </summary>
        /// <param name="directoryPath">Full path to directory</param>
        /// <returns>FilesNames with extension</returns>
        /// <exception cref="DirectoryManagerException">Represents errors that occur while working with directories.</exception>
        public static IEnumerable<string> GetFilesNames(string directoryPath)
        {
            try
            {
                return FileNames(directoryPath);
            }
            catch (Exception ex)
            {
                throw new DirectoryManagerException(ex.Message);
            }
        }

        /// <summary>
        /// Get filenames from directory without file extension
        /// </summary>
        /// <param name="directoryPath">Full path to directory</param>
        /// <returns>FilesNames without extension</returns>
        /// <exception cref="DirectoryManagerException">Represents errors that occur while working with directories.</exception>
        public static IEnumerable<string> GetFilesNamesWithoutExtension(string directoryPath)
        {
            try
            {
                return FileNames(directoryPath).Select(file => Path.GetFileNameWithoutExtension(file));
            }
            catch (Exception ex)
            {
                throw new DirectoryManagerException(ex.Message);
            }
        }

        /// <summary>
        /// Get a list of files in the form of a file name and path
        /// </summary>
        /// <param name="directoryPath">Full path to directory</param>
        /// <returns>List of files. As a filename and full path to the file</returns>
        /// <exception cref="DirectoryManagerException">Represents errors that occur while working with directories.</exception>
        public static IEnumerable<FileModel> GetFileNameAndPath(string directoryPath)
        {
            try
            {
                List<FileModel> fileList = new List<FileModel>();

                string[] files = GetFilesFromDir(directoryPath).ToArray();

                foreach (string file in files)
                {
                    string name = Path.GetFileNameWithoutExtension(file);
                    fileList.Add(new FileModel
                    {
                        Name = name,
                        Path = file,
                    });
                }

                return fileList;
            }
            catch (Exception ex)
            {
                throw new DirectoryManagerException(ex.Message);
            }
        }

        /// <summary>
        /// Get filenames from directory with file extension
        /// </summary>
        /// <param name="directoryPath">Full path to directory</param>
        /// <returns>FilesNames with extension</returns>
        /// <exception cref="DirectoryManagerException">Represents errors that occur while working with directories.</exception>
        private static IEnumerable<string> FileNames(string directoryPath)
        {
            try
            {
                List<string> files = new List<string>();

                foreach (string file in GetFilesFromDir(directoryPath))
                {
                    files.Add(Path.GetFileName(file));
                }

                return files;
            }
            catch (Exception ex)
            {
                throw new DirectoryManagerException(ex.Message);
            }
        }

        /// <summary>
        /// Get all files from directory with full path
        /// </summary>
        /// <param name="directoryPath">Full path to directory</param>
        /// <returns>Full path of files</returns>
        /// <exception cref="DirectoryManagerException">Represents errors that occur while working with directories.</exception>
        private static IEnumerable<string> GetFilesFromDir(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    throw new DirectoryManagerException("Directory not found");
                }

                string[] files = Directory.GetFiles(directoryPath);
                return files;
            }
            catch (Exception ex)
            {
                throw new DirectoryManagerException(ex.Message);
            }
        }
    }
}
