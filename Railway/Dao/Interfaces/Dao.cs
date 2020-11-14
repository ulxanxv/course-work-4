using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway.Dao.Interfaces {

    interface Dao<Type> {

        void Add(Type obj1);

        void Merge(Type obj1);

        void Remove(long id);

        Type FindById(long id);

        void OutputInDataSource(ref DataGridView data);

    }

}
