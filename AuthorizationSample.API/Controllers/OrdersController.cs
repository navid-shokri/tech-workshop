using Microsoft.AspNetCore.Mvc;

namespace AuthorizationSample.API.Controllers;

[ApiController]
public class OrdersController : ControllerBase
{
  
    [HttpGet("api/v1/orders/{ordercode}/additionalInfo")]
    public async Task<ActionResult> getAdditionalInfo()
    {
        Console.Error.Write("ridi!!!!!");      
        return Ok(new 
        {
            
                succeeded = true,
                data = new  {
                    orderId = "f2f3c1c4-c455-46eb-8b23-2b8a0819e895",
                    Tenant =  "snappStore"
                },
            error =  (object)null
        
        });
    }

    [HttpGet("test")]
    public ActionResult test()
    {
        return Redirect("https://google.com");
    }
}