using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ASP.Net.MediatR.CRUD.WebLayer;

public class CRUDController<TCreateViewModel, TViewModel, TDto, TId> : BaseApiController
    where TCreateViewModel : BaseViewModel
    where TViewModel : BaseViewModel
    where TDto : BaseDto<TId>
{
    protected IMediator _mediator;
    public CRUDController(IMediator mediator, IMemoryCache cache, IMapper mapper) : base(cache, mapper) =>
        _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] TCreateViewModel viewModel, CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(el => el.Errors.Select(e => e.ErrorMessage)));

        var model = _mapper.Map<TCreateViewModel, TDto>(viewModel);

        var result = await _mediator.Send(new CreateCommand<TDto, TId>(model), cancellationToken);

        if (result.HasErrors && !result.IsSystemError)
            return BadRequest(result.Errors);

        if (result.IsSystemError)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);

        return Ok(result.Data);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllQuery<TDto, TId>(), cancellationToken);

        if (result.IsSystemError)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);

        var mappedResult = _mapper.Map<IEnumerable<TDto>, IEnumerable<TViewModel>>(result.Data);

        return Ok(mappedResult);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(TId id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetByIdQyery<TDto, TId>(id), cancellationToken);

        if (result.Data == default)
            return NotFound(result.Errors);

        if (result.IsSystemError)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);

        var mappedItem = _mapper.Map<TDto, TViewModel>(result.Data);

        return Ok(mappedItem);
    }

    [HttpPut]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromBody] TViewModel viewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.SelectMany(el => el.Errors.Select(e => e.ErrorMessage)));

        var model = _mapper.Map<TViewModel, TDto>(viewModel);

        var result = await _mediator.Send(new UpdateCommand<TDto, TId>(model), cancellationToken);

        if (result.HasErrors && !result.IsSystemError)
            return NotFound(result.Errors);

        if (result.IsSystemError)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(TId id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteCommand<TId>(id), cancellationToken);

        if (result.HasErrors && !result.IsSystemError)
            return NotFound(result.Errors);

        if (result.IsSystemError)
            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);

        return Ok(result);
    }
}
