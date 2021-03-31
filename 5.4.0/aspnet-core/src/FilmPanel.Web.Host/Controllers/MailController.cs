using FilmPanel.Controllers;
using FilmPanel.FilmPanelAppService.MailService;
using FilmPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmPanel.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : FilmPanelControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }


        /// <summary>
        /// Mail gönderimi için başlangıç metodu
        /// </summary>
        ///<param name = "request" > Mail gönderimi için gerekli olan parametreler.(Alıcı Mail Adresi , Başlık , İçerik)</param>

        [HttpPost, Route("SendMail")]
        public async Task<IActionResult> SendMail([FromForm] SendMail request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
