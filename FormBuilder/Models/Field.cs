using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormBuilder.Models;

public class Field
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    public DataType DataType { get; set; }

    [ForeignKey("Form")]
    public long FormId { get; set; }
    public Form Form { get; set; }
    [ForeignKey("Vocabularie")]
    public long? VocabularieId { get; set; }
    public Vocabularie Vocabularie { get; set; }
    public ICollection<Response> Responses { get; set; }

}
public enum DataType
{
    TextBox,
    Header,
    Checkbox,
    Number,
    TextArea,
    ComboBox,
    MultiSelect,
    CheckboxList,
    RadioList,
}