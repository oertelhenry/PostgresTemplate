using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHistoryService.Database.Public.Tables;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[Table("reactions")]
public class Reaction: IEntityTypeConfiguration<Reaction>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid OperatorId { get; set; }
    public Guid FnoWorkOrderStatusId { get; set; }
    [MaxLength(255)]
    public string ZinierTaskTypeId { get; set; } = string.Empty;
    [MaxLength(255)]
    public string ZinierStatus { get; set; } = string.Empty;
    public bool DoAreaCheck { get; set; }
    public Guid? AreaCheckFailStatus { get; set; }
    public ICollection<Audit.Tables.Reaction> ReactionAudits { get; set; } = new List<Audit.Tables.Reaction>();

    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

        builder.HasMany(p => p.ReactionAudits).WithOne(x => x.ReactionRecord!).HasForeignKey(x => x.Id).HasPrincipalKey(x => x.Id);

        builder.HasIndex(p => new { p.OperatorId, p.FnoWorkOrderStatusId, p.ZinierStatus, p.ZinierTaskTypeId }).IsUnique();

        builder.Property(e => e.AreaCheckFailStatus).IsRequired(false);
    }

}
