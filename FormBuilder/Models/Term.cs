using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models;

public class Term
{
    [Key]
    public long Id { get; set; }

    public string Value { get; set; }
        
    public long OrderBy { get; set; }

    [ForeignKey("Vocabularie")]
    public long VocabularieId { get; set; }
    public Vocabularie Vocabularie { get; set; }
}