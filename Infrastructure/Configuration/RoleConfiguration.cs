using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
	 new IdentityRole
	 {
		 Name = "User",
		 NormalizedName = "USER"
	 },
	 new IdentityRole
	 {
		 Name = "Admin",
		 NormalizedName = "ADMIN"
	 }
	 );
		}
	}
}
 // after this step go to DbContext and apply this file by modelbuilder 