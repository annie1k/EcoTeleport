using EcoTeleport.Interfaces;
using EcoTeleport.Model;
using Microsoft.AspNetCore.Mvc;
using Route = EcoTeleport.Model.Route;
using System;

namespace EcoTeleport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;

        public RouteController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        [HttpGet]
        public IActionResult GetRoutes()
        {
            var routes = _routeRepository.GetAllRoutes();
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public IActionResult GetRouteById(Guid id)
        {
            var route = _routeRepository.GetRouteById(id);

            if (route == null)
                return NotFound();

            return Ok(route);
        }

        [HttpPost]
        public IActionResult AddRoute([FromBody] Route route)
        {
            if (route == null)
                return BadRequest();

            _routeRepository.AddRoute(route);

            return CreatedAtAction(nameof(GetRouteById), new { id = route.route_uuid }, route);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoute(Guid id, [FromBody] Route route)
        {
            var existingRoute = _routeRepository.GetRouteById(id);

            if (existingRoute == null)
                return NotFound();

            existingRoute.departure_time = route.departure_time;
            existingRoute.arrival_time = route.arrival_time;
            existingRoute.origin = route.origin;
            existingRoute.destination = route.destination;
            existingRoute.footprint = route.footprint;
            existingRoute.transportation_mode = route.transportation_mode;
            existingRoute.user_uuid = route.user_uuid;
            existingRoute.goal_uuid = route.goal_uuid;

            _routeRepository.UpdateRoute(existingRoute);

            return Ok(existingRoute);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoute(Guid id)
        {
            var route = _routeRepository.GetRouteById(id);

            if (route == null)
                return NotFound();

            _routeRepository.DeleteRoute(route);

            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetRoutesByUserId(Guid userId)
        {
            var routes = _routeRepository.GetRoutesByUserId(userId);

            if (routes == null)
                return NotFound();

            return Ok(routes);
        }

        [HttpGet("goal/{goalId}")]
        public IActionResult GetRoutesByGoalId(Guid goalId)
        {
            var routes = _routeRepository.GetRoutesByGoalId(goalId);

            if (routes == null)
                return NotFound();

            return Ok(routes);
        }
    }
}
