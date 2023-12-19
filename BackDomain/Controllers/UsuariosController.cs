using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using WepApi.Services.IServices;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {

            _usuarioServices = usuarioServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usuarioServices.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _usuarioServices.GetbyId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioResponse i)
        {

            return Ok(await _usuarioServices.Create(i));

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UsuarioResponse i, int id)
        {
            return Ok(await _usuarioServices.Update(i, id));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _usuarioServices.Delete(id));
        }

    }
}
