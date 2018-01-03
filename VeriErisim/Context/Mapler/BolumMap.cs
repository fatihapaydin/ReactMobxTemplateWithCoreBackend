using Domain.Varliklar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeriErisim.Context.Mapler
{
    public class BolumMap
    {
        public BolumMap(EntityTypeBuilder<Bolum> entityBuilder)
        {            
            entityBuilder.HasKey(x => x.Id);
                  
            entityBuilder.Property(x => x.Adi).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Butce).HasColumnType("money").IsRequired();
            entityBuilder.Property(x => x.Kod).HasMaxLength(5).IsRequired();
         
        }
    }
}