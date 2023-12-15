namespace TechSteps.Dtos.Models
{
    public class CreateDepositDto
    {
        public string CustomerFullName { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal MaturityAmount { get; set; }
        public DateTime MaturityDate { get; set; }
        public string InterestType { get; set; }
        public int Tenure { get; set; }
        public string Comment { get; set; }
        public string CustomerIdNumber { get; set; }
    }
}
