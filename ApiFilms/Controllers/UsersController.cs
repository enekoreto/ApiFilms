using ApiFilms.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilms.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRespositoryUser _usRepo;
        private readonly IMapper _mapper;

        public UsersController(IRespositoryUser usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
        }
    }
}
