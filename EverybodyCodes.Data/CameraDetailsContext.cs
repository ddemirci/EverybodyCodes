using EverybodyCodes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EverybodyCodes.Data
{
    public class CameraDetailsContext : DbContext
    {
        public DbSet<CameraDetails> CameraDetails { get; set; }
        public CameraDetailsContext(DbContextOptions<CameraDetailsContext> options)
            : base(options)
        {
        }
    }
}
