using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace UserPlatform.Controllers
{
	[Route("v1/api/[controller]")]
	[ApiController]
	public class UsersController: ControllerBase
	{
		private readonly IMapper _mapper;
		public UsersController(IMapper mapper)
		{
			_mapper=mapper;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return Ok();
		}
	}
}
