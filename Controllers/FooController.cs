using dotnet_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace dotnet_api.Controllers
{
  [Route("api/[controller]")]
  public class FooController : Controller
  {
    static List<Foo> foos = new List<Foo>();
    static int nextId = 1;

    //Get: api/foo
    [HttpGet]
    public IEnumerable<Foo> Get()
    {
      return foos;
    }

    //Get: api/foo/{name}
    [HttpGet("{name}")]
    public IEnumerable<Foo> Insert(string name)
    {
      foos.Add(new Foo { id = nextId, name = name });
      nextId++;
      return foos;
    }
  }
}
