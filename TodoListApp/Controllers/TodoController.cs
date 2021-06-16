using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IRepository<Todo> _repository;
        private readonly ILogger<TodoController> _logger;

        public TodoController(IRepository<Todo> repository, ILogger<TodoController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public Todo Add(Todo newTodo)
        {
            newTodo.CreatingDate = DateTime.Now;
            return _repository.Add(newTodo);
        }

        [HttpPut]
        public Todo Edit(Todo todo)
        {
            var originalEntity = _repository.Get(todo.Id);
            originalEntity.IsDone = todo.IsDone;
            originalEntity.Text = todo.Text;
            return _repository.Edit(originalEntity);
        }

        [HttpDelete]
        public void Delete(int todoId)
        {
            _repository.Delete(todoId);
        }
    }
}
