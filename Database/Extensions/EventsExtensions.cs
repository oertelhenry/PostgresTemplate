using EventHistoryService.Models;
using JetBrains.Annotations;

namespace EventHistoryService.Database.Extensions;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class EventsExtensions
{
    public static Event Map(this Public.Tables.Event source)
    {
        return new Event(
            source.Id,
            source.FnoWorkOrderStatusId,
            source.ZinierWorkOrderTemplateId,
            source.ZinierTaskTypeId,
            source.CancellationWOrkOrder
        );
    }

    public static Public.Tables.Event Map(this Event source, Guid operatorId)
    {
        return new Public.Tables.Event
        {
            Id = source.Id,
            OperatorId = operatorId,
            FnoWorkOrderStatusId = source.FnoWorkOrderStatusId,
            ZinierWorkOrderTemplateId = source.ZinierWorkOrderTemplateId,
            ZinierTaskTypeId = source.ZinierTaskTypeId,
            CancellationWOrkOrder = source.CancellationWorkOrder
        };
    }

    public static List<Event> Map(this IEnumerable<Public.Tables.Event> source)
    {
        return source.Select(Map).ToList();
    }
}
