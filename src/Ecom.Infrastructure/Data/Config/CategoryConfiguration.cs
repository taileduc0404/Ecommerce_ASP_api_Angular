﻿using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrastructure.Data.Config
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(30).IsRequired();


			//seed data
			builder.HasData(

				new Category { Id = 1, Name = "Category 1", Description = "1" },
				new Category { Id = 2, Name = "Category 2", Description = "2" },
				new Category { Id = 3, Name = "Category 3", Description = "3" },
				new Category { Id = 4, Name = "Category 4", Description = "4" }
			);
		}
	}
}
