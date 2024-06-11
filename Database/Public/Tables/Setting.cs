using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHistoryService.Database.Public.Tables;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[Table("settings")]
public class Setting: IEntityTypeConfiguration<Setting>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    public ICollection<Audit.Tables.Setting> SettingAudits { get; set; } = new List<Audit.Tables.Setting>();

    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

        builder.HasMany(p => p.SettingAudits).WithOne(x => x.SettingRecord!).HasForeignKey(x => x.Id).HasPrincipalKey(x => x.Id);

        builder.HasIndex(p => new { p.OperatorId }).IsUnique();
        builder.Property(e => e.TaskHost).IsRequired(false);
        builder.Property(e => e.TemplateHost).IsRequired(false);
    }

}