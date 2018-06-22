using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGEJ.Models.Entities;

namespace SGEJ.Models.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Amigo> Amigo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<EmprestimoJogo> EmprestimoJogo { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<UserAudit> UserAuditEvents { get; set; }
    }
}
