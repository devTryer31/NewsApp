using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using News.Application.News.Commands.Create;
using News.Application.News.Commands.Delete;
using News.Application.News.Commands.Update;
using News.Application.News.Queries.GetDetails;
using News.Application.News.Queries.GetNewsTitlesList;
using System;
using System.Threading.Tasks;

namespace News.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;
        public NewsController(IMediator mediator, IMapper mapper) =>
            (_mediator, _mapper) = (mediator, mapper);

        [HttpGet]
        public async Task<ActionResult<NewsTitlesListVm>> GetAll()
        {
            GetNewsTitilesListRequest request = new()
            {
                UserId = UserId
            };
            var vm = await _mediator.Send(request);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDetailsVm>> Get(Guid id)
        {
            GetNewsDetailsRequest request = new()
            {
                Id = id,
                UserId = UserId
            };
            var vm = await _mediator.Send(request);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] Models.CreateNewsDto newsDto)
        {
            var request = _mapper.Map<CreateNewsCommandRequest>(newsDto);
            request.UserId = UserId;

            Guid id = await _mediator.Send(request);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Models.UpdateNewsDto newsDto)
        {
            var request = _mapper.Map<UpdateNewsCommandRequest>(newsDto);
            request.UserId = UserId;

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsDetailsVm>> Delete(Guid id)
        {
            DeleteNewsCommandRequest request = new()
            {
                UserId = UserId,
                Id = id
            };

            var vm = await _mediator.Send(request);

            return Ok(vm);
        }
    }
}
