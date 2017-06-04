using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ISEN.BBC.Library.Models
{
    public class Reservation : BaseEntity
    {
        public int VoyageId { get; set; }
        public virtual Voyage Voyage { get; set; }
    }
}
