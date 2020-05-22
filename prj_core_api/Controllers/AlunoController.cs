using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prj_core_api.Data;
using prj_core_api.Models;

namespace prj_core_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AlunoController : Controller
  {
    private readonly IRepository _repository;
    public AlunoController(IRepository repository)
    {
      this._repository = repository;
    }

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
      try
      {
        var retorno = await _repository.GetAllAlunos(true);
        return Ok(retorno);
      }
      catch (System.Exception ex)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou" + ex.Message);
      }
    }

    [HttpGet("{AlunoId}")]
    public async Task<IActionResult> GetByAlunoId(int AlunoId)
    {
      try
      {
        var resultado = await _repository.GetAllAlunoById(AlunoId, true);
        return Ok(resultado);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
    }

    [HttpGet("ByProfessor/{ProgessorId}")]
    public async Task<IActionResult> GetAlunosByProfessorId(int ProfessorId)
    {
      try
      {
        var resultado = await _repository.GetAllAlunosByProfessorId(ProfessorId, true);
        return Ok(resultado);
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Aluno model)
    {
      try
      {
        _repository.Incluir(model);
        if (await _repository.SalvarAlteracoesAsync())
        {
            return Created($"/api/aluno/{model.AlunoId}", model);
        }
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
      return BadRequest();
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int AlunoId, Aluno model)
    {
      try
      {
        var aluno = await _repository.GetAllAlunoById(AlunoId, false);
        if (aluno == null)
        {
            return NotFound();
        }
        _repository.Alterar(model);
        if (await _repository.SalvarAlteracoesAsync())
        {
            aluno = await _repository.GetAllAlunoById(AlunoId, true);
            return Created($"/api/aluno/{model.AlunoId}", aluno);
        }
        return Ok();
      }
      catch (System.Exception)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou");
      }
    }

    [HttpDelete("{AlunoId}")]
    public async Task<IActionResult> Delete(int AlunoId)
    {
      try
      {
        var aluno = await _repository.GetAllAlunoById(AlunoId, false);
        if (aluno == null)
        {
            return BadRequest();
        }
        _repository.Excluir(aluno);
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