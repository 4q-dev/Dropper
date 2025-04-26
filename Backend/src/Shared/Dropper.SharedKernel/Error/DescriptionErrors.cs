namespace PetFamily.SharedKernel;

public sealed class DescriptionErrors
{
    public sealed class FileErrors
    {
        public static readonly string IncorrectName = "Incorrect file name. Allowed characters: a-z, A-Z, 0-9.";
        public static readonly string IncorrectExtension = "Unsupported extension file.";
        public static readonly string IncorrectSize = "Incorrect file size.";
    }
}
