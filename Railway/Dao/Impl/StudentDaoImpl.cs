using Railway.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway.Dao.Impl {

    class StudentDaoImpl : StudentDao {

        public void Add(Student obj1) {
            throw new NotImplementedException();
        }

        public Type FindById(long id) {
            throw new NotImplementedException();
        }

        public void Merge(Student obj1) {
            throw new NotImplementedException();
        }

        public void OutputInDataSource(ref DataGridView data) {
            using (ApplicationContext context = new ApplicationContext()) {
                data.DataSource = (from s in context.Students
                                   orderby s.Id
                                   select new {
                                       s.FirstName,
                                       s.LastName,
                                       s.MiddleName,
                                       s.Gender,
                                       s.DateOfBirth,
                                       s.Phone,
                                       s.Address
                                   }).ToList();
            }
        }

        public void Remove(long id) {
            using (ApplicationContext context = new ApplicationContext()) {
                Student student = context.Students
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (student == null) {
                    throw new ObjectNotFoundException();
                }

                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

    }

}
