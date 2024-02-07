using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidFileException : Exception
	{
		public string PropertyName { get; set; }
		public InvalidFileException()
		{

		}
		public InvalidFileException(string message) : base(message)
		{

		}
		public InvalidFileException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
