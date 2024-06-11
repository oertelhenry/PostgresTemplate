namespace EventHistoryService.Models;

public record ZinierWorkOrder(
        Guid AEXWorkOrderId,
        string TaskType,
        Guid SiteId,
        string Status,
        string Comments);
