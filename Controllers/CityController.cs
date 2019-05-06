using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
  public class CityController : Controller
  {
    [HttpGet("/city")]
    public ActionResult IndexCity()
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
  }
}
