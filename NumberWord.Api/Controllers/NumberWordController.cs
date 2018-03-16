using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberWord.Api.Common;
using NumberWord.Api.Models;
using NumberWord.Core;

namespace NumberWord.Api.Controllers
{
    [Route("api/number-word")]
    public class NumberWordController : BaseController
    {
        private readonly INumberTextConverter _numberTextConverter;

        public NumberWordController(INumberTextConverter numberTextConverter)
        {
            this._numberTextConverter = numberTextConverter;
        }

        [Route("")]
        [HttpGet]
        public string Index()
        {
            return "Welcome!";
        }

        [Route("number-to-word")]
        [HttpPost]
        public IActionResult NumberToWord([FromBody]MyNumber number)
        {
            if (string.IsNullOrWhiteSpace(number.Number))
            {
                return BadResult("Please provide a valid number that larger than 0.");
            }

            try
            {
                var word = new Word();
                word.Text = _numberTextConverter.IntegerToWritten(number.Number);
                return OkResult(word, "Number converted");
            }
            catch (NumberTextConverterException e)
            {
                return BadResult(e.Message);
            }

            
        }

        [Route("word-to-number")]
        [HttpPost]
        public IActionResult WordToNumber([FromBody]Word word)
        {
            if (string.IsNullOrWhiteSpace(word.Text))
            {
                return BadResult("Please provide a valid number text");
            }

            try
            {
                var number = new MyNumber();
                number.Number = "" + _numberTextConverter.WrittenToInteger(word.Text);
                return OkResult(number, "Text converted");
            }
            catch (NumberTextConverterException e)
            {
                return BadResult(e.Message);
            }
        }

    }
}
