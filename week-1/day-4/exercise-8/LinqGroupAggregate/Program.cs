namespace LinqGroupAggregate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Product objects
            List<Product> products = new List<Product>
        {
            new Product
            {
                Name = "Laptop",
                Category = "Electronics",
                Price = 1200.00M
            },

                new Product
            {
                Name = "Smartphone",
                Category = "Electronics",
                Price = 800.00M
            },


                new Product
                {
                    Name = "Headphones",
                    Category = "Electronics",
                    Price = 200.00M
                },

                new Product
                {
                    Name = "Shirt",
                    Category = "Clothing",
                    Price = 30.00M
                },

                new Product
                {
                    Name = "Jeans",
                    Category = "Clothing",
                    Price = 60.00M
                },

                new Product
                {
                    Name = "Sneakers",
                    Category = "Footwear",
                    Price = 100.00M
                }
        };



            // Use LINQ to perform the following operations:
            // 1. Group products by category

            var groupedProducts = products.GroupBy(p => p.Category);

            // 2. Count the number of products in each category

            var productCounts = groupedProducts.Select(g => new { Category = g.Key, Count = g.Count() });


            // 3. Calculate the total price of products in each category

            var totalPrices = groupedProducts.Select(g => new { Category = g.Key, TotalPrice = g.Sum(p => p.Price) });

            // 4. Find the most expensive product in each category

            var mostExpensiveProducts = groupedProducts.Select(g => new { Category = g.Key, MostExpensiveProduct = g.Max(p => p.Price) });

            Console.WriteLine("Products grouped by category:");
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var product in group)
                {
                    Console.WriteLine($" - {product.Name}, Price: {product.Price}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Product counts by category:");
            foreach (var count in productCounts)
            {
                Console.WriteLine($"Category: {count.Category}, Count: {count.Count}");
            }

            Console.WriteLine("Total prices by category:");
            foreach (var totalPrice in totalPrices)
            {
                Console.WriteLine($"Category: {totalPrice.Category}, Total Price: {totalPrice.TotalPrice}");
            }

            Console.WriteLine("Most expensive products by category:");
            foreach (var product in mostExpensiveProducts)
            {
                Console.WriteLine($"Category: {product.Category}, Most Expensive Product: {product.MostExpensiveProduct}");
            }
        }
    }
    
    }
