﻿using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data.Config
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{

		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(x => x.Id).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
			builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

			//seed data
			builder.HasData(

				new Product { Id = 1, Name = "Product 1", Description = "1", Price = 1000, CategoyId = 1 },
				new Product { Id = 2, Name = "Product 2", Description = "2", Price = 1000, CategoyId = 2 },
				new Product { Id = 3, Name = "Product 3", Description = "3", Price = 1000, CategoyId = 3 },
				new Product { Id = 4, Name = "Product 4", Description = "4", Price = 1000, CategoyId = 4 }
			);
		}
	}
}
