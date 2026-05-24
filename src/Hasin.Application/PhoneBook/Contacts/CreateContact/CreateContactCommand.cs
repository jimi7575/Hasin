using MediatR;
using Hasin.Application.PhoneBook.Contacts.Shared;

namespace Hasin.Application.PhoneBook.Contacts.CreateContact;

public sealed record CreateContactCommand(CreateContactRequest Contact) : IRequest<ContactDto>;
