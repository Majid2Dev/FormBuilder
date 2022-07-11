using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Models;

public class Form
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }
    public long OrderBy { get; set; }
    public FormStatus FormStatus { get; set; }

    public ICollection<Field> Fields { get; set; }  
    public ICollection<Response> Responses { get; set; }

}

public enum FormStatus
{
    Active,
    Inactive,
}