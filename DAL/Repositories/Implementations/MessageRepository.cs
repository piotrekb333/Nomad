﻿using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly ICasinoDbContext _context;
        public MessageRepository(ICasinoDbContext context) : base(context)
        {
            this._context = context;//new CasinoDbContext();
        }
    }
}
