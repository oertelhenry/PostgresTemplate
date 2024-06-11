using EventHistoryService.Models;
using JetBrains.Annotations;

namespace EventHistoryService.Database.Extensions;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class ReactionsExtensions
{
    public static Reaction Map(this Public.Tables.Reaction source)
    {
        return new Reaction(
            source.Id,
            source.FnoWorkOrderStatusId,
            source.ZinierTaskTypeId,
            source.ZinierStatus,
            source.DoAreaCheck,
            source.AreaCheckFailStatus
        );
    }

    public static Public.Tables.Reaction Map(this Reaction source, Guid operatorId)
    {
        return new Public.Tables.Reaction
        {
            Id = source.Id,
            OperatorId = operatorId,
            FnoWorkOrderStatusId = source.FnoWorkOrderStatusId,
            ZinierTaskTypeId = source.ZinierTaskTypeId,
            ZinierStatus = source.ZinierStatus,
            DoAreaCheck = source.DoAreaCheck,
            AreaCheckFailStatus = source.AreaCheckFailStatus
        };
    }

    public static List<Reaction> Map(this IEnumerable<Public.Tables.Reaction> source)
    {
        return source.Select(Map).ToList();
    }
}
