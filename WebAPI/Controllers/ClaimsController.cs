using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        IUserOperationClaimService _uocService;
        IOperationClaimService _ocService;
        public ClaimsController(IUserOperationClaimService uocService, IOperationClaimService ocService)
        {
            _uocService = uocService;
            _ocService = ocService;
        }

        [HttpGet("getdetail")]
        public IActionResult GetDetail()
        {
            var result = _uocService.GetAllDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuocbyuserid")]
        public IActionResult GetUOCByUserId(int id)
        {
            var result = _uocService.GetDetailByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim entity)
        {
            var result = _uocService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UserOperationClaim entity)
        {
            var result = _uocService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallclaimsforallusers")]
        public IActionResult GetAllClaimsForAllUser()
        {
            var result = _uocService.GetAllClaimsForAllUser();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result = _uocService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getoperationclaims")]
        public IActionResult GetOperationClaims()
        {
            var result = _ocService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailbyuserid")]
        public IActionResult GetDetailByUserId(int id)
        {
            var result = _uocService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
