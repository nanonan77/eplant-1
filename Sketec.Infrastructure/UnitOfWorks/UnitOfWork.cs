using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sketec.Core.Domains;
using Sketec.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.UnitOfWorks
{
    abstract public class UnitOfWork : IUnitOfWork
    {
        DbContext db;
        public UnitOfWork(DbContext db)
        {
            this.db = db;
        }

        public string Username { get; set; }

        public IDbContextTransaction BeginTransaction()
        {
            return db.Database.BeginTransaction();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return db.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            db.Database.CommitTransaction();
        }

        public Task CommitAsync()
        {
            return db.Database.CommitTransactionAsync();
        }

        public void Rollback()
        {
            db.Database.RollbackTransaction();
        }

        public Task RollbackAsync()
        {
            return db.Database.RollbackTransactionAsync();
        }

        public int Save()
        {
            AuditInfomation();
            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                return db.SaveChanges();
            }
            finally
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public int SaveNoStampDate()
        {
            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                return db.SaveChanges();
            }
            finally
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public Task<int> SaveAsyncNoStampDate()
        {
            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                return db.SaveChangesAsync();
            }
            finally
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public Task<int> SaveAsync()
        {
            AuditInfomation();
            try
            {
                db.ChangeTracker.AutoDetectChangesEnabled = false;
                return db.SaveChangesAsync();
            }
            finally
            {
                db.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        private void AuditInfomation()
        {
            var date = DateTime.Now;//DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).DateTime;
            foreach (var entity in db.ChangeTracker.Entries<Entity>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property(e => e.CreatedDate).CurrentValue = date;
                    entity.Property(e => e.CreatedBy).CurrentValue = Username;
                    entity.Property(e => e.UpdatedDate).CurrentValue = date;
                    entity.Property(e => e.UpdatedBy).CurrentValue = Username;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Property(e => e.UpdatedDate).CurrentValue = date;
                    entity.Property(e => e.UpdatedBy).CurrentValue = Username;
                }
            }

            foreach (var entity in db.ChangeTracker.Entries<EntityTransaction>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property(e => e.CreatedDate).CurrentValue = date;
                    entity.Property(e => e.CreatedBy).CurrentValue = Username;
                    entity.Property(e => e.UpdatedDate).CurrentValue = date;
                    entity.Property(e => e.UpdatedBy).CurrentValue = Username;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Property(e => e.UpdatedDate).CurrentValue = date;
                    entity.Property(e => e.UpdatedBy).CurrentValue = Username;
                }
            }
        }
    }
}
