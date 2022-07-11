using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models;

public class Response
{
    [Key]
    public long Id { get; set; }

    [ForeignKey("Field")]
    public long FieldId { get; set; }

    [ForeignKey("Form")]
    public long FormId { get; set; }
    public string Resonses { get; set; }
    public Field Field { get; set; }
    public Form Form { get; set; }

}