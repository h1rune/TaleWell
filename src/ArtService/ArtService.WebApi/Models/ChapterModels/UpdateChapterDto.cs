﻿using ArtService.Application.Chapters.Commands.UpdateChapter;
using ArtService.Application.Common.Mappings;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.ChapterModels
{
    public class UpdateChapterDto : IMapWith<UpdateChapterCommand>
    {
        [SwaggerSchema("Order of chapter in volume")]
        public int Order { get; set; }

        [SwaggerSchema("Title of chapter")]
        public string? Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateChapterDto, UpdateChapterCommand>();
        }
    }
}
