using Azure;
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
    public class OrderController : ControllerBase
    {
        private readonly IGeneric<Orders> _order;
        ResponseMassage response = new ResponseMassage();
        public OrderController(IGeneric<Orders> ord) {
        _order = ord;
        
        }

        [HttpPost]
        public async Task<ResponseMassage> AddOrder([FromForm] OrdersDTOs orders)
        {
            if (!ModelState.IsValid)
                return response;


            var record = new Orders
            {
                userId = orders.userId,
                totalAmount = orders.totalAmount,
                paymentid = orders.paymentid,
                orderDate = DateTime.Now,
                status="Pendding",
               

            };
            bool n = await _order.Add(record);


            if (!n)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Failed To Save";
                response.Data = null;

            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Order Save Successfully";
                response.Data = null;
            }


            return response;
        }

        [HttpPut]

        public async Task<ResponseMassage> UpdateOrder([FromForm] OrderDTO obj)
        {
            var data = await _order.GetSingle(obj.Id);
            if (data is not null)
            {

                var recrod = new Orders
                {
                    Id = obj.Id,
                    userId = obj.userId,
                    totalAmount = obj.totalAmount,
                    status = obj.status,
                    user = obj.user
                };

                bool n = await _order.Update(recrod);

                if (n)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Order Updated successfully";
                    response.Data = null;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.Conflict;
                    response.Message = "Order Not Updated";
                    response.Data = null;
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Order Not Found";
                response.Data = null;
            }

            return response;

        }

        [HttpGet]
        public async Task<ResponseMassage> GetOrderAll()
        {

            var data = await _order.GetAll();

            if (data.Count == 0)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "No Data Found";
                response.Data = null;

            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Order List";
                response.Data = data;
            }


            return response;
        }

        [HttpGet]
        public async Task<ResponseMassage> GetSingleOrder(int Id)
        {
            var data = await _order.GetSingle(Id);
            if (data is not null)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Order Details";
                response.Data = data;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Order Details Not Exists";

            }
            return response;
        }

        [HttpDelete]
        public async Task<ResponseMassage> OrderDelete(int Id)
        {
            bool n = await _order.Delete(Id);
            if (n)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Message = "Order Deleted Successfully";

            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = "Order Not Deleted";
            }
            return response;
        }



    }
}
