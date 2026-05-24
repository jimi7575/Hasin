using MediatR;
using Hasin.Application.PhoneBook.Contacts.Shared;

namespace Hasin.Application.PhoneBook.Contacts.UpdateContact;

public sealed record UpdateContactCommand(Guid Id, UpdateContactRequest Contact) : IRequest<ContactDto>;
