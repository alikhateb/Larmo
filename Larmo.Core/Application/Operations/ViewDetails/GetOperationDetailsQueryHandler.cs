using Larmo.Core.Repository;
using MediatR;

namespace Larmo.Core.Application.Operations.ViewDetails;

internal sealed class GetOperationDetailsQueryHandler(IOperationRepository operationRepository)
    : IRequestHandler<GetOperationDetailsQuery, OperationResult>
{
    public async Task<OperationResult> Handle(GetOperationDetailsQuery request, CancellationToken cancellationToken)
    {
        var specification = new OperationSpecification(request.GetOperationId());
        var operation = await operationRepository.FirstOrDefaultAsync(specification, cancellationToken);
        if (operation is null)
            throw new NullReferenceException("no item found");

        var result = new OperationResult(Id: operation.Id,
            OperationType: operation.OperationType,
            Amount: operation.Amount,
            CurrencyType: operation.CurrencyType,
            Date: operation.Date,
            Iban: operation.Iban,
            BeneficiaryActivity: operation.BeneficiaryActivity,
            BeneficiaryName: operation.BeneficiaryName,
            BeneficiaryCountry: operation.BeneficiaryCountry,
            BeneficiaryCity: operation.BeneficiaryCity,
            BeneficiaryArea: operation.BeneficiaryArea,
            BeneficiaryNearestMilestone: operation.BeneficiaryNearestMilestone,
            SourceOfFunds: operation.SourceOfFunds,
            SendingParty: operation.SendingParty,
            ReceivingParty: operation.ReceivingParty,
            ClientProfession: operation.ClientProfession,
            ClientIdentityNumber: operation.ClientIdentityNumber,
            ClientCountry: operation.ClientCountry,
            ClientCity: operation.ClientCity,
            ClientArea: operation.ClientArea,
            ClientNearestMilestone: operation.ClientNearestMilestone,
            BeneficiaryClientRelationship: operation.BeneficiaryClientRelationship);

        return result;
    }
}