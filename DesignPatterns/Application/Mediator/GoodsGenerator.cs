using Application.Mediator.Context;
using Bogus;
using Domain.Models;

namespace Application.Mediator;

/// <summary>
/// Генерирует товары, по запросу.
/// </summary>
public class GoodsGenerator : IGoodsProvider
{
    private readonly Faker<Good> _goodFaker = new();

    private readonly Faker<Size> _sizeFaker = new();

    /// <inheritdoc/>
    public IEnumerable<Good> GetGoods(GoodsFilterContext context)
    {
        SetUpFaker(context);
        return _goodFaker.GenerateLazy(context.Count);
    }

    private void SetUpFaker(GoodsFilterContext context)
    {
        _sizeFaker.RuleFor(x => x.Depth, faker => SetUpFloatGeneration(context.MinSize?.Depth, context.MaxSize?.Depth, faker))
            .RuleFor(x => x.Height, faker => SetUpFloatGeneration(context.MinSize?.Height, context.MaxSize?.Height, faker))
            .RuleFor(x => x.Width, faker => SetUpFloatGeneration(context.MinSize?.Width, context.MaxSize?.Width, faker));
        _goodFaker
            .RuleFor(x => x.Id, Guid.NewGuid)
            .RuleFor(x => x.Type, faker => context.Type ?? faker.PickRandom<GoodType>())
            .RuleFor(x => x.Weight, faker => SetUpFloatGeneration(context.MinWeight, context.MaxWeight, faker))
            .RuleFor(x => x.Size, () => _sizeFaker.Generate());
    }

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
