using Dropper.Domain.ValueObjects;
using FluentValidation;
using PetFamily.Core.Validation;
using PetFamily.SharedKernel;

namespace Dropper.Application.Features.File;

/// <summary>
/// Валидатор команды <see cref="UploadFileCommand"/>
/// </summary>
public class UploadFileValidator : AbstractValidator<UploadFileCommand>
{
    /// <summary>
    /// Максимальный размер файла.
    /// </summary>
    private const int MAX_FILE_SIZE = 50 * 1024 * 1024; // 50 MB

    public UploadFileValidator()
    {
        RuleFor(x => x.File.FileName)
            .MustBeValueObject(FileName.Create);

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithError(Errors.File.IncorrectFile(
                $"{DescriptionErrors.FileErrors.IncorrectSize}. Max size is {MAX_FILE_SIZE} bytes."));
    }
}
