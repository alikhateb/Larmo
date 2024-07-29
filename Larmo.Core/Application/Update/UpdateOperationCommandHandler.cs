﻿using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using MediatR;

namespace Larmo.Core.Application.Update;

internal class UpdateOperationCommandHandler(IOperationRepository operationRepository)
    : IRequestHandler<UpdateOperationCommand>
{
    public async Task Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
    {
        var operation = new Operation
        {
            BeneficiaryActivity = request.BeneficiaryActivity,
            BeneficiaryArea = request.BeneficiaryArea,
            BeneficiaryCity = request.BeneficiaryCity,
            BeneficiaryClientRelationship = request.BeneficiaryClientRelationship,
            BeneficiaryCountry = request.BeneficiaryCountry,
            BeneficiaryName = request.BeneficiaryName,
            BeneficiaryNearestMilestone = request.BeneficiaryNearestMilestone,
            ClientArea = request.ClientArea,
            ClientCity = request.ClientCity,
            ClientCountry = request.ClientCountry,
            ClientIdentityNumber = request.ClientIdentityNumber,
            ClientNearestMilestone = request.ClientNearestMilestone,
            ClientProfession = request.ClientProfession,
            CurrencyType = request.CurrencyType,
            ReceivingParty = request.ReceivingParty,
            SendingParty = request.SendingParty,
            SourceOfFunds = request.SourceOfFunds,
            Iban = request.Iban
        };

        operation.SetAmount(request.Amount);
        operation.SetDate(request.Date);
        operation.SetOperationType(request.OperationType);
        operation.SetId(request.GetOperationId());
        await operationRepository.UpdateAsync(operation, cancellationToken);
    }
}