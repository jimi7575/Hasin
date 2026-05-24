using MediatR;

namespace Hasin.Application.PhoneBook.Contacts.DeleteContact;

public sealed record DeleteContactCommand(Guid Id) : IRequest;
