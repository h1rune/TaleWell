﻿using MediatR;

namespace ArtService.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public required string OwnerHandle { get; set; }
        public Guid ParagraphId { get; set; }
        public required string Text { get; set; }
        public bool IsSpoiler { get; set; }
        public Guid? SpoilerChapterId { get; set; }
    }
}
