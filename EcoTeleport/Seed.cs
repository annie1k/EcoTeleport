using EcoTeleport.Data;
using EcoTeleport.Model;
using Route = EcoTeleport.Model.Route;

namespace EcoTeleport
{
    public class Seed
{
    private readonly DataContext dataContext;

    public Seed(DataContext context)
    {
        this.dataContext = context;
    }

    public void SeedDataContext()
    {
        Console.WriteLine("in seedDataContext");
        
        // if (!dataContext.Routes.Count() <= 0)
        // {
        //     Console.WriteLine("no routes");
        // })        
        
        if (!dataContext.Routes.Any())
        {
            Console.WriteLine("no routes");

            var routes = new List<Route>()
            {
                new Route()
                {
                    departure_time = new DateTime(2023, 3, 15, 10, 0, 0, DateTimeKind.Utc),
                    arrival_time = new DateTime(2023, 3, 15, 12, 0, 0, DateTimeKind.Utc),
                    origin = "New York",
                    destination = "Boston",
                    footprint = 100.0,
                    transportation_mode = TransportationMode.Car,
                    GoalRoutes = new List<GoalRoute>()
                    {
                        new GoalRoute { goal_uuid = Guid.NewGuid() }
                    },
                    UserRoutes = new List<UserRoute>()
                    {
                        new UserRoute { user_uuid = Guid.NewGuid() }
                    }
                },
                new Route()
                {
                    departure_time = new DateTime(2023, 3, 16, 14, 0, 0, DateTimeKind.Utc),
                    arrival_time = new DateTime(2023, 3, 16, 16, 0, 0, DateTimeKind.Utc),
                    origin = "Boston",
                    destination = "Washington D.C.",
                    footprint = 200.0,
                    transportation_mode = TransportationMode.Plane,
                    GoalRoutes = new List<GoalRoute>()
                    {
                        new GoalRoute { goal_uuid = Guid.NewGuid() }
                    },
                    UserRoutes = new List<UserRoute>()
                    {
                        new UserRoute { user_uuid = Guid.NewGuid() }
                    }
                }
            };

            dataContext.Routes.AddRange(routes);
            dataContext.SaveChanges();
        }
    }
}

}