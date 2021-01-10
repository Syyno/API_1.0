using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Project.Models;
using Project.Models.Auth;
using Project.Models.Builder;
using Project.Models.Domain;
using Project.Services;
using Project.Util;

namespace Project.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(IRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet("About")]
        public ActionResult<About> About()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fileVersionInfo.ProductVersion;

            return new About()
            {
                ProjectName = "ProjectApi",
                Time = DateTime.Now.ToLocalTime().ToString("HH:mm"),
                Version = version
            };
        }

        [Util.Authorize]
        [HttpGet("test")]
        public ActionResult<string> AuthorizedOnly() => "Only authorized users able to see this message!";
       

        [HttpPost("Register")]
        public IActionResult Register(RegisterModel registerModel)
        {
            var regModelDb = _mapper.Map<RegisterModelDb>(registerModel);
            _repository.Register(regModelDb);
            return Ok();
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            var user = _repository.RegisteredUsers()
                .FirstOrDefault(u => u.Login == request.Login && u.Password == request.Password);
            if (user == null)
                return NotFound( new {Error = "There is no such user in db"});

            return Ok( new {Token = user.CreateToken()});
        }


        [HttpGet("GetYoutubeAdmins")]
        public ActionResult<List<string>> GetYoutubeAdmins()
        {
            var request = new GetRequestModel() {Group = "admin", Services = new List<string>() {"youtube"}};
            return _repository.GetUsersByGroupAndServices(request).ToList();
        }

        [HttpPost("PostNewUser")]
        public ActionResult PostNewUser(PostUser postUser)
        {
            var builder = new ConcreteBuilder(_repository);
            var director = new Director(builder, postUser);
            director.Construct();
            var user = builder.GetResult();
            if (user == _repository.GetUserByNameSurnameAge(postUser.Name, postUser.Surname, postUser.Age))
                return Ok(new {Message = "New user has been created"});
            return BadRequest();
        }
    }
}
