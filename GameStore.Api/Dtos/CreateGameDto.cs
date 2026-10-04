using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameStore.Api.Dtos
{
    public record CreateGameDto(
        [Required] [StringLength(50)]
        string Name,

        [Required] [Range(1,50)]
        int GenreId,

        [Required] [Range(1,100)] [NotNull]
        decimal Price,

        [Required]
        DateOnly ReleaseDate
    );
}
