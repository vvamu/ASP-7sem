using Microsoft.AspNetCore.Mvc;

namespace lab2b.Controllers;

public class TMResearchController : Controller
{
    //[HttpGet("/MResearch/M01/{id?}")]
    [HttpGet]
    public IActionResult M01(string id = "")
    {
        var controller = RouteData.Values["controller"].ToString();
        var action = RouteData.Values["action"].ToString();


        return Ok($"GET:M01 {id}");
    }

    //[HttpGet("/V2/MResearch/M02")]
    [HttpGet]
    public IActionResult M02()
    {
        return Ok("GET:M02");
    }

    //[HttpGet("/V3/MResearch/string/M03")]
    [HttpGet]
    public IActionResult M03()
    {
        return Ok("GET:M03");
    }

    //[HttpGet("{**other}")]
    [HttpGet]
    public IActionResult MXX()
    {
        return Ok("GET:MXX");
    }
}
