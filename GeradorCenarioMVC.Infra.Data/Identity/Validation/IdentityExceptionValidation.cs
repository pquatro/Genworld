using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Infra.Data.Identity.Validation
{
    public class IdentityExceptionValidation : Exception
    {
        public IdentityExceptionValidation(string error) : base(error)
        {

        }



        public static void When(bool hasError, string errorType, string msgOtherErrorType, string field)
        {
            if (hasError)
            {
                string errorMsg = null;

                switch (errorType)
                {
                    case "notFound":
                        errorMsg = "Usuário não encontrado";
                        break;
                    case "passwordWeak":
                        errorMsg = "Tentativa de registro inválida (a senha precisa seguir as regras de segurança).";
                        break;
                    case "emptyField":
                        errorMsg = string.Format("Inválido {0}. {0} não pode ser nulo ou vazio.", field); 
                        break;                        
                    default:
                        errorMsg = msgOtherErrorType;
                        break;
                }

                throw new IdentityExceptionValidation(errorMsg);
            }

        }
    }
}
