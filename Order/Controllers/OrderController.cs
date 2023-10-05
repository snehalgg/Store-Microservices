using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Model;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        DataContext _dataContext = new DataContext();
        
        [HttpGet]
        public IEnumerable<OrderDetailsModel> Get()
        {

            return _dataContext.GetAllOrderDetailsModel();
        }


// GET api/<StudentAttendanceController>/5
        [HttpGet("{id}")]
        public OrderDetailsModel Get(int id)
        {
            return _dataContext.GetAllOrderDetailsModel().FirstOrDefault(x => x.OrderId == id);
        }



       
        [HttpPost]
        public void Post([FromBody] OrderDetailsModel sm)
        {
            _dataContext.AddOrderDetailsModel(sm);
        }



       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDetailsModel sm)
        {
            _dataContext.UpdateOrderDetailsModel(id, sm);
        }



        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataContext.DeleteOrderDetailsModel(id);
        }
    }
}