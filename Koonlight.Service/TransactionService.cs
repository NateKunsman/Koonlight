using Koonlight.Models;
using Koonlight.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koonlight.Service
{
    public class TransactionService
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public TransactionService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    TransactionID = model.TransactionID,
                    Payout = model.Payout,
                    ShipperID = model.ShipperID,
                    LoadID = model.LoadID,
                    DriverID = model.DriverID,
                };
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TransactionList> GetTransactions()
        {
            {
                var quary =
                    ctx
                        .Transactions
                        .Select(
                             e =>
                                new TransactionList
                                {
                                    TransactionID = e.TransactionID,
                                    Payout = e.Payout,
                                    ShipperID = e.ShipperID,
                                    LoadID = e.LoadID,
                                    DriverID = e.DriverID,
                                }
                         );
                return quary.ToArray();
            }
        }
        public TransactionDetail GetTransactionById(int id)
        {
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == id );
                return
                  new TransactionDetail
                  {
                      TransactionID = entity.TransactionID,
                      Payout = entity.Payout,
                      ShipperID = entity.ShipperID,
                      LoadID = entity.LoadID,
                      DriverID = entity.DriverID,
                  };
            }
        }
        public bool UpdateTransaction(TransactionEdit model)
        {
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == model.TransactionID );
                entity.TransactionID = model.TransactionID;
                entity.Payout = model.Payout;
                entity.ShipperID = model.ShipperID;
                entity.LoadID = model.LoadID;
                entity.DriverID = model.DriverID;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTransaction(int Id)
        {
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionID == Id );
                ctx.Transactions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
