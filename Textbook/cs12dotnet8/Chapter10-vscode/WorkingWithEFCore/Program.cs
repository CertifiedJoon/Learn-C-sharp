using Northwind.EntityModels;

using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");

ConfigureConsole();
// QueryingCategories();
// FilteredIncludes();
// QueryingProducts();
// GettingOneProduct();
// QueryingWithLike();

var resultAdd = AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, stock: 72);

if (resultAdd.affected == 1)
{
  WriteLine($"Add product successful with ID: {resultAdd.productId}");
}

ListProducts(productIdsToHighlight: [resultAdd.productId]);

var resultUpdate = IncreaseProductPrice(productNameStartsWith: "bob", amount: 20M);

if (resultUpdate.affected == 1)
{
  WriteLine($"Increase price success for ID: {resultUpdate.productId}");
}

ListProducts(productIdsToHighlight: [resultUpdate.productId]);

WriteLine("About to delete all products whose name starts with Bob.");

int deleted = DeleteProducts(productNameStartsWith: "Bob");
WriteLine($"{deleted} products were deleted.");

var resultUpdateBetter = IncreaseProductPricesBetter(
 productNameStartsWith: "Bob", amount: 20M);
if (resultUpdateBetter.affected > 0)
{
 WriteLine("Increase product price successful.");
}
ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);