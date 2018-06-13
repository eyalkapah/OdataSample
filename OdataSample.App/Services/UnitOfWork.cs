using OdataSample.App.Models;
using OdataSample.App.Services.Interfaces;
using OdataSample.App.Services.Repositories;

namespace OdataSample.App.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MondialDbContext _context;

        public IRepository<Group> Groups { get; set; }
        public IRepository<Team> Teams { get; set; }
        public IRepository<Player> Players { get; set; }


        public UnitOfWork(MondialDbContext context)
        {
            _context = context;
            Groups = new Repository<Group>(context);
            Teams = new Repository<Team>(context);
            Players = new Repository<Player>(context);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}