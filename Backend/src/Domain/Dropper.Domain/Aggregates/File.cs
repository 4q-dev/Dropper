using CSharpFunctionalExtensions;
using Dropper.Domain.ValueObjects;

namespace Dropper.Domain.Aggregates;

/// <summary>
/// Агрегат файл.
/// </summary>
public class File : Entity<FileId>
{
    /// <summary>
    /// Название файла.
    /// </summary>
    public FileName Name { get; set; }

    /// <summary>
    /// Расширение файла.
    /// </summary>
    public FileExtension Extension { get; set; }

    /// <summary>
    /// Размер файла в мегабайтах.
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// Конструктор для EF.
    /// </summary>
    private File(FileId id) : base(id)
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public File(FileId id, FileName name, FileExtension extension, long size) : base(id)
    {
        Name = name;
        Extension = extension;
        Size = size;
    }
}
