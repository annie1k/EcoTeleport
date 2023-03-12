using EcoTeleport.Data;
using EcoTeleport.Interfaces;
using EcoTeleport.Model;

namespace EcoTeleport.Repository
{
    public class GoalRepository : IGoalRepository
    {
        private readonly DataContext _context;

        public GoalRepository(DataContext context)
        {
            _context = context;
        }

        public void AddGoal(Goal goal)
        {
            _context.Goals.Add(goal);
            _context.SaveChanges();
        }

        public ICollection<Goal> GetGoals()
        {
            return _context.Goals.ToList();
        }

        public Goal GetGoalById(Guid goalId)
        {
            return _context.Goals.FirstOrDefault(g => g.goal_uuid == goalId);
        }

        public void UpdateGoal(Goal goal)
        {
            _context.Goals.Update(goal);
            _context.SaveChanges();
        }

        public void DeleteGoal(Goal goal)
        {
            _context.Goals.Remove(goal);
            _context.SaveChanges();
        }
    }

}