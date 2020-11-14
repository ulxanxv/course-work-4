using Railway.Entity;
using System.Collections.Generic;

namespace Railway.Dao.Interfaces {

    interface PersonDao : Dao<Person> {

        Person FindByPassportData(string passportSeries, string passportId);

        List<string> FindAllPersons();

    }

}
