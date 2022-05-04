using MassTransit;
using SharedClassModels.DataModels;
using System.Threading.Tasks;

namespace FlightBookingConsumerService.Models
{
    public class Consumer: IConsumer<TblBookingdetail>
    {
        private readonly AirlineDBContext _dbContext;
        public Consumer(AirlineDBContext dbContext)
        {
            _dbContext=dbContext;
        }

        public Task Consume(ConsumeContext<TblBookingdetail> context)
        {
            _dbContext.TblBookingdetails.Add(context.Message);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
