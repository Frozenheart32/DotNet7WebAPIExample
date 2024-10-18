using System.Security.Cryptography;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7WebAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        [HttpPost]
        [Route("ValidateToken")]
        public ActionResult ValidateToken(string token)
        {
            IJwtAlgorithm algorithm = new RS256Algorithm(GetRSA());

            var parameters = ValidationParameters.Default;
            parameters.ValidateSignature = true;
            parameters.ValidateExpirationTime = false;
            parameters.ValidateIssuedTime = false;
            parameters.TimeMargin = 100;

            try
            {
                var json = JwtBuilder.Create()
                    .WithAlgorithm(algorithm)
                    .WithValidationParameters(parameters)
                    .Decode(token);
                Console.WriteLine(json);
                return Ok(json);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private RSA GetRSA()
        {
            var rsa = RSA.Create(2048);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            rsa.ImportParameters(new RSAParameters()
            {
                Exponent = urlEncoder.Decode("AQAB"), 
                Modulus = urlEncoder.Decode("w7Fs1boJcxtErxEYD9UN4WaeDdQuM6PyMOKPwMMez6pY_A42HCA-4QaPMLHxIwjyKT_iCOAYBTsFlqKV3QSmFIPTGBAwY6h0GAD6jLv-DETQtI3MVJLIG3LV_tysnrHRkI9ayrtQwplIKexntd6MrJpg7cKtl89ioXrIIE4WL3Q5mwJWKGLGdKcsK8x31J9bcM5SekC3tRhOshoUBYl1juUh4d8qsNWNj_e5LP76DFkJ73K_DpK-L1bBXEJwpl9euHdfOJ4IjtrR1tsrl-RIevD_fUhM_rNuNR-9jgNLelvDSmwS2CP9RX8USLrRLWp1DxtzpR8UnBjWIqRKoAfX0w")
            });
            return rsa;
        }
    }
}
