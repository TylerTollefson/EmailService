using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniqueEmailService.Models;
using UniqueEmailService.Helpers;

namespace UniqueEmailService.Controllers
{
    [ApiController]
    [Route("/api/UniqueEmailService")]
    public class EmailInfoController : ControllerBase
    {

        private readonly ILogger<EmailInfoController> _logger;

        public EmailInfoController(ILogger<EmailInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/api/UniqueEmailService/GetUniqueCount")]
        public IActionResult GetUniqueCount()
        {
            try
            {
                return Ok(EmailInfo.getCurrent().GetUniqueCount());
            } catch (Exception e)
            {
                return BadRequest($"Encountered an exception retrieving unique count {e.Message}");
            }
            
        }

        [HttpPost]
        [Route("/api/UniqueEmailService/SetEmailList")]
        public IActionResult SetEmailList(List<string> emailList)
        {
            EmailValidator helper = new EmailValidator();
            if (helper.IsValidEmailList(emailList))
            {
                EmailInfo.getCurrent().SetEmailList(emailList);
                EmailInfo.getCurrent().CleanseEmailList();
                return Ok("Email list has been successfully set.");
            } else
            {
                return BadRequest("Email list must contain at least one valid email.");
            }
        }
    }
}
