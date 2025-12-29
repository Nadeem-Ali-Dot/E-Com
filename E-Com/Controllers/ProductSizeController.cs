using Azure;
using E_Com.Models;
using E_Com.Models.DTOs;
using E_Com.Models.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Com.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductSizeController : ControllerBase
    {

        private readonly IGeneric<ProductSize> _Cat;
        ResponseMassage response = new ResponseMassage();
        public ProductSizeController( IGeneric<ProductSize> cat) { 
        
            _Cat = cat;
        
        }
        #region ProductSize 
        [HttpPost]
        public async Task<ActionResult> AddProductSize([FromForm] ProductSize Cate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = new ProductSize
            {
                Name = Cate.Name,
                            

            };
            bool n= await _Cat.Add(record);
            

            if (n)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "ProductSize Save Successfully";
                response.Data = null;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "ProductSize Not Save";
                response.Data = null;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ResponseMassage> DeleteProductSize(int Id)
        {
            
                
               bool n= await _Cat.Delete(Id);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "ProductSize Deleted";


                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "ProductSize Not Delete";
                }
         
            return response;




        }

        [HttpGet]
        public async Task<ResponseMassage> GetAllProductSize()
        {
            
             var data= await _Cat.GetAll();
            if (data.Count > 0)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "ProductSize List";
                response.Data = data;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "ProductSize Not Found";
                response.Data = null;
            }

            return response;

        }

        [HttpPut]
        public async Task<ResponseMassage> UpdateProductSize([FromForm] ProductSize cat)
        {
            var data = await _Cat.GetSingle(cat.Id);
            if (data != null)
            {
                data.Name = cat.Name;
            
               bool n= await _Cat.Update(data);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "ProductSize Updated";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "ProductSize Not Updated";
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "ProductSize Not Found";
            }
            return response;

        }


        #endregion


    }
}
