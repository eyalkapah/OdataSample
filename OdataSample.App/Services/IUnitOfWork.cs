using OdataSample.App.Models;
using OdataSample.App.Services.Interfaces;

namespace OdataSample.App.Services
{
    public interface IUnitOfWork
    {
        IRepository<Group> Groups { get; set; }
        IRepository<Team> Teams { get; set; }
        IRepository<Player> Players { get; set; }
        bool SaveChanges();
    }
}