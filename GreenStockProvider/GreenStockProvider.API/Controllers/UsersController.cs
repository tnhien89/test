using GreenStockProvider.Models;
using GreenStockProvider.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenStockProvider.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _service;
        public UsersController(UserServices service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<UserInfo>> Get()
        {
            return _service.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ResultModel<UserInfo>> Get(string id)
        {
            var rs = new ResultModel<UserInfo>();
            try
            {
                rs.Data = _service.Get(id);
            }
            catch (Exception ex)
            {
                rs.Code = ex.HResult;
                rs.Message = ex.ToString();
            }

            return rs;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<ResultModel<UserInfo>> Create([FromForm] UserInfo user = null)
        {
            if (user == null || string.IsNullOrEmpty(user.FullName))
            {
                user = new UserInfo()
                {
                    FullName = "test",
                    LicenseType = 2,
                    Role = 3,
                    RoleName = "test",
                    LicenseTypeName = "test",
                    Status = 1,
                    StatusName = "test",
                    Type = 4,
                    TypeName = "test"
                };
            }

            var rs = new ResultModel<UserInfo>();
            try
            {
                rs.Data = _service.Create(user);
            }
            catch (Exception ex)
            {
                rs.Code = ex.HResult;
                rs.Message = ex.ToString();
            }

            return rs;
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<ResultModel<UserInfo>> Update([FromForm] UserInfo user)
        {
            //UserInfo user = new UserInfo()
            //{
            //    Id = "6119362c2a0fb6a6ca93b554",
            //    FullName = "test update",
            //    LicenseType = 21,
            //    Role = 31,
            //    RoleName = "test1",
            //    LicenseTypeName = "test1",
            //    Status = 11,
            //    StatusName = "test1",
            //    Type = 41,
            //    TypeName = "test1"
            //};

            var rs = new ResultModel<UserInfo>();
            try
            {
                rs.Data = _service.Update(user);
            }
            catch (Exception ex)
            {
                rs.Code = ex.HResult;
                rs.Message = ex.ToString();
            }

            return rs;
        }
    }
}
