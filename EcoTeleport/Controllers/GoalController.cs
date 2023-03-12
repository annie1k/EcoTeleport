using EcoTeleport.Interfaces;
using EcoTeleport.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcoTeleport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalRepository _goalRepository;

        public GoalController(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Goal>))]
        public IActionResult GetGoals()
        {
            var goals = _goalRepository.GetGoals();

            if (!goals.Any())
            {
                return NoContent();
            }

            return Ok(goals);
        }

        [HttpGet("{goalId}", Name = "GetGoalById")]
        [ProducesResponseType(200, Type = typeof(Goal))]
        [ProducesResponseType(404)]
        public IActionResult GetGoalById(Guid goalId)
        {
            var goal = _goalRepository.GetGoalById(goalId);

            if (goal == null)
            {
                return NotFound();
            }

            return Ok(goal);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Goal))]
        [ProducesResponseType(400)]
        public IActionResult AddGoal([FromBody] Goal goal)
        {
            if (goal == null)
            {
                return BadRequest();
            }

            _goalRepository.AddGoal(goal);

            return CreatedAtRoute("GetGoalById", new { goalId = goal.goal_uuid }, goal);
        }

        [HttpPut("{goalId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGoal(Guid goalId, [FromBody] Goal goal)
        {
            if (goal == null || goal.goal_uuid != goalId)
            {
                return BadRequest();
            }

            var existingGoal = _goalRepository.GetGoalById(goalId);

            if (existingGoal == null)
            {
                return NotFound();
            }

            _goalRepository.UpdateGoal(goal);

            return NoContent();
        }

        [HttpDelete("{goalId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGoal(Guid goalId)
        {
            var goal = _goalRepository.GetGoalById(goalId);

            if (goal == null)
            {
                return NotFound();
            }

            _goalRepository.DeleteGoal(goal);

            return NoContent();
        }
    }
}
