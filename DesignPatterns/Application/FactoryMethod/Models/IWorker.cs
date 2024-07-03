using Domain.Models;

namespace Application.FactoryMethod.Models;

/// <summary>
/// </summary>
public interface IWorker
{
    void Take(IEnumerable<Good> goods);
    List<Good>? GetWorkersGoods();
}
