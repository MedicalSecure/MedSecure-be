﻿
namespace BacPatient.Application.Dtos;

public record PosologyDto(
    Guid Id
    , DateTime StartDate,
    DateTime EndDate ,
    int QuantityBE ,
    int QuantityAE , 
    bool IsPermanent ,
    List<int> Hours);