﻿using ArtService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(comment => comment.Id);
            builder.HasIndex(comment => comment.ParagraphId);
            builder.HasIndex(comment => comment.OwnerHandle);

            builder.Property(comment => comment.Text).HasMaxLength(300);

            builder.HasOne(comment => comment.RelatedParagraph)
                .WithMany(paragraph => paragraph.Comments)
                .HasForeignKey(comment => comment.ParagraphId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(comment => comment.SpoilerChapter)
                .WithMany()
                .HasForeignKey(comment => comment.SpoilerChapterId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
