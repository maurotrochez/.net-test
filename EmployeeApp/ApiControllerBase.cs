using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System;
using System.Linq;

namespace EmployeeApp
{
    public class ApiControllerBase : Controller
    {
        protected ApiResponse apiResponse;

        public ApiControllerBase()
        {

            apiResponse = new ApiResponse();
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("HandleSuccessResponse")]
        public IActionResult HandleSuccessResponse(object result)
        {
            apiResponse.Content = result;
            return Ok(apiResponse);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("HandleErrorResponse")]
        public IActionResult HandleErrorResponse(Exception ex)
        {
            apiResponse.Success = false;
            if (ex != null && ex.Message != null)
            {
                apiResponse.ErrorList.Add(ex.Message);
            }
            return BadRequest(apiResponse);
        }

    }
}
