using Larmo.Core.Extension;
using Larmo.Core.Paging;
using Larmo.Core.Repository;
using MediatR;

namespace Larmo.Core.Application.Operations.ViewCollection;

internal sealed class GetOperationCollectionQueryHandler(IOperationRepository operationRepository)
    : IRequestHandler<GetOperationCollectionQuery, PageResponse<OperationResult>>
{
    public async Task<PageResponse<OperationResult>> Handle(GetOperationCollectionQuery request, CancellationToken cancellationToken)
    {
        var operations = await operationRepository.AsPage(new OperationSpecification())
            .WithPagingOptions(request, cancellationToken);

        var result = new List<OperationResult>();

        foreach (var operation in operations.Items)
        {
            result.Add(new OperationResult(Id: operation.Id,
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
                BeneficiaryClientRelationship: operation.BeneficiaryClientRelationship));
        }

        return new PageResponse<OperationResult>(result, operations.TotalCount, operations.CurrentPage, operations.PageSize);
    }
}