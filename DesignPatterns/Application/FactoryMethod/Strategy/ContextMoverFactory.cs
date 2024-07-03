using Application.FactoryMethod.Models;

namespace Application.FactoryMethod.Strategy;

/// <inheritdoc/>
public class ContextMoverFactory : IContextMoverFactory
{
    /// <inheritdoc/>
    public IMover Create(CreateMoverContext context)
    {
        var mover = new MoverWorker
        {
            Speed = context.Speed,
        };
        mover.Take(context.Goods);
        return mover;
    }
}
