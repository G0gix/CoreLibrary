using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Launching.Exceptions
{
    /// <summary>
    /// Represents errors that occur during file execution.
    /// </summary>
    [Serializable]
	public class LaunchException : Exception
	{
		public LaunchException() { }
		public LaunchException(string message) : base(message) { }
		public LaunchException(string message, Exception inner) : base(message, inner) { }
		protected LaunchException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
