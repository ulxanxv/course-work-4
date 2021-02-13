using Railway.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway.Dao.Impl {

    class DisciplineDaoImpl : DisciplineDao {

        public void Add(Discipline obj1) {
            throw new NotImplementedException();
        }

        public Type FindById(long id) {
            throw new NotImplementedException();
        }

        public void Merge(Discipline obj1) {
            throw new NotImplementedException();
        }

        public void OutputInDataSource(ref DataGridView data) {
            using (ApplicationContext context = new ApplicationContext()) {
                data.DataSource = (from d in context.Disciplines
                                   orderby d.Id
                                   select new {
                                       d.Id,
                                       d.Name
                                   }).ToList();
            }
        }

        public void Remove(long id) {
            using (ApplicationContext context = new ApplicationContext()) {
                Discipline discipline = context.Disciplines
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (discipline == null) {
                    throw new ObjectNotFoundException();
                }

                context.Disciplines.Remove(discipline);
                context.SaveChanges();
            }
        }

    }

}
