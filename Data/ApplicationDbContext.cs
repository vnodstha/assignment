using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MachineLearningCompany.Models;

namespace MachineLearningCompany.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MachineLearningCompany.Models.MachineLearningCompanyFeedback> MachineLearningCompanyFeedback { get; set; }
    }
}
