using AutoMapper;
using CoreApi.Entities;
using CoreApi.Helpers;
using CoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreApi.Services
{
    public interface ITodoService
    {
        List<TodoModel> GetAll();

        TodoModel GetById(Guid id);

        void Update(Guid id, TodoModel model);

        void Create(TodoModel model);

        void Delete(Guid id);
    }

    public class TodoService : ITodoService
    {
        private DataContext _context;
        private IMapper _mapper;

        public TodoService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TodoModel> GetAll()
        {
            var todos = _context.Todo
                .Where(x => x.IsDeleted == false).ToList();

            var model = _mapper.Map<List<TodoModel>>(todos);

            return model;
        }

        public TodoModel GetById(Guid id)
        {
            var todo = _context.Todo
                .SingleOrDefault(x => x.Id == id && x.IsDeleted == false);

            var model = _mapper.Map<TodoModel>(todo);

            return model;
        }

        public void Update(Guid id, TodoModel model)
        {
            var todo = _context.Todo
                .SingleOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (todo == null)
                throw new AppException("Todo could not found.");

            if (!string.IsNullOrWhiteSpace(model.Text))
                todo.Text = model.Text;

            if (todo.IsDone == false && model.IsDone == true)
            {
                todo.IsDone = true;
                todo.DoneAt = DateTime.UtcNow;
            }
            else if (todo.IsDone == true && model.IsDone == false)
            {
                todo.IsDone = false;
                todo.DoneAt = null;
            }

            _context.Todo.Update(todo);
            _context.SaveChanges();
        }

        public void Create(TodoModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Text))
                throw new AppException("Todo text is required");

            var todo = new Todo();

            todo.Text = model.Text;
            todo.CreatedAt = DateTime.UtcNow;

            _context.Todo.Add(todo);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var todo = _context.Todo
                .SingleOrDefault(x => x.Id == id && x.IsDeleted == false);

            if (todo == null)
                throw new AppException("Todo could not found.");

            todo.IsDeleted = true;
            _context.Todo.Update(todo);
            _context.SaveChanges();
        }
    }
}