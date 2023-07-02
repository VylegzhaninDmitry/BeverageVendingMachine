namespace BeverageVendingMachine
{
    public record CreateBeverageDto
    {
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public byte[] Image { get; set; } = null!;

        public int BeverageCount { get; set; }
    }
}
