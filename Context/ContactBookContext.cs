using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Models;

namespace ProjetoMVC.Context
{
    public class ContactBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        
        public ContactBookContext(DbContextOptions<ContactBookContext> options)
            : base(options)
        {
        }
    }
}
