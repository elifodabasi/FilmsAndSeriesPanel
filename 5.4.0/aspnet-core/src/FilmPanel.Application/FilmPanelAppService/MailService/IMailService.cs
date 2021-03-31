using Abp.Application.Services;
using FilmPanel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmPanel.FilmPanelAppService.MailService
{
    public interface IMailService: IApplicationService
    {
        Task SendEmailAsync(SendMail mailRequest);
    }
}
