using System.ComponentModel.DataAnnotations.Schema;

namespace SEDC.BurgerApp.Domain
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
