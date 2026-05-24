using Hasin.Application.Abstractions;
using Hasin.Application.PhoneBook.Contacts.Shared;
using MediatR;

namespace Hasin.Application.PhoneBook.Contacts.CreateContact;

public sealed class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactDto>
{
    private readonly IContactService _contactService;

    public CreateContactCommandHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        return _contactService.CreateAsync(request.Contact, cancellationToken);
    }
}
