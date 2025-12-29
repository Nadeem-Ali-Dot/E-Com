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
    public class ProductWeightController : ControllerBase
    {

        private readonly IGeneric<ProductWeight> _Cat;
        ResponseMassage response = new ResponseMassage();
        public ProductWeightController( IGeneric<ProductWeight> cat) { 
        
            _Cat = cat;
        
        }
        #region ProductWeight 
        [HttpPost]
        public async Task<ResponseMassage> AddProductWeight([FromForm] ProductWeight Cate)
        {

            var record = new ProductWeight
            {
                Name = Cate.Name,
             
                

            };
            bool n= await _Cat.Add(record);
            

            if (n)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Product Weight Save Successfully";
                response.Data = null;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Product Weight Not Save";
                response.Data = null;
            }

            return response;
        }

        [HttpDelete]
        public async Task<ResponseMassage> DeleteProductWeight(int Id)
        {
            
                
               bool n= await _Cat.Delete(Id);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Product Weight Deleted";


                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Product Weight Not Delete";
                }
         
            return response;




        }

        [HttpGet]
        public async Task<ResponseMassage> GetAllProductWeight()
        {
            
             var data= await _Cat.GetAll();
            if (data.Count > 0)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "ProductWeight List";
                response.Data = data;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "ProductWeight Not Found";
                response.Data = null;
            }

            return response;

        }

        [HttpPut]
        public async Task<ResponseMassage> UpdateProductWeight([FromForm] ProductWeight cat)
        {
            var data = await _Cat.GetSingle(cat.Id);
            if (data != null)
            {
                data.Name = cat.Name;
            
               bool n= await _Cat.Update(data);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Product Weight Updated";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Product Weight Not Updated";
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Product Weight Not Found";
            }
            return response;

        }


        #endregion


    }
}
