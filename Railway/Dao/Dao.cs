using System;
using System.Windows.Forms;

namespace Railway.Dao {

    interface Dao<T> {

        void Add(T obj1);

        void Merge(T obj1);

        void Remove(long id);

        Type FindById(long id);

        void OutputInDataSource(ref DataGridView data);

    }

}
