using MeuTodo.Data;
using MeuTodo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.ViewModels;

namespace MeuTodo.Controladores
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAsync([FromServices] BDContexto contexto)
        {
            var todos = await contexto.Todos.AsNoTracking().ToListAsync();

            if (todos == null) NotFound();

            return Ok(todos);
        }

        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] BDContexto contexto, [FromRoute] int id)
        {
            var todos = await contexto.Todos.AsNoTracking().FirstOrDefaultAsync(tarefa => tarefa.Id == id);

            if (todos == null) return NotFound();

            return Ok(todos);
        }


        [HttpPost("todos")]
        public async Task<IActionResult> PostAsync([FromServices] BDContexto contexto, [FromBody] CreateTodoViewModel title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var todo = new TodoModel
            {
                Date = DateTime.Now,
                Done = false,
                Title = title.Title
            };


            await contexto.Todos.AddAsync(todo);
            await contexto.SaveChangesAsync();
            return Created($"v1/todos/{todo.Id}", todo);

        }

    }
}
