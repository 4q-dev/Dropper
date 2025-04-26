namespace PetFamily.Core.Abstractions;

/// <summary>
/// Интерфейс для применения миграций к базе данных.
/// </summary>
public interface IMigrator
{
    Task Migrate(CancellationToken cancellationToken = default);
}