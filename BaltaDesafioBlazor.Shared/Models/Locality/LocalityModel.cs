using System.ComponentModel.DataAnnotations;

namespace BaltaDesafioBlazor.Shared.Models.Locality;

public class LocalityModel
{
    [Required(ErrorMessage = "O identificador é obrigatório")]
    [Display(Name = "Identificador")]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cidade é obrigatória")]
    [Display(Name = "Cidade")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado é obrigatório")]
    [Display(Name = "Estado")]
    public string State { get; set; } = string.Empty;
}
