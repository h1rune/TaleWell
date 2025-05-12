using ArtService.Domain;
using ArtService.Domain.Common.ArchetypeParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class LiteraryArchetypeConfiguration : IEntityTypeConfiguration<LiteraryArchetype>
    {
        public void Configure(EntityTypeBuilder<LiteraryArchetype> builder)
        {
            builder.HasKey(archetype => archetype.Id);

            builder.HasIndex(archetype => new {
                archetype.ScopeType,
                archetype.NarrativeType,
                archetype.ToneType,
                archetype.PurposeType
            }).IsUnique();

            builder.Property(archetype => archetype.Name)
                .HasMaxLength(100);

            builder.HasData([
                new LiteraryArchetype
                {
                    Name = "Судья",
                    Id = "RBSI",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Illumination
                },
                new LiteraryArchetype
                {
                    Name = "Хроникёр",
                    Id = "RBSE",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Entertainment
                },
                new LiteraryArchetype
                {
                    Name = "Свидетель",
                    Id = "RBLI",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Illumination
                },
                new LiteraryArchetype
                {
                    Name = "Бард",
                    Id = "RBLE",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Entertainment
                },
                new LiteraryArchetype
                {
                    Name = "Мудрец",
                    Id = "RHSI",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Illumination
                },
                new LiteraryArchetype
                {
                    Name = "Отшельник",
                    Id = "RHSE",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Entertainment
                },
                new LiteraryArchetype
                {
                    Name = "Пилигрим",
                    Id = "RHLI",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Illumination,
                },
                new LiteraryArchetype
                {
                    Name = "Арлекин",
                    Id = "RHLE",
                    ScopeType = ScopeType.Realism,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Entertainment
                },
                new LiteraryArchetype
                {
                    Name = "Пророк",
                    Id = "FBSI-P",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Illumination
                },
                new LiteraryArchetype
                {
                    Name = "Герой",
                    Id = "FBSE",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Entertainment
                },
                new LiteraryArchetype
                {
                    Name = "Алхимик",
                    Id = "FBLI",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Illumination
                },
                new LiteraryArchetype
                {
                    Name = "Трикстер",
                    Id = "FBLE",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.BehaviorDynamic,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Entertainment
                },
                new LiteraryArchetype
                {
                    Name = "Оракул",
                    Id = "FHSI",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Illumination
                },
                new LiteraryArchetype
                {
                    Name = "Мистик",
                    Id = "FHSE",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Serious,
                    PurposeType = PurposeType.Entertainment
                },
                new LiteraryArchetype
                {
                    Name = "Визионер",
                    Id = "FHLI",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Illumination
                },
                new LiteraryArchetype
                {
                    Name = "Чародей",
                    Id = "FHLE",
                    ScopeType = ScopeType.Fiction,
                    NarrativeType = NarrativeType.HumanOriented,
                    ToneType = ToneType.Light,
                    PurposeType = PurposeType.Entertainment
                }
            ]);
        }
    }
}
