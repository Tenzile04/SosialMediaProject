using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Exceptions
{
    public class InvalidCredentionalException : Exception
    {
        public string PropertyName { get; set; }
        public InvalidCredentionalException()
        {

        }
        public InvalidCredentionalException(string message) : base(message)
        {

        }
        public InvalidCredentionalException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
