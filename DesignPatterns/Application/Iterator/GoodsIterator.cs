using System.Collections;
using Application.Mediator;
using Application.Mediator.Context;
using Domain.Models;

namespace Application.Iterator;

/// <summary>
/// Итератор товаров.
/// </summary>
public class GoodsIterator : IEnumerator<Good>
{
    private readonly IGoodsProvider _provider;
    private int _currentIndex;
    private Good[]? _goods;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="provider"><see cref="IGoodsProvider"/>.</param>
    public GoodsIterator(IGoodsProvider provider)
    {
        _provider = provider;
        SetUpNewGoods();
    }

    /// <summary>
    /// Переход к следующему элементу.
    /// </summary>
    /// <returns>Успешный переход или нет.</returns>
    public bool MoveNext()
    {
        if (_goods == null)
        {
            return false;
        }

        _currentIndex++;
        return _currentIndex < _goods?.Length;
    }

    /// <summary>
    /// Вернуться в начало коллекции итерируемых элементов.
    /// </summary>
    public void Reset() => _currentIndex = 0;

    /// <summary>
    /// Текущий элемент коллекции.
    /// </summary>
    public Good Current => (Good)_goods?.GetValue(_currentIndex)!;

    object IEnumerator.Current => Current;

    /// <summary>
    /// Освободить коллекцию.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Dispose()
    {
        _goods = null;
        _currentIndex = 0;
    }

    private void SetUpNewGoods()
    {
        _goods = _provider.GetGoods(new GoodsFilterContext
        {
            MaxWeight = 10,
            MinWeight = 0.1f,
        }).ToArray();
        _currentIndex = 0;
    }
}
