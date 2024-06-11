using DotNetToolbox.Db.Audit.Pg;
using EventHistory.Database.Entities;
using EventHistoryService.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;


namespace EventHistory.Database
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class EventHistoryContext : PgAuditDbContext
    {
        public EventHistoryContext(DbContextOptions options, IConfiguration configuration) : base(options, configuration)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SetupAuditEntities(modelBuilder, GetType().Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<EventHistoryService.Database.Audit.Tables.Event>().ToTable("events", "audit");
            modelBuilder.Entity<EventHistoryService.Database.Audit.Tables.Reaction >().ToTable("reactions", "audit");
            modelBuilder.Entity<EventHistoryService.Database.Audit.Tables.Setting>().ToTable("settings", "audit");
        }


        public DbSet<TestTable> TestTable { get; set; }

        public DbSet<Setting> Settings => Set<Setting>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Reaction> Reactions => Set<Reaction>();


        public DbSet<EventHistoryService.Database.Audit.Tables.Setting> SettingAudits => Set<EventHistoryService.Database.Audit.Tables.Setting>();
        public DbSet<EventHistoryService.Database.Audit.Tables.Event> EventAudits => Set<EventHistoryService.Database.Audit.Tables.Event>();
        public DbSet<EventHistoryService.Database.Audit.Tables.Reaction> ReactionAudits => Set<EventHistoryService.Database.Audit.Tables.Reaction>();
    }
}
