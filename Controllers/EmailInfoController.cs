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

        [HttpPost]
        [Route("/api/UniqueEmailService/RetrieveUniqueCount")]
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
