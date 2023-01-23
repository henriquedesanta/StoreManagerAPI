using TPC.Domain.Enums;

namespace TPC.Domain.Entities
{
    internal class Product
    {
        public Product(string name, string description, decimal value,
               ProductType type, int stockAmount)
        {
            Name = name;
            Description = description;
            Value = value;
            IsActive = true;
            RegisterDate = DateTime.UtcNow;
            Type = type;
            StockAmount = stockAmount;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; private set; }
        public ProductType Type { get; private set; }
        public int StockAmount { get; private set; }

        public void Activate() => IsActive = true;

        public void Deactivate() => IsActive = false;

        public void ChangeType(ProductType newType) => Type = newType;

        public void ChangeDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new Exception("Descrição inválida!");

            Description = newDescription;
        }

        public void ProductOut(int amount)
        {
            if (amount < 0)
                throw new Exception("Quantidade inválida.");

            if (!ExistsStock(amount))
            {
                throw new Exception("Quantidade em estoque é insuficiente.");
            }

            StockAmount -= amount;
        }

        public bool ExistsStock(int amount) => StockAmount >= amount;
        
        public void AddStock (int amount)
        {
            StockAmount += amount;
        }
    }
}
