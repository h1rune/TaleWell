﻿using MediatR;

namespace ArtService.Application.Chapters.Commands.DeleteChapter
{
    public class DeleteChapterCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid ChapterId { get; set; }
    }
}
