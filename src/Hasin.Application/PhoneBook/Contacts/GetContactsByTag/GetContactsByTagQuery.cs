using MediatR;
using Hasin.Application.PhoneBook.Contacts.Shared;

namespace Hasin.Application.PhoneBook.Contacts.GetContactsByTag;

public sealed record GetContactsByTagQuery(string Tag) : IRequest<IReadOnlyCollection<ContactDto>>;
