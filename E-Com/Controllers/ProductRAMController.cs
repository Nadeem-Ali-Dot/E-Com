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
    public class ProductRAMController : ControllerBase
    {

        private readonly IGeneric<ProductRAM> _Cat;
        ResponseMassage response = new ResponseMassage();
        public ProductRAMController( IGeneric<ProductRAM> cat) { 
        
            _Cat = cat;
        
        }
        #region ProductRAM 
        [HttpPost]
        public async Task<ResponseMassage> AddProductRAM([FromForm] ProductRAM Cate)
        {

            var record = new ProductRAM
            {
                Name = Cate.Name,
             
                

            };
            bool n= await _Cat.Add(record);
            

            if (n)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Sub Categroy Save Successfully";
                response.Data = null;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Sub Categroy Not Save";
                response.Data = null;
            }

            return response;
        }

        [HttpDelete]
        public async Task<ResponseMassage> DeleteProductRAM(int Id)
        {
            
                
               bool n= await _Cat.Delete(Id);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Sub Category Deleted";


                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Sub Category Not Delete";
                }
         
            return response;




        }

        [HttpGet]
        public async Task<ResponseMassage> GetAllProductRAM()
        {
            
             var data= await _Cat.GetAll();
            if (data.Count > 0)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Category List";
                response.Data = data;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Category Not Found";
                response.Data = null;
            }

            return response;

        }

        [HttpPut]
        public async Task<ResponseMassage> UpdateProductRAM([FromForm] ProductRAM cat)
        {
            var data = await _Cat.GetSingle(cat.Id);
            if (data != null)
            {
                data.Name = cat.Name;
            
               bool n= await _Cat.Update(data);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Sub Category Updated";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Sub Category Not Updated";
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Sub Category Not Found";
            }
            return response;

        }


        #endregion


    }
}
