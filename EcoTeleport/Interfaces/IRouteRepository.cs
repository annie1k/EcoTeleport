using Route = EcoTeleport.Model.Route;

namespace EcoTeleport.Interfaces
{
    public interface IRouteRepository
    {
        ICollection<Route> GetAllRoutes();
        Route GetRouteById(Guid id);
        void AddRoute(Route route);
        void UpdateRoute(Route route);
        void DeleteRoute(Route route);
        ICollection<Route> GetRoutesByUserId(Guid userId);
        ICollection<Route> GetRoutesByGoalId(Guid goalId);
    }
}