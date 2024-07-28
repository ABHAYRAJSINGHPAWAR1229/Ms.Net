using System.Collections.Generic;

namespace Ccart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean Availability { get; set; }   

        public static List<Product> list=Populating.populate();

        public static int i=1;
        

        public  List<Product>  getAllproduct()
        {
            return list;
        }
        public Product getSingleproduct(int id)
        {
            
            Product product = null;
            foreach (var p in list)
            {
                if (p.Id == id)
                {
                    product = p;
                    break;
                }
            }

            return product;
        }

        public void updateProduct(Product product)
        {
            int id = product.Id;
            list[id-1]= product;
        }

        public void createproduct(Product product)
        {
            
            list.Add(product);

        }

        public void deleteProduct(int id)
        {
        
            foreach (Product p in list)
            {
                if(p.Id == id)
                {
                    Console.WriteLine(list.Contains(p));
                  
                    list.Remove(p);
                    Console.WriteLine(list.Contains(p));
                    break;
                }
                
                
            }
          
        }
       

    }

    public class Populating
    {
        public static List<Product> populate()
        {


            List<Product> list = new List<Product>();
            list.Add(new Product { Id = 1, Name = "Garnier Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 2, Name = "Glow & lovely Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 3, Name = "Nivea Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 4, Name = "Ponds White beauty Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 5, Name = "himami Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 6, Name = "Ponds Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 7, Name = "himalaya Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 8, Name = "vi-jhon Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 9, Name = "fair & Lovely Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 10, Name = "fair & handsome Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 11, Name = "Honey Almond Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 12, Name = "lakhme Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 13, Name = "Boro Line Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 14, Name = "bioTech Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 15, Name = "Gold Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 16, Name = "Fairy Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 17, Name = "German Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 18, Name = "Glowness Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 19, Name = "Panchvati Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 20, Name = "Nicen Cream", Description = "for facial purpose", Availability = true });
            list.Add(new Product { Id = 21, Name = "daskil Cream", Description = "for facial purpose", Availability = true });

            return list;
        }
    }
   
}
