using Railway.Entity;
using System.Collections.Generic;

namespace Railway.Dao.Interfaces {

    interface TrainTypeDao : Dao<TrainType> {

        TrainType FindByName(string name);

        List<string> FindAllNames();

    }

}
