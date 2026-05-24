using Hasin.Application.Abstractions;
using Hasin.Application.PhoneBook.Contacts.Shared;
using MediatR;

namespace Hasin.Application.PhoneBook.Contacts.UpdateContact;

public sealed class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ContactDto>
{
    private readonly IContactService _contactService;

    public UpdateContactCommandHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public Task<ContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        return _contactService.UpdateAsync(request.Id, request.Contact, cancellationToken);
    }
}
