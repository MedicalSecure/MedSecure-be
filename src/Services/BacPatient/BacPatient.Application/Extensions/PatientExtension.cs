using BacPatient.Domain.Enums;
using BacPatient.Domain.Models;
using BacPatient.Domain.ValueObjects;
using MassTransit.Internals.GraphValidation;
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
                id: d.Id.Value,
                firstName: d.FirstName,
                lastName: d.LastName,
                dateOfBirth: d.DateOfBirth,
                identity: d.FirstName,
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
                children: d.Children,
                assurance: d.Assurance,
                addressIsRegistrations : d.AddressIsRegisterations,
                saveForNextTime : d.AddressIsRegisterations,
                zipCode:d.ZipCode 
                );
        }

        public static IEnumerable<RiskFactorDto> ToRiskFactorDto(this IEnumerable<RiskFactor> riskFactors)
        {
            return riskFactors.Select(p => new RiskFactorDto(
                id: p.Id.Value,
                key: p.Key,
                value: p.Value,
                code: p.Code,
                description: p.Description,
                isSelected: p.IsSelected,
                type: p.Type,
                icon: p.Icon,
                subRiskFactors: p.SubRiskFactors?.ToList()
                ));
        }
    


    public static HistoryDto ToHistoryDto(this History history)
        {
            return new HistoryDto
            {
                Date = history.Date,
                Status = history.Status,
                RegisterId = history.RegisterId.Value
            };
        }

       

      

        public static List<HistoryDto> ToHistoriesDto(this IEnumerable<History> histories)
        {
            return histories.Select(history => history.ToHistoryDto()).ToList();
        }

        public static IEnumerable<TestDto> ToTestDto(this List<Test> tests)
        {
            return tests.Select(t => new TestDto(
                id: t.Id.Value,
                code: t.Code,
                description: t.Description,
                language: t.Language,
                testType: t.Type,
                registerId: t.RegisterId.Value
            ));
        }

    }
}