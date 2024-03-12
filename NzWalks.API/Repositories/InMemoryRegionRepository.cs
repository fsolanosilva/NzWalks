using NzWalks.API.Models.Domain;

namespace NzWalks.API.Repositories
{
    public class InMemoryRegionRepository /*: IRegionRepository*/
    {
        public Task<List<Region>> GetAllAsync()
        {
            var list = new List<Region>();

            list.Add(new Region
            {
                Id = Guid.NewGuid(),
                Name = "Sanneer's Region Name",
                Code = "SAM",
                RegionImageUrl = "sanner.jpeg"
            });

            return Task.FromResult(list);
        }

        public Task<Region> CreateAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> UpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
