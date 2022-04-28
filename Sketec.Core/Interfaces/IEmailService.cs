using Sketec.Core.Resources.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailRequest sendEmailRequest);
    }
}
