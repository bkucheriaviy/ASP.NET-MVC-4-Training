using System.Collections.Generic;
using WebServices.Models;

namespace WebServices.Repositories
{
    public interface IReservationDbRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation GetById(int id);
        Reservation Add(Reservation item);
        void Remove(int id);
        bool Update(Reservation item);
    }
}
