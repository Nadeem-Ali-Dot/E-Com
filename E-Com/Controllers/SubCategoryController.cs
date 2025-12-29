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
    public class SubCategoryController : ControllerBase
    {

        private readonly IGeneric<SubCategory> _Cat;
        ResponseMassage response = new ResponseMassage();
        public SubCategoryController( IGeneric<SubCategory> cat) { 
        
            _Cat = cat;
        
        }
        #region Category 
        [HttpPost]
        public async Task<IActionResult> AddSubCategory([FromForm] SubCategoryDto Cate)
        {

            var record = new SubCategory
            {
                SubCategoryName = Cate.SubCategoryName,
                CategoryId = Cate.CategoryId
                

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

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ResponseMassage> DeleteSubCategroy(int Id)
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
        public async Task<ResponseMassage> GetAllSubCategory()
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
        public async Task<ResponseMassage> UpdateSubCategory([FromForm] SubCategoryDto cat)
        {
            //var data = await _Cat.GetSingle(cat.id);
            //if (data != null)
            //{
            //    data.SubCategoryName = cat.SubCategoryName;
            //    data.CategoryId = cat.CategoryId;
            //   bool n= await _Cat.Update(data);
            //    if (n)
            //    {
            //        response.StatusCode = HttpStatusCode.OK;
            //        response.Message = "Sub Category Updated";
            //    }
            //    else
            //    {
            //        response.StatusCode = HttpStatusCode.BadRequest;
            //        response.Message = "Sub Category Not Updated";
            //    }
            //}
            //else
            //{
            //    response.StatusCode = HttpStatusCode.NotFound;
            //    response.Message = "Sub Category Not Found";
            //}
            return response;

        }


        #endregion


    }
}
