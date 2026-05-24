using Hasin.Application.PhoneBook.Contacts.CreateContact;
using Hasin.Application.PhoneBook.Contacts.DeleteContact;
using Hasin.Application.PhoneBook.Contacts.GetContactsByTag;
using Hasin.Application.PhoneBook.Contacts.Shared;
using Hasin.Application.PhoneBook.Contacts.UpdateContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hasin.Api.Controllers;

[ApiController]
[Route("api/contacts")]
public sealed class ContactsController : ControllerBase
{
    private readonly ISender _sender;

    public ContactsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ContactDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactDto>> Create(CreateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = await _sender.Send(new CreateContactCommand(request), cancellationToken);
        return CreatedAtAction(nameof(GetByTag), new { tag = contact.Tag }, contact);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactDto>> Update(Guid id, UpdateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = await _sender.Send(new UpdateContactCommand(id, request), cancellationToken);
        return Ok(contact);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ContactDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyCollection<ContactDto>>> GetByTag([FromQuery] string tag, CancellationToken cancellationToken)
    {
        var contacts = await _sender.Send(new GetContactsByTagQuery(tag), cancellationToken);
        return Ok(contacts);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteContactCommand(id), cancellationToken);
        return NoContent();
    }
}
