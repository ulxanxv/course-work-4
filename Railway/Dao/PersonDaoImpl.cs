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

    class PersonDaoImpl : PersonDao {

        public void Add(Person obj1) {

            using (ApplicationContext context = new ApplicationContext()) {
                context.Persons.Add(obj1);

                try {
                    context.SaveChanges();
                } catch (DbUpdateException) {
                    throw new DataException("Человек с такими паспортными данными уже существует");
                }
            }
        }

        public List<string> FindAllPersons() {

            using (ApplicationContext context = new ApplicationContext()) {
                List<string> allNames = new List<string>();

                foreach (Person x in context.Persons) {
                    allNames.Add(String.Format("{0} {1} ({2} {3}. {4}.)", x.PassportSeries, x.PassportId, x.SecondName, x.FirstName[0], x.MiddleName[0]).Trim());
                }

                return allNames;
            }
        }

        public Person FindById(long id) {

            using (ApplicationContext context = new ApplicationContext()) {
                Person person = context.Persons.Find(id);

                if (person == null) {
                    throw new ObjectNotFoundException();
                }

                return person;
            }
        }

        public Person FindByPassportData(string passportSeries, string passportId) {

            using (ApplicationContext context = new ApplicationContext()) {

                Person person = context.Persons
                    .Where(x => (x.PassportSeries == passportSeries && x.PassportId == passportId))
                    .FirstOrDefault();

                if (person == null) {
                    throw new ObjectNotFoundException("Человека с такими данным не существует!");
                }

                return person;
            }
        }

        public void Merge(Person obj1) {
            
            if (obj1 == null) {
                throw new ArgumentNullException();
            }

            using (ApplicationContext context = new ApplicationContext()) {

                // Load in context
                Person person = context.Persons
                    .Where(x => x.Id == obj1.Id)
                    .FirstOrDefault();

                if (person == null) {
                    throw new ObjectNotFoundException();
                }

                person.Update = obj1;
                context.Persons.AddOrUpdate(person);
                context.SaveChanges();

            }
        }

        public void OutputInDataSource(ref DataGridView data) {

            using (ApplicationContext context = new ApplicationContext()) {
                data.DataSource = context.Persons.ToList();
            }
        }

        public void Remove(long id) {

            using (ApplicationContext context = new ApplicationContext()) {

                Person person = context.Persons
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (person == null) {
                    throw new ObjectNotFoundException();
                }

                context.Persons.Remove(person);
                context.SaveChanges();
            }
        }



    }

}
