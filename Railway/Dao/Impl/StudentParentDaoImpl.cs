using Railway.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway.Dao.Impl {

    class StudentParentDaoImpl : StudentParentDao {

        public void Add(StudentParent obj1) {
            throw new NotImplementedException();
        }

        public Type FindById(long id) {
            throw new NotImplementedException();
        }

        public void Merge(StudentParent obj1) {
            throw new NotImplementedException();
        }

        public void OutputInDataSource(ref DataGridView data) {
            throw new NotImplementedException();
        }

        public void Remove(long id) {
            using (ApplicationContext context = new ApplicationContext()) {
                StudentParent studentParent = context.StudentParents
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (studentParent == null) {
                    throw new ObjectNotFoundException();
                }

                context.StudentParents.Remove(studentParent);
                context.SaveChanges();
            }
        }

    }

}
