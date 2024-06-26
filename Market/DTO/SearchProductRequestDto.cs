using Market.Enums;

namespace Market.DTO;

public record SearchProductRequestDto(
    string? ProductName,
    SortType? SortType,
    ProductCategory? Category,
    bool Ascending = true,
    int Skip = 0,
    int Take = 50);