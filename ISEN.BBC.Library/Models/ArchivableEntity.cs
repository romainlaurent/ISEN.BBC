using System.ComponentModel.DataAnnotations;

namespace ISEN.BBC.Library.Models
{
    public abstract class ArchivableEntity : BaseEntity
    {
        private bool isArchived = false;
        public bool IsArchived { get => isArchived; set => isArchived = value; }

        public override string Display => $"{base.Display}|Archived={IsArchived}";
    }
}