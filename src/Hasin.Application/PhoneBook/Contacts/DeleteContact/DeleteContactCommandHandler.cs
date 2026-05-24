using Hasin.Application.Abstractions;
using MediatR;

namespace Hasin.Application.PhoneBook.Contacts.DeleteContact;

public sealed class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IContactService _contactService;

    public DeleteContactCommandHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        return _contactService.DeleteAsync(request.Id, cancellationToken);
    }
}
