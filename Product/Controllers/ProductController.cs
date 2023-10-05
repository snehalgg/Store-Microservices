using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Model;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DataContext _dataContext = new DataContext();
        
        [HttpGet]
        public IEnumerable<ProductDetailsModel> Get()
        {

            return _dataContext.GetAllProductDetailsModel();
        }



        [HttpGet("{id}")]
        public ProductDetailsModel Get(int id)
        {
            return _dataContext.GetAllProductDetailsModel().FirstOrDefault(x => x.ProductId == id);
        }



       
        [HttpPost]
        public void Post([FromBody] ProductDetailsModel sm)
        {
            _dataContext.AddProductDetailsModel(sm);
        }



       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDetailsModel sm)
        {
            _dataContext.UpdateProductDetailsModel(id, sm);
        }



        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataContext.DeleteProductDetailsModel(id);
        }
    }
}