using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DM.Model.Entities
{
    public class Client: Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
