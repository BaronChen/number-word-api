using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NumberWord.Api.Common
{
    public class BaseController: Controller
    {
        protected IActionResult BadResult(string error)
        {
            var response = new StandardResponse<object>();

            response.Errors.Add(error);

            return BadRequest(response);
        }

        protected IActionResult BadResult(List<string> errors)
        {
            var response = new StandardResponse<object>();

            response.Errors.AddRange(errors);

            return BadRequest(response);
        }

        protected IActionResult OkResult<T>(T data, string message)
        {
            var response = new StandardResponse<T>();

            response.Messages.Add(message);

            response.Data = data;

            return Ok(response);

        }
    }
}
