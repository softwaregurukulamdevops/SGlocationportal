using LocationPortel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public LocationController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetLocationDetails")]
        public List<Location> GetLocationDetails()
        {
            List<Location> lstLocation = new List<Location>();
            try
            {
                lstLocation = trainingDBContext.Location.ToList();
                return lstLocation;
            }
            catch (Exception ex)
            {
                lstLocation = new List<Location>();
                return lstLocation;
            }
        }
        [HttpPost("AddLocation")]
        public string AddLocation(Location location)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(location.LocationName))
                {
                    trainingDBContext.Add(location);
                    trainingDBContext.SaveChanges();
                    message = "Location added successfully";
                }
                else
                    message = "Location Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
