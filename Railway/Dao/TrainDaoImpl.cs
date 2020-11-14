using Railway.Dao.Interfaces;
using Railway.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace Railway.Dao {

    class TrainDaoImpl : TrainDao {

        public void Add(Train obj1) {

            using (ApplicationContext context = new ApplicationContext()) {
                TrainType trainType = context.TrainTypes.Find(obj1.TypeId);

                obj1.Type           = trainType;

                context.Trains.Add(obj1);

                try {
                    context.SaveChanges();
                } catch (DbUpdateException) {
                    throw new DataException("Такая модель поезда уже существует!");
                }
            }
        }

        public List<string> FindAllModels() {

            using (ApplicationContext context = new ApplicationContext()) {
                List<string> allModels = new List<string>();

                foreach (Train x in context.Trains) {
                    allModels.Add(x.Model);
                }

                return allModels;
            }
        }

        public Train FindById(long id) {

            using (ApplicationContext context = new ApplicationContext()) {
                Train train = context.Trains.Find(id);

                if (train == null) {
                    throw new ObjectNotFoundException();
                }

                return train;
            }
        }

        public Train FindByModel(string model) {

            using (ApplicationContext context = new ApplicationContext()) {
                Train train = context.Trains
                    .Where(x => x.Model == model)
                    .FirstOrDefault();

                if (train == null) {
                    throw new ObjectNotFoundException();
                }

                return train;
            }
        }

        public void Merge(Train obj1) {

            if (obj1 == null) {
                throw new ArgumentNullException();
            }

            using (ApplicationContext context = new ApplicationContext()) {
                Train train = context.Trains
                    .Where(x => x.Id == obj1.Id)
                    .FirstOrDefault();

                if (train == null) {
                    throw new ObjectNotFoundException();
                }

                train.Update = obj1;
                context.Trains.AddOrUpdate(train);
                context.SaveChanges();
            }
        }

        public void OutputInDataSource(ref DataGridView data) {

            using (ApplicationContext context = new ApplicationContext()) {
                data.DataSource = (from t in context.Trains
                                   orderby t.Id
                                   select new {
                                       t.Id,
                                       t.TypeId,
                                       t.Model,
                                       t.MaxSpeed,
                                       t.AmountSeat,
                                       t.ManufacturerCountry
                                   }).ToList();
            }
        }

        public void Remove(long id) {

            using (ApplicationContext context = new ApplicationContext()) {
                Train train = context.Trains
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (train == null) {
                    throw new ObjectNotFoundException();
                }

                context.Trains.Remove(train);
                context.SaveChanges();
            }
        }

    }

}
