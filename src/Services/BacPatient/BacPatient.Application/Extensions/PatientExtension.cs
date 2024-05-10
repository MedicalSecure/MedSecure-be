using rescription.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Extensions
{
    public static class PatientExtension
    {
        public static PatientDto ToPatientDto(this Patient d)
        {
            return new PatientDto(
                Id: d.Id.Value,
                firstName: d.FirstName,
                lastName: d.LastName,
                dateOfbirth: d.DateOfBirth,
                cin: d.CIN,
                cnam: d.CNAM,
                gender: d.Gender,
                height: d.Height,
                weight: d.Weight,
                email: d.Email,
                address1: d.Address1,
                address2: d.Address2,
                country: d.Country,
                state: d.State,
                familyStatus: d.FamilyStatus,
                children: d.Children);
        }

        public static ICollection<PatientDto> ToPatientDto(this IReadOnlyList<Patient> patients)
        {
            return patients.Select(d => d.ToPatientDto()).ToList();
        }
        public static RiskFactorDto ToRiskFactorDto(this RiskFactor riskFactor)
        {
            return new RiskFactorDto
            {
                SubRiskFactor = riskFactor.SubRiskFactor.Select(rf => rf.ToRiskFactorDto()).ToList(),
                RiskFactorParent = riskFactor.RiskFactorParent?.ToRiskFactorDto(),
                RiskFactorParentId = riskFactor.RiskFactorParentId.Value,
                RiskFactorId = riskFactor.RiskFactorParentId.Value,
                Key = riskFactor.Key,
                Value = riskFactor.Value,
                Code = riskFactor.Code,
                Description = riskFactor.Description,
                IsSelected = riskFactor.IsSelected,
                Type = riskFactor.Type,
                Icon = riskFactor.Icon
            };
        }

        public static List<RiskFactorDto> ToRiskFactorsDto(this IEnumerable<RiskFactor> riskFactors)
        {
            return riskFactors.Select(rf => rf.ToRiskFactorDto()).ToList();
        }


        public static HistoryDto ToHistoryDto(this History history)
        {
            return new HistoryDto
            {
                Date = history.Date,
                Status = history.Status,
                RegisterId = history.RegisterId
            };
        }

       

        public static TestDto ToTestDto(this Test test)
        {
            return new TestDto
            {
                Code = test.Code,
                Description = test.Description,
                Language = test.Language,
                Type = test.Type,
                RegisterId = test.RegisterId
            };
        }

        public static List<HistoryDto> ToHistoriesDto(this IEnumerable<History> histories)
        {
            return histories.Select(history => history.ToHistoryDto()).ToList();
        }

        public static List<TestDto> ToTestsDto(this IEnumerable<Test> tests)
        {
            return tests.Select(test => test.ToTestDto()).ToList();
        }

    }
}