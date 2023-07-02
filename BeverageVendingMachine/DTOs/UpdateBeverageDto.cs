namespace BeverageVendingMachine
{
    public class UpdateBeverageDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public byte[] Image { get; set; } = null!;

        public int BeverageCount { get; set; }
    }
}
