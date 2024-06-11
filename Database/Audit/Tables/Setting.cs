using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DotNetToolbox.Db.Audit.Models;
using JetBrains.Annotations;

namespace EventHistoryService.Database.Audit.Tables;

[ExcludeFromCodeCoverage]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Setting: IAuditEntity<Public.Tables.Setting>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuditId { get; set; }
    public char AuditAction { get; set; }
    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public long? DeletionContextId { get; set; }

    public Guid Id { get; set; }
    public Guid OperatorId { get; set; }
    [MaxLength(255)]
    public string Org { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Login { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Password { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Authorization { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Locale { get; set; } = string.Empty;
    public Uri? TemplateHost { get; set; }
    public Uri? TaskHost { get; set; }

    public Public.Tables.Setting? SettingRecord { get; set; }

}
