using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Models;

public class Vocabularie
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    public long OrderBy { get; set; }

    public List<Term> Terms { get; set; }
}