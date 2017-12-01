using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using HelloAngular.Models;
using HelloAngular.Interface;

namespace HelloAngular.Controllers
{
    /// <summary>
    /// TodoController
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ApplicationDBConnectionSettings _dbConnectionSettings;

        private readonly TodoContext _context;

        private readonly ISystemDateTime _sysDateTime;

        /// <summary>
        /// TodoController
        /// </summary>
        /// <param name="dbConnectionSettings"></param>
        /// <param name="context"></param>
        /// <param name="sysDateTime"></param>
        public TodoController(IOptions<ApplicationDBConnectionSettings> dbConnectionSettings,
          TodoContext context,
          ISystemDateTime sysDateTime)
        {
            _context = context;

            _dbConnectionSettings = dbConnectionSettings.Value;

            _sysDateTime = sysDateTime;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1_"
                  + _sysDateTime.Now.ToString() + "_"
                  + "Server:" + _dbConnectionSettings.Server + "_"
                  + "DataBase:" + _dbConnectionSettings.DataBase + "_"
                  + "SAType:" + _dbConnectionSettings.SAType + "_"
                  + "SATypeList:" + _dbConnectionSettings.SATypeList });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long Id)
        {
            var item = _context.TodoItems.FirstOrDefault(x => x.Id == Id);
            if (item == null)
            {
              return NotFound();
            }

            return new ObjectResult(item);
        }

        /// <summary>
        /// Create a Todo Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        /// </remarks>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly-created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(typeof(TodoItem), 201)]
        [ProducesResponseType(typeof(TodoItem), 400)]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name = item.Name;
            todo.IsComplete = item.IsComplete;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
