using System;
using System.Data.Entity;
using Models.GraphModels;

namespace Data.Context
{
    public class GraphInitializer : DropCreateDatabaseIfModelChanges<GraphContext>
    {
        protected override void Seed(GraphContext graphContext)
        {
            Album originOfSymetry = new Album()
            {
                Name = "Origin of Symetry",
                Description = "A fantastic album by MUSE",
                Genre = "Indie",
                ReleaseDate = new DateTime(2001, 5, 20)
            };

            Artist muse = new Artist()
            {
                Name = "MUSE",
                DateOfBirth = new DateTime(1984,5,24)
            };

            Track plugInBaby = new Track()
            {
                Name = "Plug In Baby",
                Length = TimeSpan.FromSeconds(200)
            };

            graphContext.Nodes.Add(originOfSymetry);
            graphContext.Nodes.Add(muse);
            graphContext.Nodes.Add(plugInBaby);

            graphContext.Edges.Add(new Edge()
            {
                FromNode = muse,
                ToNode = originOfSymetry,
                Type = EdgeType.Has
            });

            graphContext.Edges.Add(new Edge()
            {
                FromNode = originOfSymetry,
                ToNode = plugInBaby,
                Type = EdgeType.Has
            });
        }
    }
}
