using Railway.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway.Dao.Impl {

    class StudentPerformanceDaoImpl : StudentPerformanceDao {

        public void Add(StudentPerformance obj1) {
            throw new NotImplementedException();
        }

        public Type FindById(long id) {
            throw new NotImplementedException();
        }

        public void Merge(StudentPerformance obj1) {
            throw new NotImplementedException();
        }

        public void OutputInDataSource(ref DataGridView data) {
            using (ApplicationContext context = new ApplicationContext()) {
                data.DataSource = (from sp in context.StudentPerformances
                                   orderby sp.Id
                                   select new {
                                       sp.StudentId,
                                       sp.DisciplineId,
                                       sp.TeacherSurname,
                                       sp.AmountOfHours,
                                       sp.Rating,
                                       sp.Date
                                   }).ToList();
            }
        }

        public void Remove(long id) {
            using (ApplicationContext context = new ApplicationContext()) {
                StudentPerformance studentPerformance = context.StudentPerformances
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (studentPerformance == null) {
                    throw new ObjectNotFoundException();
                }

                context.StudentPerformances.Remove(studentPerformance);
                context.SaveChanges();
            }
        }

    }

}
