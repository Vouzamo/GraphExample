using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.GraphModels
{
    [Table("Track")]
    public class Track : Node
    {
        public TimeSpan Length { get; set; }
    }
}