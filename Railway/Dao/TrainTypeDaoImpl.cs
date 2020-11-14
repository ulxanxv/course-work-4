using Railway.Dao.Interfaces;
using Railway.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace Railway.Dao {

    class TrainTypeDaoImpl : TrainTypeDao {

        public void Add(TrainType obj1) {

            using (ApplicationContext context = new ApplicationContext()) {
                context.TrainTypes.Add(obj1);

                try {
                    context.SaveChanges();
                } catch (DbUpdateException) {
                    throw new DataException("Такой тип поезда уже существует!");
                }
            }
        }

        public List<string> FindAllNames() {

            using (ApplicationContext context = new ApplicationContext()) {
                List<string> allNames = new List<string>();

                foreach (TrainType x in context.TrainTypes) {
                    allNames.Add(x.Name);
                }

                return allNames;
            }
        }

        public TrainType FindById(long id) {

            using (ApplicationContext context = new ApplicationContext()) {
                TrainType trainType = context.TrainTypes.Find(id);

                if (trainType == null) {
                    throw new ObjectNotFoundException();
                }

                return trainType;
            }
        }

        public TrainType FindByName(string name) {

            using (ApplicationContext context = new ApplicationContext()) {
                TrainType trainType = context.TrainTypes
                    .Where(x => (x.Name == name))
                    .FirstOrDefault();

                if (trainType == null) {
                    throw new ObjectNotFoundException("Такого типа поезда не существует!");
                }

                return trainType;
            }
        }

        public void Merge(TrainType obj1) {

            if (obj1 == null) {
                throw new ArgumentNullException();
            }

            using (ApplicationContext context = new ApplicationContext()) {
                TrainType trainType = context.TrainTypes
                    .Where(x => x.Id == obj1.Id)
                    .FirstOrDefault();

                if (trainType == null) {
                    throw new ObjectNotFoundException();
                }

                trainType.Update = obj1;
                context.TrainTypes.AddOrUpdate(trainType);
                context.SaveChanges();

            }
        }

        public void OutputInDataSource(ref DataGridView data) {

            using (ApplicationContext context = new ApplicationContext()) {
                data.DataSource = (from tt in context.TrainTypes
                                   orderby tt.Id
                                   select new {
                                       tt.Id,
                                       tt.Name
                                   }).ToList();
            }
        }

        public void Remove(long id) {

            using (ApplicationContext context = new ApplicationContext()) {
                TrainType trainType = context.TrainTypes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (trainType == null) {
                    throw new ObjectNotFoundException();
                }

                context.TrainTypes.Remove(trainType);
                context.SaveChanges();
            }
        }

    }

}
