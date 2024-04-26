﻿using Registration.Domain.Enums;
using Registration.Domain.Models;

namespace Registration.Application.Dtos
{
    public record PatientDto(Guid Id, string firstName, string lastName, DateTime dateOfbirth, int cin, int cnam, Gender gender, int height, int weight,
            string email, string address1, string address2, string country, string state, FamilyStatus familyStatus, Children children);
}
