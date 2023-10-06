using Microsoft.AspNetCore.Mvc;
using PasswordCheckerBackend.Services.PasswordValidateService;

namespace PasswordCheckerBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordValidateController : ControllerBase
    {
        private IPasswordValidatorService _passwordValidatorService;
        public PasswordValidateController(IPasswordValidatorService passwordValidatorService)
        {
            _passwordValidatorService = passwordValidatorService;
        }
        public class RequestContent
        {
            public string Content { get; set; }
        }

        [HttpPost("upload")]
        public IActionResult UploadText([FromBody] RequestContent request)
        {
            if (string.IsNullOrEmpty(request.Content))
                return BadRequest("Content is empty");

            var validCount = _passwordValidatorService.CountValidPasswords(request.Content);

            return Ok(new { validPasswordCount = validCount });
        }
    }
}