using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CustomProductRepository : ICustomProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CustomProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CustomProductDTO> Create(CustomProductDTO objDTO)
        {
            var obj = _mapper.Map<CustomProductDTO, CustomProduct>(objDTO);
           

            var addedObj = _db.CustomProducts.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<CustomProduct, CustomProductDTO>(addedObj.Entity);
        }
        public async Task<int> Delete(int id)
        {
            var obj = await _db.CustomProducts.FirstOrDefaultAsync(u => u.Id == id);
            if(obj != null)
            {
                _db.CustomProducts.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CustomProductDTO> Get(int id)
        {
            var obj = await _db.CustomProducts.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<CustomProduct, CustomProductDTO>(obj);
            }
            return new CustomProductDTO();
        }

        public async Task<IEnumerable<CustomProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomProduct>, IEnumerable<CustomProductDTO>>(_db.CustomProducts);
        }

        public async Task<CustomProductDTO> Update(CustomProductDTO objDTO)
        {
            var objFromDb = await _db.CustomProducts.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                objFromDb.Description = objDTO.Description;
                objFromDb.ImageUrl = objDTO.ImageUrl;
                objFromDb.RequiredDate = objDTO.RequiredDate;
                //objFromDb.CategoryId = objDTO.CategoryId;

                _db.CustomProducts.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<CustomProduct, CustomProductDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
