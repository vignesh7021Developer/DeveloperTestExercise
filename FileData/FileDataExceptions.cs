using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    class InvalidOptionsException:Exception
    {
        public InvalidOptionsException()
        {

        }
        public InvalidOptionsException(string message):base(message)
        {

        }
    }

    class InvalidNumberOfOptionsException:Exception
    {
        public InvalidNumberOfOptionsException()
        {

        }
        public InvalidNumberOfOptionsException(string message):base(message)
        {

        }
    }
}
