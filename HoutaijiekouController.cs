using Microsoft.AspNetCore.Mvc;
using System.Text.Json;




[ApiController]
[Route("api/[controller]")]
public class HoutaijiekouController : ControllerBase {
    [HttpPost("endpoint")]
    public IActionResult ReceiveJson([FromBody] YourModel model) {

        Console.WriteLine($"Received: Name={model?.zhanghao ?? "null"}, Age={model?.mima}");
        if (model == null) {
            return BadRequest("Invalid data.");
        } else{ 
            string jsonString1 = JsonSerializer.Serialize(model);
            Console.WriteLine(jsonString1);
            var jsonString2 = System.IO.File.ReadAllText("zhanghao.json");
            jsonString2=jsonString2.Replace("[", "");
            jsonString2=jsonString2.Replace("]", "");
            //Console.WriteLine(jsonString2);
            //Console.WriteLine(jsonString2 is String);
            if (jsonString2.Contains(model.zhanghao)) {
                return Ok(1);
            } else {
                using (var writer = System.IO.File.CreateText("zhanghao.json")) {
                    writer.Write("[" + jsonString1 + ',' + jsonString2 + "]");
                }
            }

            

        }

        return Ok(new { message = "Data received", data = model });
    }
    //[HttpGet("endpoint")]
    //public IActionResult TestEndpoint() {
    //    return Ok("路由存在！");
    //}
}

public class YourModel {
    public string zhanghao { get; set; }
    public int mima { get; set; }
}


