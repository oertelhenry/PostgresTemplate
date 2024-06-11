namespace EventHistoryService.Models;
public record Reaction(Guid Id, Guid FnoWorkOrderStatusId, string ZinierTaskTypeId, string ZinierStatus, bool DoAreaCheck, Guid? AreaCheckFailStatus);


