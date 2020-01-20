using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class NewsletterRepository : Repository<Newsletter>,INewsletterRepository
    {
        private readonly ICasinoDbContext _context;
        public NewsletterRepository(ICasinoDbContext context):base(context)
        {
            this._context = context;//new CasinoDbContext();
        }
        public bool EmailExistsInNewsletter(string email)
        {
            return _context.Newsletters.Any(m => m.Email.ToLower() == email.ToLower());
        }
    }
}
