using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tti.Estate.Data.Entities;

namespace Tti.Estate.Data
{
    public partial class AppDbContext
    {
        protected void ConfigureCountyData(EntityTypeBuilder<County> builder)
        {
            builder.HasData(
                new County { Id = 2, Code = "RIGA", Name = "Rīga" },
                new County { Id = 4, Code = "JELGAVA", Name = "Jelgava" }
                
           );
        }

        protected void ConfigureCityData(EntityTypeBuilder<City> builder)
        {

        }
    }
}
