using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHistoryService.Database.Public.Tables;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[Table("events")]
public class Event: IEntityTypeConfiguration<Event>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid OperatorId { get; set; }
    public Guid FnoWorkOrderStatusId { get; set; }
    [MaxLength(255)]
    public string? ZinierWorkOrderTemplateId { get; set; } = string.Empty;
    [MaxLength(255)]
    public string? ZinierTaskTypeId { get; set; } = string.Empty;
    public bool? CancellationWOrkOrder { get; set; } = false;
    public ICollection<Audit.Tables.Event> EventAudits { get; set; } = new List<Audit.Tables.Event>();
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

        builder.HasMany(p => p.EventAudits).WithOne(x => x.EventRecord!).HasForeignKey(x => x.Id).HasPrincipalKey(x => x.Id);

        builder.HasIndex(p => new { p.OperatorId,p.FnoWorkOrderStatusId }).IsUnique();

        builder.Property(e => e.ZinierWorkOrderTemplateId).IsRequired(false);
        builder.Property(e => e.ZinierTaskTypeId).IsRequired(false);
        builder.Property(e => e.CancellationWOrkOrder).IsRequired(false);


    }

}
