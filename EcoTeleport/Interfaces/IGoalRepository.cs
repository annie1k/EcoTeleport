using EcoTeleport.Model;

namespace EcoTeleport.Interfaces
{
    public interface IGoalRepository
    {
        ICollection<Goal> GetGoals();
        void AddGoal(Goal goal);
        Goal GetGoalById(Guid goalId);
        void UpdateGoal(Goal goal);
        void DeleteGoal(Goal goal);
    }
}