using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.GraphModels
{
    public class Edge
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public EdgeType Type { get; set; }

        public int FromNodeId { get; set; }
        public virtual Node FromNode { get; set; }
        public int ToNodeId { get; set; }
        public virtual Node ToNode { get; set; }
    }
}