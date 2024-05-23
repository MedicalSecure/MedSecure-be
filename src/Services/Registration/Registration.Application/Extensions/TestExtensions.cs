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
                id: t.Id.Value,
                code: t.Code,
                description: t.Description,
                language: t.Language,
                testType: t.Type,
                registerId: t.RegisterId.Value
            );
        }
    }
}