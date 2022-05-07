namespace Entities.Models
{
    public class LoanModel
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public float Interest { get; set; }

        public decimal MinAmount { get; set; }

        public decimal MaxAmount { get; set; }
    }
}
