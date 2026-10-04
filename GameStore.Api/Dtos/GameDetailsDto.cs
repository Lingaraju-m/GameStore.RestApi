namespace GameStore.Api.Dtos
{
    public record GameDetailsDto(
        int Id,
        string Name,
        int GenreId,
        Decimal Price,
        DateOnly ReleaseDate
    );
}
