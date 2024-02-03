using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidVideoException:Exception
	{
		public string PropertyName { get; set; }
		public InvalidVideoException()
		{

		}
		public InvalidVideoException(string message) : base(message)
		{

		}
		public InvalidVideoException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
