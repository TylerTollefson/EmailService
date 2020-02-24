using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmailService.Models;
using EmailService.Helpers;

namespace EmailService.Controllers
{
    [ApiController]
    [Route("/api/EmailService")]
    public class EmailInfoController : ControllerBase
    {

        private readonly ILogger<EmailInfoController> _logger;

        public EmailInfoController(ILogger<EmailInfoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/api/EmailService/RetrieveUniqueCount")]
        public IActionResult UniqueEmailCount(List<string> emailList)
        {
            EmailValidator helper = new EmailValidator();
            EmailInfo current = EmailInfo.getCurrent();
            if (helper.IsValidEmailList(emailList))
            {
                current.SetEmailList(emailList);
                current.CleanseEmailList();
                return Ok($"Count of unique emails is {current.GetUniqueCount()}");
            } else
            {
                return BadRequest("Email list must contain at least one valid email.");
            }
        }
    }
}
