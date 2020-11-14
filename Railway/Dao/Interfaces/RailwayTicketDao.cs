using Railway.Entity;
using System.Collections.Generic;

namespace Railway.Dao.Interfaces {

    interface RailwayTicketDao : Dao<RailwayTicket> {

        RailwayTicket FindBySeatInTrain(int cattiageNumber, int seatOfCarriage);

        List<RailwayTicket> CallProcedure(string procedureName, string[] arguments);

    }

}
