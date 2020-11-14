using Railway.Dao.Interfaces;
using Railway.Entity;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace Railway.Dao {

    class RailwayTicketDaoImpl : RailwayTicketDao {

        public void Add(RailwayTicket obj1) {

            using (ApplicationContext context = new ApplicationContext()) {
                Person person   = context.Persons.Find(obj1.PersonId);
                Train train     = context.Trains.Find(obj1.TrainId);

                train.RailwayTickets.Add(obj1);
                obj1.Person = person;
                obj1.Train  = train;

                context.RailwayTickets.Add(obj1);

                try {
                    context.SaveChanges();
                } catch (DbUpdateException) {
                    throw new DataException("Место уже занято!");
                }
            }
        }



        public RailwayTicket FindById(long id) {

            using (ApplicationContext context = new ApplicationContext()) {
                RailwayTicket railwayTicket = context.RailwayTickets.Find(id);

                if (railwayTicket == null) {
                    throw new ObjectNotFoundException();
                }

                return railwayTicket;
            }
        }

        public RailwayTicket FindBySeatInTrain(int cattiageNumber, int seatOfCarriage) {

            using (ApplicationContext context = new ApplicationContext()) {
                RailwayTicket railwayTicket = context.RailwayTickets
                    .Where(x => (x.CarriageNumber == cattiageNumber && x.SeatOfCarriage == seatOfCarriage))
                    .FirstOrDefault();

                if (railwayTicket == null) {
                    throw new ObjectNotFoundException();
                }

                return railwayTicket;
            }
        }

        public void Merge(RailwayTicket obj1) {

            if (obj1 == null) {
                throw new ArgumentNullException();
            }

            using (ApplicationContext context = new ApplicationContext()) {
                RailwayTicket railwayTicket = context.RailwayTickets
                    .Where(x => x.Id == obj1.Id)
                    .FirstOrDefault();

                if (railwayTicket == null) {
                    throw new ObjectNotFoundException();
                }

                railwayTicket.Update = obj1;
                context.RailwayTickets.AddOrUpdate(railwayTicket);
                context.SaveChanges();
            }
        }

        public void OutputInDataSource(ref DataGridView data) {

            using (ApplicationContext context = new ApplicationContext()) {
                data.DataSource = (from rt in context.RailwayTickets
                                   orderby rt.Id
                                   select new {
                                       rt.Id,
                                       rt.TrainId,
                                       rt.PersonId,
                                       rt.PointOfDeparture,
                                       rt.PointOfArrival,
                                       rt.DepartureTime,
                                       rt.ArrivalTime,
                                       rt.CarriageNumber,
                                       rt.SeatOfCarriage,
                                       rt.TicketPrice
                                   }).ToList();
            }
        }

        public void Remove(long id) {

            using (ApplicationContext context = new ApplicationContext()) {
                RailwayTicket railwayTicket = context.RailwayTickets
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (railwayTicket == null) {
                    throw new ObjectNotFoundException();
                }

                context.RailwayTickets.Remove(railwayTicket);
                context.SaveChanges();
            }
        }

    }

}
