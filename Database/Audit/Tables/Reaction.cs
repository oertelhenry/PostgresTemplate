using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DotNetToolbox.Db.Audit.Models;
using JetBrains.Annotations;

namespace EventHistoryService.Database.Audit.Tables;

[ExcludeFromCodeCoverage]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Reaction: IAuditEntity<Public.Tables.Reaction>
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
    public string ZinierTaskTypeId { get; set; } = string.Empty;
    [MaxLength(255)]
    public string ZinierStatus { get; set; } = string.Empty;
    public bool DoAreaCheck { get; set; }
    public Guid? AreaCheckFailStatus { get; set; }

    public Public.Tables.Reaction? ReactionRecord { get; set; }
}
