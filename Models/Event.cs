namespace EventHistoryService.Models;
public record Event(Guid Id, Guid FnoWorkOrderStatusId, string? ZinierWorkOrderTemplateId, string? ZinierTaskTypeId,bool? CancellationWorkOrder);
