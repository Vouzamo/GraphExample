using System.Collections.Generic;
using Models.GraphModels;

namespace Data.Context
{
    public class GraphModel
    {
        private GraphContext GraphContext { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public GraphModel(GraphContext graphContext)
        {
            GraphContext = graphContext;

            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public void AddNode(Node node)
        {
            if (!Nodes.Contains(node))
            {
                Nodes.Add(node);

                foreach (Edge edge in GraphContext.QueryOutboundEdges(node))
                {
                    if (!Edges.Contains(edge))
                    {
                        Edges.Add(edge);

                        // Start again for this node
                        AddNode(edge.ToNode);
                    }
                }
            }
        }
    }
}
