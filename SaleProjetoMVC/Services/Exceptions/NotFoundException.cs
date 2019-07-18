using System;


namespace SaleProjetoMVC.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
        
    }
}
