﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
	public class InvalidImageException : Exception
	{
		public string PropertyName { get; set; }
		public InvalidImageException()
		{

		}
		public InvalidImageException(string message) : base(message)
		{

		}
		public InvalidImageException(string propertyName, string message) : base(message)
		{
			PropertyName = propertyName;
		}
	}
}
