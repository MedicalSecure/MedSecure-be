﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Application.Extensions
{
    public static partial class TestExtensions
    {
        public static IEnumerable<TestDto> ToTestDto(this List<Domain.Models.Test> tests)
        {
            return tests.Select(t => new TestDto(
                Id: t.Id.Value,
                code: t.Code,
                description: t.Description,
                language: t.language,
                testType: t.type
            ));
        }
    }
}
