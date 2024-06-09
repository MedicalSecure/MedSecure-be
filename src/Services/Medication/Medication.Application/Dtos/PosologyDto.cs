using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Dtos
{
    public record PosologyDto(Guid Id, Guid DrugId, DrugDto? Drug, List<DispensesDTO> Dispenses, List<CommentDto> Comments);
}