using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TodoDbRepository : IRepository<Todo>
    {
        private readonly TodoContext _todoContext;

        public TodoDbRepository(TodoContext context)
        {
            _todoContext = context;
        }

        public Todo Add(Todo entity)
        {
            _todoContext.Add(entity);
            _todoContext.SaveChanges();
            return entity;
        }

        public IEnumerable<Todo> GetAll()
        {
            return _todoContext.Todos
                // .OrderByDescending(e => e.CreatingDate)
                //.Where(e => e.IsDone == true)
                .ToList();
        }

        public Todo Get(int id)
        {
            return _todoContext.Todos.Find(id);
        }

        public void Delete(int id)
        {
            var entityToRemove = _todoContext.Todos.Find(id);
            _todoContext.Todos.Remove(entityToRemove);
            _todoContext.SaveChanges();
        }

        public Todo Edit(Todo entity)
        {
            _todoContext.Todos.Update(entity);
            _todoContext.SaveChanges();
            return entity;
        }
    }
}
