using EcoTeleport.Data;
using EcoTeleport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    if (!dataContext.Users.Any())
    {
        var users = new List<User>()
        {
            new User { user_uuid = Guid.NewGuid(), user_name = Convert.ToChar("Alice"), password = Convert.ToChar("password") },
            new User { user_uuid = Guid.NewGuid(), user_name = Convert.ToChar("Bob"), password = Convert.ToChar("password") },
            new User { user_uuid = Guid.NewGuid(), user_name = Convert.ToChar("Charlie"), password = Convert.ToChar("password") }
        };

        dataContext.Users.AddRange(users);
        dataContext.SaveChanges();
    }

    if (!dataContext.Goals.Any())
    {
        var goals = new List<Goal>()
        {
            new Goal { goal_uuid = Guid.NewGuid(), daily_goal = 1000 },
            new Goal { goal_uuid = Guid.NewGuid(), daily_goal = 2000 },
            new Goal { goal_uuid = Guid.NewGuid(), daily_goal = 3000 }
        };

        dataContext.Goals.AddRange(goals);
        dataContext.SaveChanges();
    }

    if (!dataContext.Routes.Any())
    {
        var user1 = dataContext.Users.First(u => u.user_name == 'A');
        var user2 = dataContext.Users.First(u => u.user_name == 'B');
        var user3 = dataContext.Users.First(u => u.user_name == 'C');

        var goal1 = dataContext.Goals.First(g => g.daily_goal == 1000);
        var goal2 = dataContext.Goals.First(g => g.daily_goal == 2000);
        var goal3 = dataContext.Goals.First(g => g.daily_goal == 3000);

        var routes = new List<Route>()
        {
            new Route()
            {
                route_uuid = Guid.NewGuid(),
                departure_time = new DateTime(2023, 3, 11, 12, 30, 0, DateTimeKind.Utc),
                arrival_time = new DateTime(2023, 3, 11, 13, 30, 0, DateTimeKind.Utc),
                origin = 'N',
                destination = 'B',
                footprint = 100.0,
                transportation_mode = TransportationMode.Car,
                user_uuid = user1.user_uuid,
                goal_uuid = goal1.goal_uuid
            },
            new Route()
            {
                route_uuid = Guid.NewGuid(),
                departure_time = new DateTime(2023, 3, 12, 12, 30, 0, DateTimeKind.Utc),
                arrival_time = new DateTime(2023, 3, 13, 12, 30, 0, DateTimeKind.Utc),
                origin = 'B',
                destination = 'W',
                footprint = 200.0,
                transportation_mode = TransportationMode.Plane,
                user_uuid = user2.user_uuid,
                goal_uuid = goal2.goal_uuid
            },
            new Route()
            {
                route_uuid = Guid.NewGuid(),
                departure_time = new DateTime(2023, 4, 10, 12, 30, 0, DateTimeKind.Utc),
                arrival_time = new DateTime(2023, 4, 11, 12, 30, 0, DateTimeKind.Utc),
                origin = 'W',
                destination = 'M',
                footprint = 300.0,
                transportation_mode = TransportationMode.Plane,
                user_uuid = user3.user_uuid,
                goal_uuid = goal3.goal_uuid
            }
        };

        dataContext.Routes.AddRange(routes);
        dataContext.SaveChanges();
    }

}



    }
}
