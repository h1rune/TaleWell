using ChannelService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChannelService.Persistence.EntityTypeConfigurations
{
    public class TariffPaymentConfiguration : IEntityTypeConfiguration<TariffPayment>
    {
        public void Configure(EntityTypeBuilder<TariffPayment> builder)
        {
            builder.HasKey(payment => payment.Id);
            builder.HasOne(payment => payment.Channel)
                .WithMany()
                .HasForeignKey(payment => payment.ChannelId);
        }
    }
}
