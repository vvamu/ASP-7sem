using Microsoft.AspNetCore.Mvc;

namespace lab2b.Controllers;
public class TAResearchController : Controller
{

    [HttpGet("it/{n:int}/{string}")]
    public IActionResult M04(int n, string @string)
    {
        var result = $"GET:M04: {n}/{@string}";
        return Content(result);
    }

    [Route("it/{f:float}/{string:length(2,5)}", Name = "M06")]
    [HttpGet] //ERROR 
    [HttpDelete]

    public IActionResult M06(float f, string @string)
    {
        var result = $"{Method}:M06: {f}/{@string}";
        return Content(result);
    }


    [Route("it/{b:bool}/{letters:regex(^[[a-zA-Z]]+$)}:length(2,5)", Name = "M05")]
    [HttpGet] //ERROR
    [HttpPost]
    public IActionResult M05(bool b, string letters)
    {
        var result = $"XXX:M05: {b}/{letters}";
        return Content(result);
    }


    [HttpPut("it/{letters:length(3,4)}/{n:int:range(100,200)}")]
    public IActionResult M07(string letters, int n)
    {
        if (letters.Length >= 3 && letters.Length <= 4 && n >= 100 && n <= 200)
        {
            var result = $"PUT:M07: {letters}/{n}";
            return Content(result);
        }
        return BadRequest("Invalid input.");
    }

    [HttpPost(@"{mail:regex(^\S+@\S+\.\S+$)}")]
    public IActionResult M08(string mail)
    {
        var result = $"POST:M08: {mail}";
        return Content(result);
    }
}