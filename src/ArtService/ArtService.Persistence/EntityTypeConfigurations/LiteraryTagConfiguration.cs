using ArtService.Domain;
using ArtService.Domain.Common.ArchetypeParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtService.Persistence.EntityTypeConfigurations
{
    public class LiteraryTagConfiguration : IEntityTypeConfiguration<LiteraryTag>
    {
        public void Configure(EntityTypeBuilder<LiteraryTag> builder)
        {
            builder.HasKey(tag => tag.Id);
            builder.HasIndex(tag => new { 
                tag.ScopeType, 
                tag.NarrativeType, 
                tag.ToneType, 
                tag.PurposeType 
            });

            builder.Property(tag => tag.Name)
                .HasMaxLength(100);

            builder.HasData([
                new LiteraryTag { Name = "От первого лица", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Ненадёжный рассказчик", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Письма", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Нелинейность", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                 
                new LiteraryTag { Name = "Антигерой", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Моральный выбор", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Рост героя", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Трагедия", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Внутренний конфликт", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Наставник", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Предательство", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Entertainment },
                 
                new LiteraryTag { Name = "Исторический сеттинг", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Футуризм", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Дистопия", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Утопия", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Система магии", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Инопланетная цивилизация", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Альтернативная реальность", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Природа", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Городская среда", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Постапокалипсис", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Entertainment },
                 
                new LiteraryTag { Name = "Политика", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Общество", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Поиск смысла", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Любовь", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Смерть", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Свобода", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Человеческая природа", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Отчуждение", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                 
                new LiteraryTag { Name = "Интрига", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Эмоции", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Трагизм", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Юмор", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Страх", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Ностальгия", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Надежда", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                
                new LiteraryTag { Name = "Философия", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Критика", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Обучение", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Эскапизм", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Аллегория", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                
                new LiteraryTag { Name = "Символизм", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Сатира", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Минимализм", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Архаизм", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                
                new LiteraryTag { Name = "Рефлексия", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Интерактивность", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Метастиль", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Обращение", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Открытый финал", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Вызов нормам", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                
                new LiteraryTag { Name = "Приключения", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Романтика", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Детектив", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Добро и зло", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Поколения", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Судьба", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Спасение мира", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Light, PurposeType = PurposeType.Entertainment },
                new LiteraryTag { Name = "Родственные связи", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Бегство", ScopeType = ScopeType.Fiction, NarrativeType = NarrativeType.BehaviorDynamic, ToneType = ToneType.Serious, PurposeType = PurposeType.Entertainment },
                 
                new LiteraryTag { Name = "Психология", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Страхи", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Желания", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Самооценка", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Тревожность", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Осознание", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Изменения", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Память", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Одиночество", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Serious, PurposeType = PurposeType.Illumination },
                new LiteraryTag { Name = "Семья", ScopeType = ScopeType.Realism, NarrativeType = NarrativeType.HumanOriented, ToneType = ToneType.Light, PurposeType = PurposeType.Illumination }
            ]);
        }
    }
}
