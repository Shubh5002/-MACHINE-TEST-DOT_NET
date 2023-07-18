namespace DOTMACHINETEST.Models
{
    public class Product
    {
      
            public int ProductId { get; set; }
            public string ProductName { get; set; }

            // Foreign key
            public int CategoryId { get; set; }

            // Navigation property
            public virtual Category Category { get; set; }
        
    }
}
