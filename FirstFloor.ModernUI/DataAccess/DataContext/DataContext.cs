using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities;

namespace DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new DbInitializer());
            Database.Connection.ConnectionString = @"Server=(LocalDB)\v11.0;Database=Sudacad;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=180";
        }

        public DbSet<Trainee> Trainees { get; set; }
    }
}