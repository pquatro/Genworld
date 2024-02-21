using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error) 
        {

        }

        

        public static void When(bool hasError, string errorType, string field, string parameter)
        {
            if (hasError)
            {
                string errorMsg = null;

                switch (errorType)
                {
                    case "blank":
                        errorMsg = string.Format("Invalid {0}. {0} is required.", field);
                        break;
                    case "short":
                        errorMsg = string.Format("Invalid {0}, too short, minimum {1} characters.", field, parameter);
                        break;
                    case "long":
                        errorMsg = string.Format("Invalid {0}, too long, maximum {1} characters.", field);
                        break;
                    case "invalid_number":
                        errorMsg = string.Format("Invalid {0}, must be a valid number.", field);
                        break;
                    case "invalid_date":
                        errorMsg = string.Format("Invalid {0}, must be a valid date.", field);
                        break;
                    case "invalid_path":
                        errorMsg = string.Format("Invalid {0}, must be a valid path.", field);
                        break;
                    case "whiteSpace":
                        errorMsg = string.Format("Invalid {0}, white space is not valid.", field);
                        break;
                    default:
                        // code block
                        break;
                }

                throw new DomainExceptionValidation(errorMsg);
            }
            
        }
    }
}
