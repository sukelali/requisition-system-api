using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RequisitionSystemApi.Data
{
    public class RequisitionSystemApiContext : DbContext
    {
        public RequisitionSystemApiContext (DbContextOptions<RequisitionSystemApiContext> options)
            : base(options)
        {
        }

        public DbSet<Requisition> Requisitions { get; set; } = default!;

        public DbSet<RequisitionItem> RequisitionItems { get; set; } = default!;
    }
}
