using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcBoard.Models;

namespace MvcBoard.Data
{
    public class MvcBoardContext : IdentityDbContext<IdentityUser>
    {   
        public MvcBoardContext (DbContextOptions<MvcBoardContext> options)
            : base(options)
        {
        }

        public DbSet<MvcBoard.Models.Board> Board { get; set; } = default!;
    }
}
