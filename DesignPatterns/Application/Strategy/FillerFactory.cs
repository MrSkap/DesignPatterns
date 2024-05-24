using Application.Strategy.Fillers;
using Domain.Models;

namespace Application.Strategy;

/// <inheritdoc/>
public class FillerFactory : IFillerFactory
{
    private readonly Dictionary<FillingType, IFiller> _fillers = new()
    {
        { FillingType.ByGoodType, new GoodsTypeFiller() },
        { FillingType.ByMiddleWeight, new MiddleWeightFiller() },
        { FillingType.ByMaxVolumeUsage, new MaxVolumeFiller() },
    };

    /// <inheritdoc/>
    public IFiller GetFiller(FillingContext context) => _fillers[context.Type];
}
