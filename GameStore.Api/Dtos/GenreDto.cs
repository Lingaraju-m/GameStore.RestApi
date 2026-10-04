using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameStore.Api.Dtos
{
    public record GenreDto(
       int Id, string Name
    );
}
