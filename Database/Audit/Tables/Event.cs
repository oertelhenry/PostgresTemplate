using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DotNetToolbox.Db.Audit.Models;
using JetBrains.Annotations;

namespace EventHistoryService.Database.Audit.Tables;

[ExcludeFromCodeCoverage]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Event: IAuditEntity<Public.Tables.Event>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuditId { get; set; }
    public char AuditAction { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public long? DeletionContextId { get; set; }
    public Guid Id { get; set; }
    public Guid OperatorId { get; set; }
    public Guid WorkOrderStatusId { get; set; }
    [MaxLength(255)]
    public string? ZinierWorkOrderTemplateId { get; set; } = string.Empty;
    [MaxLength(255)]
    public string? ZinierTaskTypeId { get; set; } = string.Empty;
    public bool? CancellationWOrkOrder { get; set; } = false;
    public Public.Tables.Event? EventRecord { get; set; }
}
