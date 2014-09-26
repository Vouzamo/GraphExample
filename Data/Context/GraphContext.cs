using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Models.GraphModels;

namespace Data.Context
{
    public class GraphContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Edge> Edges { get; set; }

        public GraphContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public IEnumerable<Edge> QueryOutboundEdges(Node entity)
        {
            return this.Edges.ToList().Where(x => x.FromNodeId == entity.Id).ToList();
        }

        public IEnumerable<Edge> QueryOutboundEdges<T2>(Node entity)
        {
            return this.Edges.ToList().Where(x => x.FromNodeId == entity.Id && x.ToNode is T2).ToList();
        }

        public IEnumerable<Edge> QueryInboundEdges(Node entity)
        {
            return this.Edges.ToList().Where(x => x.ToNodeId == entity.Id).ToList();
        }

        public IEnumerable<Edge> QueryInboundEdges<T2>(Node entity)
        {
            return this.Edges.ToList().Where(x => x.ToNodeId == entity.Id && x.FromNode is T2).ToList();
        }
    }
}
