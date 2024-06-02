namespace UnitCare.Application.Equipments.Queries.GetEquipmentByNameQuery;


public class GetEquipmentByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetEquipmentByNameQuery, GetEquipmentByNameResult>
    {
        public async Task<GetEquipmentByNameResult> Handle(GetEquipmentByNameQuery query, CancellationToken cancellationToken)
        {
            // get equipments by Id using dbContext
            // return result
            var equipments = await dbContext.Equipments
                 .AsNoTracking()
                 .Where(o => o.Name.Contains(query.name))
                 .OrderBy(o => o.Id)
        .ToListAsync(cancellationToken);

            return new GetEquipmentByNameResult(equipments.ToEquipmentDto());
        }
    }

