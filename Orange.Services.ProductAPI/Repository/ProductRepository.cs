using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orange.Services.ProductAPI.DbContexts;
using Orange.Services.ProductAPI.Models;
using Orange.Services.ProductAPI.Models.Dto;

namespace Orange.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        private IMapper _mapper;
        public ProductRepository(ApplicationDbContext context,IMapper mapper)
        {
            dbContext= context;
            _mapper= mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            if (product.ProductId > 0)
            {
                dbContext.Products.Update(product);
            }
            else
            {
                dbContext.Products.Add(product);
            }
            dbContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                Product product = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                if (product==null)
                {
                    return false;
                }
                dbContext.Products.Remove(product);
                dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            Product products = await dbContext.Products.Where(x=>x.ProductId==id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(products);

        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await dbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);

        }
    }
}
