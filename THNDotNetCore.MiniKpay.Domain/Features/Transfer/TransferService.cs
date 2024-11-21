using Microsoft.EntityFrameworkCore;
using THNDotNetCore.Database.Models;
using THNDotNetCore.MiniKpay.Database.Models;
namespace THNDotNetCore.MiniKpay.Domain.Features.Transfer
{
    public class TransferService
    {
        private readonly AppDbContext _db;

        public TransferService(AppDbContext db)
        {
            _db = db;
        }

        public List<TransferModel> GetTransfers()
        {
            var transfers = _db.Transfer.AsNoTracking().ToList();
            return transfers;
        }

        public int CreateTransfer(TransferModel model)
        {
            _db.Transfer.Add(model);
            var result = _db.SaveChanges();
            return result;
        }
    }
}
