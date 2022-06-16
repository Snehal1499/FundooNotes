using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entities
{
    [Keyless]
    public class Lable
    {

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Note")]
        public int NoteId { get; set; }
        public string LabelName { get; set; }
    }
}
