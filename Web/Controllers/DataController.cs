using System.Linq;
using System.Web.Mvc;
using Data.Context;
using Models.GraphModels;

namespace Web.Controllers
{
    public class DataController : Controller
    {
        private readonly GraphContext _graphContext;

        public DataController()
        {
            _graphContext = new GraphContext("GraphDatabase");
        }

        public ActionResult Index()
        {
            Artist artist = _graphContext.Nodes.Where(x => x is Artist).ToList().FirstOrDefault() as Artist;

            return View(artist);
        }

        //private IEnumerable<T1> Query<T1,T2>(T2 entity)
        //{
        //    // Retrieve all related T1 (of T2) regardless of the reason for the relationship
        //}

        //private IEnumerable<Relationship<T1, T2>> Query<T1, T2>(T2 entity)
        //{
        //    List<Relationship<T1,T2>> relationships = new List<Relationship<T1, T2>>();

        //    if(entity is Node)
        //    {
        //        Node nodeEntity = entity as Node;
        //        List<Edge> Edges = _graphContext.Edges.Where(x => x.FromNode is T1 && x.ToNode == nodeEntity);

        //        relationships.Add(new Relationship<T1, T2>
        //        {
        //            EntityA = T1,
        //            EntityB = T2,
        //            Direction = EdgeType.Has
        //        });
        //    }

        //    return relationships;
        //}

        // this.Query<Artist,Song>(Song plugInBaby)
        //     .Where(x => x.Name == "MUSE")
	}

    //public class Relationship<T1,T2>
    //{
    //    public T1 EntityA { get; set; }
    //    public T2 EntityB { get; set; }
    //    public Edge Edge { get; set; }
    //}
}