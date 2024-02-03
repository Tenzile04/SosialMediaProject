﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidVideoContentTypeException : Exception
	{
		public string PropertyName { get; set; }
		public InvalidVideoContentTypeException()
		{

		}
		public InvalidVideoContentTypeException(string message) : base(message)
		{

		}
		public InvalidVideoContentTypeException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
