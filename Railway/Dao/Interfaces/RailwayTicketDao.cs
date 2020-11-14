using Railway.Entity;

namespace Railway.Dao.Interfaces {

    interface RailwayTicketDao : Dao<RailwayTicket> {

        RailwayTicket FindBySeatInTrain(int cattiageNumber, int seatOfCarriage);

    }

}
