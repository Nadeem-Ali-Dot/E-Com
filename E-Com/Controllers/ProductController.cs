using E_Com.Models;
using E_Com.Models.DTOs;
using E_Com.Models.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace E_Com.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGeneric<Products> _Pro;
        ResponseMassage response = new ResponseMassage();
        public ProductController(IGeneric<Products> generic)
        {
            _Pro=generic;

        }
        [HttpGet]
        public async Task<ResponseMassage> GetAllProduct()
        {
            var data = await _Pro.GetAll();
            if(data == null)
            {
                response.StatusCode=HttpStatusCode.BadRequest;
                response.Message= "Not Found";
                response.Data = null;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Product List";
                response.Data = data;

            }


                return response;
        }

        [HttpGet]
        public async Task<ResponseMassage> GetProduct(int Id)
        {
            var data = await _Pro.GetSingle(Id);
            if (data == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Not Found";
                response.Data = null;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Product List";
                response.Data = data;

            }


            return response;
        }


        [HttpPost]
        public async Task<ResponseMassage> AddProduct([FromForm] ProductsDTO Pro)
        {

            var record = new Products
            {
                ProductName = Pro.title,
                Description = Pro.description,
                Price = Pro.price,
                stock = Pro.stock,
                categoryId = Pro.categoryId,
                CreateAt = DateTime.Now,
                ProductImages = null
            };
           bool n= await _Pro.Add(record);

            if (n) {
            
                response.StatusCode=HttpStatusCode.OK;
                response.Message = "Product Add Successfully";
                response.Data = null;
            
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Product Not Add";
                response.Data = null;
            }


                return response;
        }

        [HttpDelete]
        public async Task<ResponseMassage> DeleteProduct(int Id)
        {
            bool n =await _Pro.Delete(Id);
            if (n)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Product Deleted Successfully";

            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Product Not Deleted";
            }
            return response;
        }
    }
}
