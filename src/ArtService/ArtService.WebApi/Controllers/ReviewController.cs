using ArtService.Application.Reviews.Commands.CreateReview;
using ArtService.Application.Reviews.Commands.DeleteReview;
using ArtService.Application.Reviews.Commands.UpdateReview;
using ArtService.Application.Reviews.Queries.GetReview;
using ArtService.Application.Reviews.Queries.GetWorkReviews;
using ArtService.WebApi.Models.ReviewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtService.WebApi.Controllers
{
    [Route("[controller]")]
    public class ReviewController(IMediator mediator, IMapper mapper) : BaseController(mediator)
    {
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Создает новый отзыв о произведении.
        /// </summary>
        /// <param name="createDto">DTO для создания отзыва.</param>
        /// <returns>Идентификатор созданного отзыва.</returns>
        /// <response code="200">Возвращает идентификатор созданного отзыва.</response>
        /// <response code="400">Если входные данные некорректны.</response>
        /// <response code="401">Если пользователь не авторизован.</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Guid), 200)]  // Атрибут для успешного ответа с идентификатором
        [ProducesResponseType(400)]  // Атрибут для ошибки валидации
        [ProducesResponseType(401)]  // Атрибут для ошибки авторизации
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReviewDto createDto)
        {
            var createCommand = _mapper.Map<CreateReviewCommand>(createDto);
            createCommand.UserId = UserId;
            var reviewId = await Mediator.Send(createCommand);
            return Ok(reviewId);
        }

        /// <summary>
        /// Обновляет существующий отзыв о произведении.
        /// </summary>
        /// <param name="updateDto">DTO для обновления отзыва.</param>
        /// <returns>Результат обновления отзыва.</returns>
        /// <response code="204">Отзыв успешно обновлен.</response>
        /// <response code="400">Если входные данные некорректны.</response>
        /// <response code="401">Если пользователь не авторизован.</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(204)]  // Атрибут для успешного ответа без контента
        [ProducesResponseType(400)]  // Атрибут для ошибки валидации
        [ProducesResponseType(401)]  // Атрибут для ошибки авторизации
        public async Task<IActionResult> Update([FromBody] UpdateReviewDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdateReviewCommand>(updateDto);
            updateCommand.UserId = UserId;
            await Mediator.Send(updateCommand);
            return NoContent();
        }

        /// <summary>
        /// Удаляет отзыв о произведении.
        /// </summary>
        /// <param name="reviewId">Идентификатор отзыва, который необходимо удалить.</param>
        /// <returns>Результат удаления отзыва.</returns>
        /// <response code="204">Отзыв успешно удален.</response>
        /// <response code="400">Если входные данные некорректны.</response>
        /// <response code="401">Если пользователь не авторизован.</response>
        [HttpDelete("{reviewId}")]
        [Authorize]
        [ProducesResponseType(204)]  // Атрибут для успешного ответа без контента
        [ProducesResponseType(400)]  // Атрибут для ошибки валидации
        [ProducesResponseType(401)]  // Атрибут для ошибки авторизации
        public async Task<IActionResult> Delete(Guid reviewId)
        {
            var deleteCommand = new DeleteReviewCommand
            {
                UserId = UserId,
                ReviewId = reviewId
            };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

        /// <summary>
        /// Получает отзыв по его идентификатору.
        /// </summary>
        /// <param name="reviewId">Идентификатор отзыва.</param>
        /// <returns>Отзыв о произведении.</returns>
        /// <response code="200">Возвращает найденный отзыв.</response>
        /// <response code="404">Если отзыв с указанным идентификатором не найден.</response>
        [HttpGet("{reviewId}")]
        [ProducesResponseType(typeof(ReviewVm), 200)]  // Атрибут для успешного ответа с данными
        [ProducesResponseType(404)]  // Атрибут для ошибки "не найдено"
        public async Task<ActionResult<ReviewVm>> Get(Guid reviewId)
        {
            var query = new GetReviewQuery { ReviewId = reviewId };
            var reviewVm = await Mediator.Send(query);
            return Ok(reviewVm);
        }

        /// <summary>
        /// Получает список отзывов для конкретного произведения.
        /// </summary>
        /// <param name="workReviewsDto">DTO с параметрами запроса для получения отзывов.</param>
        /// <returns>Список отзывов о произведении.</returns>
        /// <response code="200">Возвращает список отзывов.</response>
        /// <response code="400">Если входные данные некорректны.</response>
        [HttpGet("list")]
        [ProducesResponseType(typeof(WorkReviewsVm), 200)]  // Атрибут для успешного ответа с данными
        [ProducesResponseType(400)]  // Атрибут для ошибки валидации
        public async Task<ActionResult<WorkReviewsVm>> GetWorkReviews([FromQuery] GetWorkReviewsDto workReviewsDto)
        {
            var query = _mapper.Map<GetWorkReviewsQuery>(workReviewsDto);
            var workReviewsVm = await Mediator.Send(query);
            return Ok(workReviewsVm);
        }
    }
}
