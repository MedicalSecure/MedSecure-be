using BuildingBlocks.Exceptions;


namespace Registration.Application.Exceptions
{
    internal class RiskFactorNotFoundException : NotFoundException
    {
        public RiskFactorNotFoundException(Guid Id) : base("RiskFactor" , Id)
        {
        }
    }
}
