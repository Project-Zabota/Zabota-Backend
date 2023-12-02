using Microsoft.AspNetCore.Mvc;
using Zabota.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zabota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppContext _db;

        public ValuesController(AppContext db)
        {
            _db = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Instruction> Get()
        {
            return _db.Instructions.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            Instruction? instruction = _db.Instructions.FirstOrDefault(x => x.Id == id);

            if (instruction == null) return Results.NotFound(new { message = "Инструкция не найден" });

            return Results.Json(instruction);
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
