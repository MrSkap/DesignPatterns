using Domain.Models;

namespace Application.Proxy;

/// <summary>
/// Запрос на доставку.
/// </summary>
/// <param name="PostmanId">Идентификатор доставщика.</param>
/// <param name="Packages">Посылки.</param>
/// <param name="Context">Контекст доставки.</param>
public record DeliveryRequest(Guid? PostmanId, List<Package> Packages, DeliveryContext Context);
