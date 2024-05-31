using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Application.Extensions
{
    public static partial class TestExtensions
    {
        public static IEnumerable<TestDto> ToTestDto(this IReadOnlyList<Domain.Models.Test> tests)
        {
            return tests.Select(t => t.ToTestDto());
        }

        public static TestDto ToTestDto(this Test t)
        {
            return new TestDto(
                Id: t.Id.Value,
                Code: t.Code,
                Description: t.Description,
                Language: t.Language,
                TestType: t.Type,
                RegisterId: t.RegisterId.Value
            );
        }
    }
}