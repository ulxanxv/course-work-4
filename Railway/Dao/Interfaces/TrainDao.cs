using Railway.Entity;
using System.Collections.Generic;

namespace Railway.Dao.Interfaces {

    interface TrainDao : Dao<Train> {

        Train FindByModel(string model);

        List<string> FindAllModels();

    }

}
