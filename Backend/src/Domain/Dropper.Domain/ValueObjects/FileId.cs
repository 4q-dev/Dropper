namespace Dropper.Domain.ValueObjects;

public class FileId : IComparable<FileId>
{
    public Guid Id { get; }

    private FileId(Guid id) => Id = id;

    public static FileId NewId() => new (Guid.NewGuid());
    public static FileId Create(Guid id) => new (id);
    public static implicit operator Guid(FileId breedId) => breedId.Id;

    public int CompareTo(FileId? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return Id.CompareTo(other.Id);
    }
}