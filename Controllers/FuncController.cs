using Microsoft.AspNetCore.Mvc;
using BancaApi.Entities;
using BancaApi.Repositories;

namespace BancaApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FuncController : ControllerBase
    {
        private readonly IFuncRepo _funcRepository;

        public FuncController(IFuncRepo funcRepository)
        {
            _funcRepository = funcRepository;
        }

        [HttpGet]
        public  async Task<IActionResult> GetFuncs()
        {
            var funcs = await _funcRepository.GetFuncsAsync();
            return Ok(funcs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncAsync(int id)
        {
            var func = await _funcRepository.GetFuncByIdAsync(id);

            if (func == null)
            {
                return NotFound("Funzionalità non trovata");
            }

            return Ok(func);
        }

        [HttpPost]
        public async Task<IActionResult> AddFunc([FromBody] FunzionalitaEntity func)
        {
            var newFunc = await _funcRepository.AddFuncAsync(func);
            return CreatedAtAction("GetFunc", new { id = newFunc.Id }, newFunc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFunc(int id, [FromBody] FunzionalitaEntity func)
        {
            var updated = await _funcRepository.UpdateFuncAsync(id, func);

            if (!updated)
            {
                return NotFound("Funzionalità non trovata");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFunc(int id)
        {
            var deleted = await _funcRepository.DeleteFuncAsync(id);

            if (!deleted)
            {
                return NotFound("Funzionalità non trovata");
            }

            return NoContent();
        }
    }
}
