using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidImageContentTypeException : Exception
	{
		public string PropertyName { get; set; }
		public InvalidImageContentTypeException()
		{

		}
		public InvalidImageContentTypeException(string message) : base(message)
		{

		}
		public InvalidImageContentTypeException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
