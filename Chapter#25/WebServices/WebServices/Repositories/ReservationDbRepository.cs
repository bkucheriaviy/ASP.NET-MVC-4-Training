using System.Collections.Generic;
using System.Linq;
using WebServices.Models;

namespace WebServices.Repositories
{
    public class ReservationDbRepository: IReservationDbRepository
    {
        private static readonly ReservationDbRepository Repository = new ReservationDbRepository();
        public static ReservationDbRepository GetInstance()
        {
            return Repository;
        }
        
        private readonly List<Reservation> _data = new List<Reservation>
        {
            new Reservation { Id= 1, ClientName="Client 1", Location = "Location 1"},
            new Reservation { Id= 2, ClientName="Client 2", Location = "Location 2"},
            new Reservation { Id= 3, ClientName="Client 3", Location = "Location 3"},
            new Reservation { Id= 4, ClientName="Client 4", Location = "Location 4"},
            new Reservation { Id= 5, ClientName="Client 5", Location = "Location 5"},

        };
        
        public IEnumerable<Reservation> GetAll()
        {
            return _data;
        }

        public Reservation GetById(int id)
        {
            return _data.FirstOrDefault(r => r.Id == id);
        }

        public Reservation Add(Reservation item)
        {
            item.Id = _data.Count + 1;
            _data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            var item = GetById(id);
            if (item != null)
                _data.Remove(item);
        }

        public bool Update(Reservation item)
        {
            var reservation = GetById(item.Id);
            if (reservation == null) 
                return false;

            reservation.ClientName = item.ClientName;
            reservation.Location = item.Location;
            return true;
        }
    }
}
