using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prj_core_api.Data;
using prj_core_api.Models;

namespace prj_core_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProfessorController : Controller
  {
    private readonly IRepository _repository;
    public ProfessorController(IRepository repository)
    {
      this._repository = repository;
    }

    [HttpGet()]
    public async Task<IActionResult> get()
    {
      try
      {
        var retorno = await _repository.GetAllProfessores(true);
        return Ok(retorno);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
    }

    [HttpGet("{ProfessorId}")]
    public async Task<IActionResult> GetByProfessorId(int ProfessorId)
    {
      try
      {
        var resultado = await _repository.GetAllProfessorById(ProfessorId, true);
        return Ok(resultado);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Professor model)
    {
      try
      {
        _repository.Incluir(model);
        if (await _repository.SalvarAlteracoesAsync())
        {
          return Created($"/api/professor/{model.ProfessorId}", model);
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
      return BadRequest();
    }

    [HttpPut("{ProfessorId}")]
    public async Task<IActionResult> Put(int ProfessorId, Professor model)
    {
      try
      {
        var professor = await _repository.GetAllProfessorById(ProfessorId, false);
        if (professor == null)
        {
            return NotFound();
        }
        _repository.Alterar(model);
        if (await _repository.SalvarAlteracoesAsync())
        {
            professor = await _repository.GetAllProfessorById(ProfessorId, true);
            return Created($"/api/professor/{model.ProfessorId}", professor);
        }
        return Ok();
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
    }

    [HttpDelete("{ProfessorId}")]
    public async Task<IActionResult> Delete(int ProfessorId)
    {
      try
      {
        var professor = await _repository.GetAllProfessorById(ProfessorId, false);
        if (professor == null)
        {
            return BadRequest();
        }
        _repository.Excluir(professor);
        if (await _repository.SalvarAlteracoesAsync())
        {
            return Ok();
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
      return BadRequest();
    }

  }
}