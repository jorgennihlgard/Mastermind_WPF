namespace Mastermind_WPF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=MasterCon")
        {
        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Pin> Pins { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
