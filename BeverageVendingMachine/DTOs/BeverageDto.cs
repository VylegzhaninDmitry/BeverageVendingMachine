namespace BeverageVendingMachine
{
    public record BeverageDto : BaseDTO
    {
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public string Image { get; set; } = string.Empty;

        public int BeverageCount { get; set; }
    }
}
