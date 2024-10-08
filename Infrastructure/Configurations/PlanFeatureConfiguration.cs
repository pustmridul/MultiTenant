﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class PlanFeatureConfiguration:IEntityTypeConfiguration<PlanFeature>
    {
        public void Configure(EntityTypeBuilder<PlanFeature> builder)
        {
            builder.ToTable("PlanFeature");
            builder.HasKey(e => new { e.Id });
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(e => e.Feature)
              .WithMany(e => e.PlanFeatures)
              .HasForeignKey(e => e.FeatureId)
              .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Plan)
            .WithMany(e => e.PlanFeatures)
            .HasForeignKey(e => e.PlanId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
