using CSharpFunctionalExtensions;
using PetFamily.SharedKernel;

namespace Dropper.Domain.ValueObjects;

/// <summary>
/// Value Object который̆ представляет имя файла.
/// </summary>
public class FileName : ValueObject
{
    /// <summary>
    /// Имя файла.
    /// </summary>
    public string Value { get; }

    private FileName(string value) => Value = value;

    public static Result<FileName, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<FileName, Error>(Errors.General.ValueIsRequired(nameof(value)));
        }

        if (value.Any(c => !char.IsLetterOrDigit(c)))
        {
            return Result.Failure<FileName, Error>(
                Errors.File.IncorrectFile(DescriptionErrors.FileErrors.IncorrectName));
        }

        return new FileName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
