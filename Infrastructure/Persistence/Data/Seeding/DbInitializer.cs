namespace Persistence.Data.Seeding
{
    public class DbInitializer (AppDbContext _dbContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
			try
			{
				if (_dbContext.Database.GetPendingMigrations().Any())
				{
					await _dbContext.Database.MigrateAsync();
					if(!_dbContext.ProductTypes.Any())
					{
						var typeData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\JsonFiles\types.json");
						var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
						if(types is not null)
						{
                            await _dbContext.ProductTypes.AddRangeAsync(types);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (!_dbContext.ProductBrands.Any())
                    {
                        var brandData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\JsonFiles\brands.json");
                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                        if (brands is not null)
                        {
                            await _dbContext.ProductBrands.AddRangeAsync(brands);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (!_dbContext.Products.Any())
                    {
                        var productData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\JsonFiles\products.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(productData);
                        if (products is not null)
                        {
                            await _dbContext.Products.AddRangeAsync(products);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                }

			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
