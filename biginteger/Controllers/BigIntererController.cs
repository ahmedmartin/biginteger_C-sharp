using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace biginteger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BigIntererController : ControllerBase
    {


        public class max_min{

        public string Min { get; set; }
        public string Max { get; set; }

    }


        public class Result
        {

            public string addition { get; set; }
            public string subtraction { get; set; }
            public string multible { get; set; }
            public string divide { get; set; }

        }



        [HttpPost]
        public IActionResult Get_operations(max_min numbers)
        {

            BigInteger min = 0 , max = 0;

            if (BigInteger.TryParse(numbers.Min, out min))
            {
                if (BigInteger.TryParse(numbers.Max, out max))
                {

                    return Ok(operations(min:min,max:max));

                }
                else
                {
                    return NotFound("max is not number");
                }

            }
            else {
                return NotFound("min is not number");
            }
            
        }



        private Result operations(BigInteger min,BigInteger max) {

            Result result = new Result();

            result.addition =  BigInteger.Add(min, max).ToString();

            result.subtraction = BigInteger.Subtract(max, min).ToString();

            result.multible = BigInteger.Multiply(min, max).ToString();

            result.divide = BigInteger.Divide(max, min).ToString();
            

            return result;
        }



    }
}