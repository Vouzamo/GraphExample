using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Models.GraphModels
{
    public class Node
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type
        {
            get { return GetType().Name.Split('_').First(); }
        }
        public DateTime Created { get; set; }

        public virtual ICollection<Edge> Edges { get; set; }

        public Node()
        {
            Created = DateTime.Now;
        }
    }
}