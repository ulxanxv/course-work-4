using Railway.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway.Dao.Impl {

    class ParentDaoImpl : ParentDao {

        public void Add(Parent obj1) {
            throw new NotImplementedException();
        }

        public Type FindById(long id) {
            throw new NotImplementedException();
        }

        public void Merge(Parent obj1) {
            throw new NotImplementedException();
        }

        public void OutputInDataSource(ref DataGridView data) {
            throw new NotImplementedException();
        }

        public void Remove(long id) {
            using (ApplicationContext context = new ApplicationContext()) {
                Parent parent = context.Parents
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (parent == null) {
                    throw new ObjectNotFoundException();
                }

                context.Parents.Remove(parent);
                context.SaveChanges();
            }
        }

    }

}
