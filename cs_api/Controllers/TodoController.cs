using cs_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cs_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> items = new List<TodoItem>()
        {
            new TodoItem { Id = 1, Name = @"ミントティーを飲む", IsDone = false, },
            new TodoItem { Id = 2, Name = @"紅茶を飲む", IsDone = true, },
            new TodoItem { Id = 3, Name = @"ハーブティーを飲む", IsDone = false, },
        };

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll() => items;

        [HttpGet("{id}", Name = "Todo")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null) return NotFound();
            return item;
        }
    }
}
