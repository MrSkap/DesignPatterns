using Domain.Models;

namespace Application.TemplateMethod.Extensions;

public static class StorageExtension
{
    public static Storage MoveGoodsFrom(this Storage currentStorage, Storage storages)
    {
        var finalStorage = new Storage();
        return finalStorage;
        // storages.Select(x => x.)
    }
}
