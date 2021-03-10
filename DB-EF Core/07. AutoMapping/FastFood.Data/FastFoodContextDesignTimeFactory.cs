using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Data
{
    public class FastFoodContextDesignTimeFactory : IDesignTimeDbContextFactory<FastFoodContext>
    {
        public FastFoodContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FastFoodContext>();
            builder.UseSqlServer("Server=DESKTOP-H1L2UK7\\MSSQLSERVER01;Database=FastFood;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new FastFoodContext(builder.Options);
        }
    }
}
