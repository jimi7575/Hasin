using Hasin.Application.Abstractions;
using Hasin.Application.PhoneBook.Contacts.Shared;
using MediatR;

namespace Hasin.Application.PhoneBook.Contacts.GetContactsByTag;

public sealed class GetContactsByTagQueryHandler : IRequestHandler<GetContactsByTagQuery, IReadOnlyCollection<ContactDto>>
{
    private readonly IContactService _contactService;

    public GetContactsByTagQueryHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public Task<IReadOnlyCollection<ContactDto>> Handle(GetContactsByTagQuery request, CancellationToken cancellationToken)
    {
        return _contactService.GetByTagAsync(request.Tag, cancellationToken);
    }
}
