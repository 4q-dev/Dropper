using Microsoft.AspNetCore.Http;
using PetFamily.Core.Abstractions;

namespace Dropper.Application.Features.File;

/// <summary>
/// Команда загрузки файла.
/// </summary>
/// <param name="File">Файл.</param>
/// <param name="Size">Размер файла.</param>
public record UploadFileCommand(IFormFile File, long Size) : ICommand;
