using System;
using System.Data.Entity;
using System.Linq;

namespace Projet_Quiz_En_Ligne.Models
{
    public class MyContext : DbContext
    {

        public MyContext()
            : base("name=MyContext")
        {
        }


       public virtual DbSet<User> Users { get; set; }
     
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}