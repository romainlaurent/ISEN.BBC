using System.ComponentModel.DataAnnotations;

namespace ISEN.BBC.Library.Models
{
    public abstract class BaseEntity
    {
        public int Id { get;set; }
        [Required]
        public string Name { get;set; }
        [StringLength(1000)]
        public string Comment { get; set; }

        public bool IsNew => Id <= 0;
        public virtual string Display => $"Name={Name}|Comment={Comment}";
        public override string ToString() => $"Id={Id}|{Display}";
    }
}
