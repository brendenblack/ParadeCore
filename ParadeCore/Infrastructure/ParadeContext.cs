using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ParadeCore.Domain.Models;
using System.Data;
using System.Threading.Tasks;

namespace ParadeCore.Infrastructure
{
    public class ParadeContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public ParadeContext(DbContextOptions<ParadeContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Member>()
                .ToTable("Member")
                .HasIndex(m => m.ServiceNumber)
                .IsUnique(true);

            modelBuilder.Entity<TrainingCalendarEvent>()
                .HasKey(t => new { t.EventId, t.TrainingCalendarId });

            modelBuilder.Entity<TrainingCalendarEvent>()
                .HasOne(tce => tce.Event)
                .WithMany(e => e.TrainingCalendars)
                .HasForeignKey(tce => tce.EventId);

            modelBuilder.Entity<TrainingCalendarEvent>()
                .HasOne(tce => tce.TrainingCalendar)
                .WithMany(tc => tc.Events)
                .HasForeignKey(tce => tce.TrainingCalendarId);
        }

        public void BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
