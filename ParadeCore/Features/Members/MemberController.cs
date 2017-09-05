using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ParadeCore.Features.Members
{
    [Produces("application/json")]
    [Route("api/Member")]
    public class MemberController : Controller
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Route("")]
        public async Task<IActionResult> GetMembers(GetMembers.Query query)
        {
            var model = await _mediator.Send(query);
            return Ok(model);
        }

        [Route("{id:int}")]
        public async Task<IActionResult> GetMemberById(GetMemberById.Query query)
        {
            var model = await _mediator.Send(query);
            return Ok(model);
        }
    }
}