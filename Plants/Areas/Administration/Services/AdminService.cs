//namespace Plants.Services.AdminService
//{
//    using Data;
//    using Data.Models.Plant;
//    using Microsoft.EntityFrameworkCore;
//    using Models;
//    using Plants.Areas.Administration.Intefraces;
//    using Plants.Services.Data.AdminService.Models;

//    public class AdminService : IAdminService
//    {
//        private readonly PlantsDbContext _context;

//        public AdminService(PlantsDbContext context)
//        {
//            _context = context;
//        }

//        public async Task AddPlantAsync(PlantModel model)
//        {
//            var entity = new PlantModel()
//            {
   
//            };

//            await _context.AddAsync(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeletePlantAsync(int id)
//        {
//            var entity = await _context.Plants
//               .Where(x => x.Id == id)
//               .FirstOrDefaultAsync();

//            if (entity == null)
//            {
//                throw new Exception("Invalid post");
//            }

//            _context.Remove(entity);

//            await _context.SaveChangesAsync();
//        }

//        public async Task EditPlantAsync(PlantModel model)
//        {
//            var entity = await _context.Plants
//                .Where(x => x.Id == model.Id)
//                .FirstOrDefaultAsync();

//            if (entity == null)
//            {
//                throw new Exception("Invalid post");
//            }
//            else
//            {

//            }

//            await _context.SaveChangesAsync();
//        }

//        public async Task<IEnumerable<PlantModel>> GetAllPlantsAsync()
//        {
//            return await _context.Plants
//               .Select(x => new PlantModel()
//               {
//                   Id = x.Id,
//               })
//               .AsNoTracking()
//               .ToListAsync();
//        }

//        public async Task<PlantModel?> GetPlantByIdAsync(int id)
//        {
//            return await _context.Plants
//               .Where(x => x.Id == id)
//               .Select(x => new PlantModel()
//               {
//                   Id = x.Id,
                   
      
//               })
//               .AsNoTracking()
//               .FirstOrDefaultAsync();
//        }
//    }
//}
