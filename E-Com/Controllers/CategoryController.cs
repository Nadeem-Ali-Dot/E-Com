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
    public class CategoryController : ControllerBase
    {

        private readonly IGeneric<Category> _Cat;
        ResponseMassage response = new ResponseMassage();
        public CategoryController( IGeneric<Category> cat) { 
        
            _Cat = cat;
        
        }
        #region Category 
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromForm] CategoryDTO Cate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            string Filename = Guid.NewGuid() + Path.GetExtension(Cate.Image.FileName);
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Category");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var path = Path.Combine(uploadPath, Filename);
           

            var record = new Category
            {
                CategoryName = Cate.CategoryName,
                Color = Cate.Color,
                Image= Filename

            };
            bool n= await _Cat.Add(record);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Cate.Image.CopyToAsync(stream);
            }

            if (n)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Categroy Save Successfully";
                response.Data = null;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Categroy Not Save";
                response.Data = null;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ResponseMassage> DeleteCategroy(int Id)
        {
            
                
               bool n= await _Cat.Delete(Id);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Category Deleted";


                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Category Not Delete";
                }
         
            return response;




        }

        [HttpGet]
        public async Task<ResponseMassage> GetAllCategory()
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
        public async Task<ResponseMassage> UpdateCategory([FromForm] CategoryUpdateDTO cat)
        {
            var data = await _Cat.GetSingle(cat.Id);
            if (data != null)
            {
                data.CategoryName = cat.name;
               bool n= await _Cat.Update(data);
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Category Updated";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Category Not Updated";
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Category Not Found";
            }
            return response;

        }


        #endregion


    }
}
