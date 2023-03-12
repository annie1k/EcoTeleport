using EcoTeleport.Data;
using EcoTeleport.Interfaces;
using Route = EcoTeleport.Model.Route;

namespace EcoTeleport.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly DataContext _context;
        private IRouteRepository _routeRepositoryImplementation;

        public RouteRepository(DataContext context)
        {
            _context = context;
        }

        public void AddRoute(Route route)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
        }

        public void DeleteRoute(Route route)
        {
            var contextRoute = _context.Routes.FirstOrDefault(r => r.route_uuid == route.route_uuid);
            if (contextRoute != null)
            {
                _context.Routes.Remove(contextRoute);
                _context.SaveChanges();
            }
        }

        public ICollection<Route> GetAllRoutes()
        {
            return _context.Routes.ToList();
        }

        public Route GetRouteById(Guid id)
        {
            return _context.Routes.FirstOrDefault(r => r.route_uuid == id);
        }
        
        public ICollection<Route> GetRoutesByUserId(Guid userId)
        {
            var query = _context.Routes.AsQueryable();

            query = query.Where(r => GetAllRoutes().Any(ur => ur.User.user_uuid == userId));

            return query.ToList();
        }

        public ICollection<Route> GetRoutesByGoalId(Guid goalId)
        {
            var query = _context.Routes.AsQueryable();

            query = query.Where(r => GetAllRoutes().Any(ur => ur.Goal.goal_uuid == goalId));

            return query.ToList();
        }

        public void UpdateRoute(Route route)
        {
            _context.Routes.Update(route);
            _context.SaveChanges();
        }
    }
}