using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using dotnet_api.Models;
using System;

namespace dotnet_api.Controllers
{
  [Route("api/[controller]")]
  public class TodoController : Controller
  {
    [FromServices]
    public ITodoRepository Todos { get; set; }
    
    // GET /api/todo
    [HttpGet]
    public IEnumerable<Todo> GetAll()
    {
      return Todos.GetAll();
    }
    
    // GET /api/todo/{id}
    [HttpGet("{id}", Name = "GetTodo")]
    public IActionResult GetById(string id)
    {
      var item = Todos.Find(id);
      if (item == null)
      {
        return HttpNotFound();
      }
      return new ObjectResult(item);
    }
    
    // POST /api/todo
    [HttpPost]
    public IActionResult Create(Todo item)
    {
      Console.WriteLine("item:");
      Console.WriteLine(item);
      if (item == null)
      {
        return HttpBadRequest();
      }
      Todos.Add(item);
      return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.id }, item);
    }
    
    // PUT /api/todo/{id}
    [HttpPut("{id}")]
    public IActionResult Update(string id, Todo item)
    {
      Console.WriteLine(id);
      Console.WriteLine(item);
      if (item == null || item.id != id)
      {
        return HttpBadRequest();
      }
      
      var todo = Todos.Find(id);
      if (todo == null)
      {
        return HttpNotFound();
      }
      
      Todos.Update(item);
      return new NoContentResult();
    }
  }
}