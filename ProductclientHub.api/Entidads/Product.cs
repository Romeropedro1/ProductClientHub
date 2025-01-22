namespace ProductclientHub.api.Entidads
{
    public class Product
    {
        public Guid Id { get; set; }  // Propriedade de tipo string para o nome do produto
        public string Name { get; set; } = string.Empty;
        public string Brond { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public Guid ClientId {get;set; }
    }
}
