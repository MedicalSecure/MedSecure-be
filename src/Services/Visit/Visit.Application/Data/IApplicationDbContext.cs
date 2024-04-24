﻿
using Visit.Domain.Models;

namespace Visit.Application.Data;

public interface  IApplicationDbContext
{
    DbSet<Domain.Models.Visit> Visits { get; }
    DbSet<Patient> Patients { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
