using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class Processor
    {
        public static int CreateAuction(DateTime date, DateTime end_Date,
            string status, string description, double price)
        {
            AuctionModel data = new AuctionModel
            {
                Date = date,
                End_Date = end_Date,
                Status = status,
                Description = description,
                Price = price
            };

            string sql = @"insert into dbo.Auction (Date, End_Date, 
                Status, Description, Price) values (@Date, @End_Date,
                @Status, @Description, @Price);";

            return SqlDataAccess.SaveData(sql, data);
        }


        public static int CreateBid(string card, DateTime date)
        {
            BidModel data = new BidModel
            {
                Card = card,
                Date = date
            };

            string sql = @"insert into dbo.Bid (Card, Date) values (@Card, @Date);";

            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<BidModel> LoadBids()
        {
            string sql = @"select Id, Card, Date from dbo.Bid;";

            return SqlDataAccess.LoadData<BidModel>(sql);
        }



        public static List<AuctionModel> LoadAuctions()
        {
            string sql = @"select Id, Date, End_Date, Status, Description, Price from dbo.Auction;";

            return SqlDataAccess.LoadData<AuctionModel>(sql);
        }


    }
}
