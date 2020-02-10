using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class StreetAddress
    {
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
    }

    public class Distributor
    {
        public int Id { get; set; }
        public string name { get; set; } = "";
        public ICollection<StreetAddress> ShippingCenters { get; set; } = null!;
        public StreetAddress ShippingCenter { get; set; } = null!;
    }

    public class DistributorConfiguration : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.OwnsOne(p => p.ShippingCenter);
            builder.OwnsMany(p => p.ShippingCenters, a =>
            {
                a.WithOwner().HasForeignKey("OwnerId");
                a.Property<int>("Id");
                a.HasKey("Id");
            });
        }
    }
}
