using AutoMapper;
using CoreApi.Entities;
using CoreApi.Helpers;
using CoreApi.Models;
using CoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class TodosController : ControllerBase
    {
        private ITodoService _todoService;
        private IMapper _mapper;

        public TodosController(
            ITodoService todoService,
            IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoModel model)
        {
            try
            {
                _todoService.Create(model);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var todos = _todoService.GetAll();
                return Ok(todos);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var todo = _todoService.GetById(id);
                return Ok(todo);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] TodoModel model)
        {
            try
            {
                _todoService.Update(id, model);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _todoService.Delete(id);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}