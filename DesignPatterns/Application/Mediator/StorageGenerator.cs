using Application.Mediator.Context;
using Bogus;
using Domain.Models;

namespace Application.Mediator;

/// <summary>
/// Генерирует хранилища.
/// </summary>
public class StorageGenerator : IStorageProvider
{
    private readonly Faker<Size> _sizeFaker = new();
    private readonly Faker<Storage> _storageFaker = new();

    /// <inheritdoc/>
    public IEnumerable<Storage> GetStorages(StoragesFilterContext context)
    {
        SetUpFaker(context);
        return _storageFaker.GenerateLazy(context.Count);
    }

    private void SetUpFaker(StoragesFilterContext context)
    {
        _sizeFaker.RuleFor(x => x.Depth, faker => SetUpFloatGeneration(context.MinSize?.Depth, context.MaxSize?.Depth, faker))
            .RuleFor(x => x.Height, faker => SetUpFloatGeneration(context.MinSize?.Height, context.MaxSize?.Height, faker))
            .RuleFor(x => x.Width, faker => SetUpFloatGeneration(context.MinSize?.Width, context.MaxSize?.Width, faker));
        _storageFaker
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.TotalSize, () => _sizeFaker.Generate())
            .RuleFor(x => x.FreeSize, (faker, storage) => storage.TotalSize)
            .RuleFor(x => x.TotalVolume, (faker, storage) => CalculateVolume(storage.TotalSize))
            .RuleFor(x => x.FreeVolume, (faker, storage) => storage.TotalVolume);
    }

    private float CalculateVolume(Size storageSize) =>
        storageSize.Depth * storageSize.Height * storageSize.Width;

    private float SetUpFloatGeneration(float? min, float? max, Faker faker)
    {
        var minFloat = 0f;
        var maxFloat = 0f;
        if (min != null)
        {
            minFloat = min.Value;
        }

        if (max != null)
        {
            maxFloat = max.Value;
        }

        return faker.Random.Float(minFloat, maxFloat);
    }
}
