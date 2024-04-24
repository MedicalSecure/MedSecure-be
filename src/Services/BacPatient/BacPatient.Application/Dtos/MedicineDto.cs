

namespace BacPatient.Application.Dtos
{
    public  record MedicineDto(Guid Id ,string Name , string Form , Root Root  ,string Dose , string Unit , DateTime DateExp , int Stock , List<string> Note , List<PosologyDto> Posology);
   
}
