using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                Phone p1 = new Phone { Name = "Samsung Galaxy S7", Price = 20000 };
                Phone p2 = new Phone { Name = "iPhone 7", Price = 28000 };

                // добавление
                db.Phones.Add(p1);
                db.Phones.Add(p2);
                db.SaveChanges();   // сохранение изменений

                var phones = db.Phones.ToList();
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1} - {2}", p.Id, p.Name, p.Price);
            }
        }
        public class Phone
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }
        public class PhoneContext : DbContext
        {
            public PhoneContext() : base("DefaultConnection")
            { }

            public DbSet<Phone> Phones { get; set; }
        }
    }
}
