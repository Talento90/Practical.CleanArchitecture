using ClassifiedAds.Modules.AuditLog.Contracts.DTOs;
using System.Collections.Generic;

namespace ClassifiedAds.Modules.AuditLog.Contracts.Services
{
    public interface IAuditLogService
    {
        List<AuditLogEntryDTO> GetAuditLogEntries(AuditLogEntryQueryOptions options);

        void AddOrUpdate(AuditLogEntryDTO auditLog);
    }
}
