using ArtService.Application.Chapters.Commands.CreateChapter;
using ArtService.Application.Chapters.Commands.DeleteChapter;
using ArtService.Application.Chapters.Commands.UpdateChapter;
using ArtService.Application.Chapters.Queries.GetChapter;
using ArtService.Application.Paragraphs.Queries.GetChapterParagraphs;
using ArtService.WebApi.Models.ChapterModels;
using ArtService.WebApi.Models.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Controllers
{
    public class ChaptersController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Chapter was successfully added to database.", typeof(Guid))]
        [EndpointDescription("This operation writes to database information about new chapter of volume and return the ID.")]
        public async Task<ActionResult<Guid>> Create(
            [FromBody, SwaggerRequestBody("Information about new chapter")] 
            CreateChapterDto createDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateChapterCommand>(createDto);
            command.UserId = UserId;
            var chapterId = await Mediator.Send(command, cancellationToken);
            var location = Url.Action(nameof(Get), "Chapters", new {chapterId});
            return Created(location, chapterId);
        }

        [HttpPut("{chapterId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Chapter was successfully updated.")]
        [EndpointDescription("This operation updates information about chapter by ID.")]
        public async Task<IActionResult> Update(
            [SwaggerParameter("ID of updating chapter")]
            Guid chapterId,
            [FromBody, SwaggerRequestBody("Information about chapter")] 
            UpdateChapterDto updateDto,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateChapterCommand>(updateDto);
            command.UserId = UserId;
            command.ChapterId = chapterId;    
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{chapterId:guid}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User is unauthorized.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Chapter was successfully deleted.")]
        [EndpointDescription("This operation deletes information about chapter by ID.")]
        public async Task<IActionResult> Delete(
            [SwaggerParameter("ID of chapter to delete")]
            Guid chapterId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteChapterCommand
            {
                UserId = UserId,
                ChapterId = chapterId
            };
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{chapterId}")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Chapter was successfully received.", typeof(ChapterVm))]
        [EndpointDescription("This operation receives information about volume by ID.")]
        public async Task<ActionResult<ChapterVm>> Get(
            [SwaggerParameter("ID of chapter to receive")]
            Guid chapterId,
            CancellationToken cancellationToken)
        {
            var query = new GetChapterQuery { ChapterId = chapterId };
            var chapterVm = await Mediator.Send(query, cancellationToken); 
            return Ok(chapterVm);
        }

        [HttpGet("{chapterId}/paragraphs")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status200OK, "Chapter's paragraphs were successfully received.", typeof(ChapterParagraphsVm))]
        [EndpointDescription("This operation receives information about paragraphs of chapter by ID.")]
        public async Task<ActionResult<ChapterParagraphsVm>> GetParagraphs(
            [SwaggerParameter("ID of chapter")]
            Guid chapterId,
            [FromQuery, SwaggerParameter("Offset and limit for received list.")]
            ListSettingsDto settingsDto,
            CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetChapterParagraphsQuery>(settingsDto);
            query.ChapterId = chapterId;
            var paragraphsVm = await Mediator.Send(query, cancellationToken);
            return Ok(paragraphsVm);
        }
    }
}
