using System.ComponentModel.DataAnnotations;

namespace BaltaDesafioBlazor.Shared.Models.Locality;

public class LocalityModel
{
    [Required]
    [Display(Name = "Identificador")]
    public string Id { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Cidade")]
    public string City { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Estado")]
    public string State { get; set; } = string.Empty;
}
