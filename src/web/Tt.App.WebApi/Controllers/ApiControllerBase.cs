using Microsoft.AspNetCore.Mvc;

namespace Tt.App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
    }
}