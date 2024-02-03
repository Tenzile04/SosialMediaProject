using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidVideoSizeException : Exception
	{
		public string PropertyName { get; set; }
		public InvalidVideoSizeException()
		{

		}
		public InvalidVideoSizeException(string message) : base(message)
		{

		}
		public InvalidVideoSizeException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
