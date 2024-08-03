using Larmo.Core.Repository;
using Larmo.Shared.Application.Paging;
using Larmo.Shared.Extension;
using MediatR;

namespace Larmo.Core.Application.Notifications.GetViewCollection;

public sealed class GetNotificationCollectionQueryHandler(INotificationRepository notificationRepository)
    : IRequestHandler<GetNotificationCollectionQuery, PageResponse<NotificationResult>>
{
    public async Task<PageResponse<NotificationResult>> Handle(GetNotificationCollectionQuery request, CancellationToken cancellationToken)
    {
        var notifications = await notificationRepository.AsPage(new NotificationSpecification())
            .WithPagingOptions(request, cancellationToken);

        var results = new List<NotificationResult>();
        foreach (var item in notifications.Items)
        {
            results.Add(new NotificationResult
            {
                Area = item.Area,
                City = item.City,
                Email = item.Email,
                Employer = item.Employer,
                FullName = item.FullName,
                Gender = item.Gender.ToString(),
                IdentityExpiryDate = item.IdentityExpiryDate,
                IdentityIssueDate = item.IdentityIssueDate,
                IdentityNumber = item.IdentityNumber,
                IsLibyanNationality = item.IsLibyanNationality,
                MaritalStatus = item.MaritalStatus.ToString(),
                MotherName = item.MotherName,
                Nationality = item.Nationality,
                NearestMilestone = item.NearestMilestone,
                PassportNumber = item.PassportNumber,
                PassportNumberExpiryDate = item.PassportNumberExpiryDate,
                PassportNumberIssueDate = item.PassportNumberIssueDate,
                PhoneNumber = item.PhoneNumber,
                Profession = item.Profession,
                Street = item.Street,
                StartWorkDate = item.StartWorkDate,
                Resident = item.Resident,
                Id = item.Id,
                IsChecked = item.IsChecked
            });
        }

        return new PageResponse<NotificationResult>(data: results, count: notifications.TotalCount,
            page: notifications.CurrentPage, pageSize: notifications.PageSize);
    }
}