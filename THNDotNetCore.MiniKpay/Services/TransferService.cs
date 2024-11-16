using THNDotNetCore.MiniKpay.Db;
using THNDotNetCore.MiniKpay.Features.Transfer;

namespace THNDotNetCore.MiniKpay.Services
{
    public class TransferService
    {
        private readonly AppDbContext _db;

        public TransferService(AppDbContext db)
        {
            _db = db;
        }

        public int CreateTransfer(TransferModel model)
        {
            _db.Transfer.Add(model);
            var result = _db.SaveChanges();
            return result;
        }
    }
}
