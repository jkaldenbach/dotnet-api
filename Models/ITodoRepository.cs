using System.Collections.Generic;

namespace dotnet_api.Models
{
  public interface ITodoRepository
  {
    void Add(Todo item);
    IEnumerable<Todo> GetAll();
    Todo Find(string id);
    Todo Remove(string id);
    void Update(Todo item);
  }
}