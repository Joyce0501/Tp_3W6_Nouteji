using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Models.Data
{
    public class JulieProDbContext: DbContext
    {
        public JulieProDbContext(DbContextOptions<JulieProDbContext> options) : base(options)
        {

        }

    }
}
