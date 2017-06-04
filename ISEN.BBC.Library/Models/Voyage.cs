using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISEN.BBC.Library.Models
{
    public class Voyage : ArchivableEntity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Entrez un lieu de depart !")]
        [StringLength(80)]
        public string Depart { get; set; }

        [Required(ErrorMessage = "Entrez une destination !")]
        [StringLength(80)]
        public string Destination { get; set; }       

        [Required(ErrorMessage = "Entrez un nombre de place !")]
        public int Places { get; set; }

        public virtual ICollection<Reservation> ReservationCollection { get; set; } = new List<Reservation>();

        public bool IsFull => Places <= ReservationCollection.Count;

        public int NbPlaces => Places - ReservationCollection.Count;

        public override string Display =>
            $"{base.Display}|Date={Date}|Depart={Depart}|Destination={Destination}|NbPlace={Places}";
    }
}
