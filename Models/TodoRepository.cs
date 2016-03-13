using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace dotnet_api.Models
{
  public class TodoRepository : ITodoRepository
  {
    static ConcurrentDictionary<string, Todo> _todos = new ConcurrentDictionary<string, Todo>();
    
    public TodoRepository()
    {
      Add(new Todo { task = "Do something" });
    }
    
    public IEnumerable<Todo> GetAll()
    {
      return _todos.Values;
    }
    
    public void Add(Todo item)
    {
      item.id = Guid.NewGuid().ToString();
      _todos[item.id] = item;
    }
    
    public Todo Find(string id)
    {
      Todo item;
      _todos.TryGetValue(id, out item);
      return item;
    }
    
    public Todo Remove(string id)
    {
      Todo item;
      _todos.TryGetValue(id, out item);
      _todos.TryRemove(id, out item);
      return item;
    }
    
    public void Update(Todo item)
    {
      _todos[item.id] = item;
    }
  }
}