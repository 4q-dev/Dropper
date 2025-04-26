using CSharpFunctionalExtensions;
using PetFamily.SharedKernel;

namespace Dropper.Domain.ValueObjects;

/// <summary>
/// Value Object для расширения файла.
/// </summary>
public class FileExtension : ValueObject
{
    /// <summary>
    /// Запрещенные форматы файлов.
    /// </summary>
    public static readonly string[] NonAllowedExtensions =
    [
        // TODO: а надо ли?
        // ".exe", ".cmd", ".bat", ".com", ".scr", ".pif", ".js", ".vbs", ".wsf", ".ps1", ".psm1", ".sh", ".apk",
        // ".msi", ".jar", ".vb", ".cpl", ".msc", ".gadget"
    ];

    /// <summary>
    /// Значение расширения.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    private FileExtension(string value) => Value = value;

    public static Result<FileExtension, Error> Create(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return Result.Failure<FileExtension, Error>(
                Errors.File.IncorrectFile(DescriptionErrors.FileErrors.IncorrectExtension));
        }

        var extension = Path.GetExtension(fileName).ToLowerInvariant();

        if (NonAllowedExtensions.Contains(extension))
        {
            return Result.Failure<FileExtension, Error>(
                Errors.File.IncorrectFile(DescriptionErrors.FileErrors.IncorrectExtension));
        }

        return new FileExtension(extension);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
