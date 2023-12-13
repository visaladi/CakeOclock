using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface ICustomProductRepository
    {
        public Task<CustomProductDTO> Create(CustomProductDTO objDTO);
        public Task<CustomProductDTO> Update(CustomProductDTO objDTO);
        public Task<int> Delete(int id);

        public Task<CustomProductDTO> Get(int id);
        public Task<IEnumerable<CustomProductDTO>> GetAll();


    }
}
