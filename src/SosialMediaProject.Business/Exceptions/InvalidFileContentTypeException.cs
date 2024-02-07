using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidFileContentTypeException : Exception
	{
		public string PropertyName { get; set; }
		public InvalidFileContentTypeException()
		{

		}
		public InvalidFileContentTypeException(string message) : base(message)
		{

		}
		public InvalidFileContentTypeException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
