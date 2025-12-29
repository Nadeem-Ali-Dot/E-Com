using Azure;
using E_Com.Models.DTOs;
using E_Com.Models.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_Com.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IGeneric<Users> _User;
        ResponseMassage response = new ResponseMassage();

        public UserController(IGeneric<Users> _db)
        {

            _User = _db;
            
        }

        [HttpPost]
        public async Task<ResponseMassage> AddUser([FromForm] UserDTOs user)
        {
            if (!ModelState.IsValid)
                return response;


            var record = new Users
            {
                Name = user.Name,
                Email = user.Email,
                Passowrd = user.Passowrd,
                CreateAt = DateTime.Now,
                Role = user.Role

            };
          bool n=  await _User.Add(record);
            

            if (!n)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Failed To Save";
                response.Data = null;

            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "User Save Successfully";
                response.Data = null;
            }


            return response;
        }

        [HttpPut]

        public async Task<ResponseMassage> UpdateUser([FromForm] UserUpdateDTOs obj)
        {
            var data = await _User.GetSingle(obj.Id);
            if (data is not null)
            {

                var recrod = new Users
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Email = obj.Email,
                    Passowrd = obj.Passowrd,
                    Role = obj.Role
                };

               bool n=await _User.Update(recrod);
               
                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "User Updated successfully";
                    response.Data = null;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.Conflict;
                    response.Message = "User Not Updated";
                    response.Data = null;
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "User Not Found";
                response.Data = null;
            }

            return response;

        }

        [HttpGet]
        public async Task<ResponseMassage> GetUserAll()
        {

            var data = await _User.GetAll();

            if (data.Count == 0)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "No Data Found";
                response.Data = null;

            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "User List";
                response.Data = data;
            }


            return response;
        }

        [HttpGet]
        public async Task<ResponseMassage> GetSingleUser(int Id)
        {
            var data = await _User.GetSingle(Id);
            if (data is not null)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "User Details";
                response.Data = data;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "User Details Not Exists";

            }
            return response;
        }

        [HttpDelete]
        public async Task<ResponseMassage> UserDelete(int Id)
        {
            bool n = await _User.Delete(Id);
            if (n)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "User Deleted Successfully";

            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "User Not Deleted";
            }
            return response;
        }



    }
}
