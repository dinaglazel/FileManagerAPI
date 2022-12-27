using DataEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces
{
    public interface IMailBO
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
