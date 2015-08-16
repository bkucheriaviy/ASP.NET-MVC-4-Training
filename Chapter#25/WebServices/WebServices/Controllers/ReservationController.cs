using System.Collections.Generic;
using System.Web.Http;
using WebServices.Models;
using WebServices.Repositories;

namespace WebServices.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationDbRepository _reservationDbRepository = ReservationDbRepository.GetInstance();

        [HttpGet]
        public IEnumerable<Reservation> GetAll()
        {
            return _reservationDbRepository.GetAll();
        }

        [HttpGet]
        public Reservation GetById(int id)
        {
            return _reservationDbRepository.GetById(id);
        }

        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return _reservationDbRepository.Add(item);
        }

        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return _reservationDbRepository.Update(item);
        }

        [HttpDelete]
        public void DeleteReservation(int id)
        {
            _reservationDbRepository.Remove(id);
        }
    }
}
