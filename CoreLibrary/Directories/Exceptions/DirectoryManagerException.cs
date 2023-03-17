using System;


namespace CoreLibrary.Directories.Exceptions
{
    /// <summary>
    /// Represents errors that occur while working with directories.
    /// </summary>
    [Serializable]
	public class DirectoryManagerException : Exception
	{
		public DirectoryManagerException() { }
		public DirectoryManagerException(string message) : base(message) { }
		public DirectoryManagerException(string message, Exception inner) : base(message, inner) { }
		protected DirectoryManagerException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
