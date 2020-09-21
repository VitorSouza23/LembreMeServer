using LembreMeServer.Domain.Entities;
using LembreMeServer.Domain.Repository;
using LembreMeServer.Infra.Context;

namespace LembreMeServer.Infra.Repository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(IAppContext appContext) : base(appContext)
        {
        }
    }
}
