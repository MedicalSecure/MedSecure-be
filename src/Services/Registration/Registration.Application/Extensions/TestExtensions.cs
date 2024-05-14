using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Application.Extensions
{
    public static partial class TestExtensions
    {
        public static IEnumerable<TestDto> ToTestDto(this List<Domain.Models.Test> tests)
        {
            return tests.Select(t => new TestDto(
                id: t.Id.Value,
                code: t.Code,
                description: t.Description,
                language: t.Language,
                testType: t.Type,
                registerId:t.RegisterId.Value
            ));
        }
    }
}
