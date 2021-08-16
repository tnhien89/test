using GreenStockProvider.Models;
using GreenStockProvider.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenStockProvider.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppConfigController : ControllerBase
    {
        private readonly AppConfigService _service;
        public AppConfigController(AppConfigService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ResultModel<List<AppConfigModel>>> Index()
        {
            ResultModel<List<AppConfigModel>> rs = new ResultModel<List<AppConfigModel>>() {
                Data = _service.Get()
            };

            return rs;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ResultModel<AppConfigModel>> Index(string id)
        {
            ResultModel<AppConfigModel> rs = new ResultModel<AppConfigModel>();
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
        public ActionResult<ResultModel<AppConfigModel>> Create([FromForm] AppConfigModel model = null)
        {
            var rs = new ResultModel<AppConfigModel>();
            if (model == null)
            {
                model = new AppConfigModel();
            }

            try
            {
                rs.Data = _service.Create(model);
            }
            catch (Exception ex)
            {
                rs.Code = ex.HResult;
                rs.Message = ex.ToString();
            }

            return rs;
        }

        [HttpGet]
        [Route("{id}/strategies")]
        public ActionResult<ResultModel<List<Strategy>>> GetStrategies(string id)
        {
            var rs = new ResultModel<List<Strategy>>();
            try
            {
                rs.Data = _service.GetStrategies(id);
            }
            catch (Exception ex)
            {
                rs.Code = ex.HResult;
                rs.Message = ex.ToString();
            }

            return rs;
        }

        [HttpPost]
        [Route("{id}/strategies")]
        public ActionResult<ResultModel<int>> Update([FromRoute] string id, [FromForm] List<Strategy> strategies = null)
        {
            var rs = new ResultModel<int>();
            if (strategies == null || strategies.Count == 0)
            {
                strategies = new();
                strategies.Add(new Strategy());
            }

            try
            {
                rs.Data = _service.UpdateStrategies(id, strategies);
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
