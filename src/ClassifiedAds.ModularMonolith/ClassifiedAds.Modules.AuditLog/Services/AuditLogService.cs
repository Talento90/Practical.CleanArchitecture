using ClassifiedAds.Application;
using ClassifiedAds.Domain.Events;
using ClassifiedAds.Modules.AuditLog.Contracts.DTOs;
using ClassifiedAds.Modules.AuditLog.Contracts.Services;
using ClassifiedAds.Modules.AuditLog.Entities;
using ClassifiedAds.Modules.AuditLog.Queries;
using ClassifiedAds.Modules.AuditLog.Repositories;
using System.Collections.Generic;

namespace ClassifiedAds.Modules.AuditLog.Services
{
    public class AuditLogService : CrudService<AuditLogEntry>, IAuditLogService
    {
        private readonly Dispatcher _dispatcher;

        public AuditLogService(AuditLogDbContext dbContext, IDomainEvents domainEvents, Dispatcher dispatcher)
            : base(dbContext, domainEvents)
        {
            _dispatcher = dispatcher;
        }

        public void AddOrUpdate(AuditLogEntryDTO dto)
        {
            AddOrUpdate(new AuditLogEntry
            {
                UserId = dto.UserId,
                CreatedDateTime = dto.CreatedDateTime,
                Action = dto.Action,
                ObjectId = dto.ObjectId,
                Log = dto.Log,
            });
        }

        public List<AuditLogEntryDTO> GetAuditLogEntries(AuditLogEntryQueryOptions options)
        {
            return _dispatcher.Dispatch(new GetAuditEntriesQuery
            {
                ObjectId = options.ObjectId,
                UserId = options.UserId,
            });
        }
    }
}
