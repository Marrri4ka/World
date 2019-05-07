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


    [HttpPost("/sortascending")]
    public ActionResult IndexASCCity()
    {
      List<City> allCitiesAscending = City.SortAscending();
      return View("IndexCity",allCitiesAscending);
    }


    [HttpPost("/sortdescending")]
    public ActionResult IndexMyDESCCity()
    {
      List<City> allCitiesDescending = City.SortDescending();
      return View("IndexCity",allCitiesDescending);
    }

    [HttpGet("/country")]
    public ActionResult IndexCountry()
    {
      List<Country> allCountries= Country.GetAll();
      return View(allCountries);
    }

    [HttpPost("/continentFilter")]
    public ActionResult IndexMyCountry(string continent)
    {
      List<Country> allContinents= Country.GetAllContinents(continent);
      return View("IndexCountry",allContinents);
    }



  }
}
