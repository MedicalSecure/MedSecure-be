namespace Prescription.Domain.Enums
{
    public enum PrescriptionStatus
    {
        Draft = 0,// good for filling the initial data, creation process (wont be submitted outside this microservice)
        Pending = 1,
        Active = 2,  //Done : validée
        Rejected = 3,
        Discontinued = 4,
        Completed = 5,
        /*
        Expired,
        OnHold*/
    }
}