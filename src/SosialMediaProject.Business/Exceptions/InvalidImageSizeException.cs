using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidImageSizeException : Exception
	{
		public string PropertyName { get; set; }
		public InvalidImageSizeException()
		{

		}
		public InvalidImageSizeException(string message) : base(message)
		{

		}
		public InvalidImageSizeException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
