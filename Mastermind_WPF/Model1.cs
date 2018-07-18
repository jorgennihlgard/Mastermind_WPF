namespace Mastermind_WPF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Pin> Pins { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Point> Points { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
