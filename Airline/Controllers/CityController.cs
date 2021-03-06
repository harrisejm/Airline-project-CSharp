using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Airport.Models;

namespace Airport.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet("/cities")]
        public ActionResult Index()
        {
          List<City> allCities = City.GetAll();

          return View(allCities);
        }

       [HttpGet("/cities/new")]
        public ActionResult CreateForm()
        {

          return View();
        }

        [HttpPost("/cities")]
        public ActionResult Create()
        {
          City newCity = new City(Request.Form["new-city"], Request.Form["new-state"]);
          newCity.Save();
          List<City> allCity = City.GetAll();
          return View("Index", allCity);
      }

      [HttpGet("/flights/new")]
      public ActionResult CreateFlight()
      {
        return View();
      }

      [HttpPost("/flights")]
      public ActionResult CreateFFF()
      {
        Flight newFlight = new Flight(int.Parse(Request.Form["new-flight-number"]), Request.Form["new-depart-time"], int.Parse(Request.Form["new-depart-id"]), int.Parse(Request.Form["new-arrive-id"]), Request.Form["new-status"]);
        newFlight.Save();
        List<Flight> allFlights = Flight.GetAll();
        return View("flights", allFlights);
    }

    [HttpGet("/flights/{id}/all")]
    public ActionResult flights(int id)
    {
    //  List<Flight> allFlight = Flight.GetAll();
      return View(Flight.FindFlightsByCity(id));

    }

  //   [HttpGet("/flights/{id}/all")]
  //   public ActionResult CreateFlightsByCity()
  //   {
  //
  // }



    }
}
