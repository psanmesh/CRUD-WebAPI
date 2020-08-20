using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AssignmentAPI.Models;
using AssignmentAPI.Resource;
using DBM = AssignmentDataLayer;

namespace AssignmentAPI.Controllers
{
    [RoutePrefix("api/Assignment")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("ProductList")]
        [ResponseType(typeof(List<ProductModel>))]
        public IHttpActionResult GetProductList()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBM.DBManager dBManager = new DBM.DBManager();
                    List<ProductModel> productList = new List<ProductModel>();
                    DataTable dt = dBManager.GetProductList();
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ProductModel item = new ProductModel();                            
                            item.ID = Convert.ToInt32(row["ID"]);
                            item.Name = Convert.ToString(row["Name"]);
                            item.MRP = Convert.ToDecimal(row["MRP"]);
                            item.Code = Convert.ToString(row["Code"]);
                            item.Status = Convert.ToInt32(row["Status"]);
                            productList.Add(item);
                        }
                    }
                    if (productList.Count != 0)
                    {
                        return Ok(productList);
                    }
                    else
                    {
                        return BadRequest(AssignmentResource.InvalidData);
                    }
                }
                else
                {
                    return BadRequest(AssignmentResource.InvalidData);
                }

            }
            catch (HttpException)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(AssignmentResource.FetchErrorMessage),
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                throw new HttpResponseException(message);
            }
            catch (Exception)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(AssignmentResource.InternalServerError),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(message);
            }
        }

        [HttpGet]
        [Route("ProductOrderList")]
        [ResponseType(typeof(List<ProductOrderModel>))]
        public IHttpActionResult GetProductOrderList()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBM.DBManager dBManager = new DBM.DBManager();
                    List<ProductOrderModel> orderList = new List<ProductOrderModel>();
                    DataTable dt = dBManager.GetProductOrderList();
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ProductOrderModel item = new ProductOrderModel();
                            item.ID = Convert.ToInt32(row["ID"]);
                            item.ProductName = Convert.ToString(row["ProductName"]);
                            item.ProductID = Convert.ToInt32(row["ProductID"]);
                            item.QTY = Convert.ToInt32(row["QTY"]);
                            item.MRP = Convert.ToDecimal(row["MRP"]);
                            item.Amount = Convert.ToDecimal(row["Amount"]);
                            item.DiscountAmount = Convert.ToDecimal(row["Discount"]);
                            item.PayableAmount = Convert.ToDecimal(row["PayableAmount"]);
                            item.ModeName = Convert.ToString(row["Mode"]);
                            orderList.Add(item);
                        }
                    }
                    if (orderList.Count != 0)
                    {
                        return Ok(orderList);
                    }
                    else
                    {
                        return BadRequest(AssignmentResource.InvalidData);
                    }
                }
                else
                {
                    return BadRequest(AssignmentResource.InvalidData);
                }

            }
            catch (HttpException)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(AssignmentResource.FetchErrorMessage),
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                throw new HttpResponseException(message);
            }
            catch (Exception)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(AssignmentResource.InternalServerError),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(message);
            }
        }


        [HttpPost]
        [Route("ProductOrderDetail")]
        [ResponseType(typeof(ProductOrderModel))]
        public IHttpActionResult ProductOrderDetail(ProductOrderModel Order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBM.DBManager dBManager = new DBM.DBManager();
                    ProductOrderModel item = new ProductOrderModel();
                    try
                    {
                        DataTable dt = dBManager.ProductOrderDetail(Order.ID);
                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                item.ID = Convert.ToInt32(row["ID"]);
                                item.ProductName = Convert.ToString(row["ProductName"]);
                                item.ProductID = Convert.ToInt32(row["ProductID"]);
                                item.QTY = Convert.ToInt32(row["QTY"]);
                                item.MRP = Convert.ToDecimal(row["MRP"]);
                                item.Amount = Convert.ToDecimal(row["Amount"]);
                                item.DiscountAmount = Convert.ToDecimal(row["Discount"]);
                                item.PayableAmount = Convert.ToDecimal(row["PayableAmount"]);
                                item.Mode = Convert.ToInt32(row["Mode"]);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }

                    if (item.ID != 0)
                    {
                        return Ok(item);
                    }
                    else
                    {
                        return BadRequest(AssignmentResource.InvalidData);
                    }
                }
                else
                {
                    return BadRequest(AssignmentResource.InvalidData);
                }

            }
            catch (HttpException)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(AssignmentResource.FetchErrorMessage),
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                throw new HttpResponseException(message);
            }
            catch (Exception)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(AssignmentResource.InternalServerError),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(message);
            }
        }

        [HttpPost]
        [Route("AddOrEditOrder")]
        [ResponseType(typeof(ResponseModel))]
        public IHttpActionResult AddOrEditOrder(ProductOrderModel Order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBM.DBManager dBManager = new DBM.DBManager();
                    ResponseModel response = new ResponseModel();
                    DataTable dt = dBManager.AddOrEditOrder(Order.ID, Order.ProductID,Order.MRP, Order.QTY, Order.Amount, Order.PayableAmount, Order.DiscountAmount,Order.Mode);
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            response.Status = Convert.ToInt32(row["Status"]);
                            response.Message = Convert.ToString(row["Message"]);
                           
                        }
                    }
                    if (response != null)
                    {
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest(AssignmentResource.InvalidData);
                    }
                }
                else
                {
                    return BadRequest(AssignmentResource.InvalidData);
                }

            }
            catch (HttpException)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(AssignmentResource.FetchErrorMessage),
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                throw new HttpResponseException(message);
            }
            catch (Exception)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(AssignmentResource.InternalServerError),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(message);
            }
        }



        [HttpPost]
        [Route("DeleteOrder")]
        [ResponseType(typeof(ResponseModel))]
        public IHttpActionResult DeleteOrder(ProductOrderModel Order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBM.DBManager dBManager = new DBM.DBManager();
                    ResponseModel response = new ResponseModel();
                    DataTable dt = dBManager.DeleteOrder(Order.ID);
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            response.Status = Convert.ToInt32(row["Status"]);
                            response.Message = Convert.ToString(row["Message"]);

                        }
                    }
                    if (response != null)
                    {
                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest(AssignmentResource.InvalidData);
                    }
                }
                else
                {
                    return BadRequest(AssignmentResource.InvalidData);
                }

            }
            catch (HttpException)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(AssignmentResource.FetchErrorMessage),
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                throw new HttpResponseException(message);
            }
            catch (Exception)
            {
                // TODO: Unhandled exception handling
                HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(AssignmentResource.InternalServerError),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(message);
            }
        }
    }
}
