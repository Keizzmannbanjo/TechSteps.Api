namespace TechSteps.Dtos.Models
{
    public class DepositDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEffective { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal Amount { get; set; }
        public decimal MaturityAmount { get; set; }
        public decimal Rate { get; set; }
        public int Tenure { get; set; }
        public string InterestType { get; set; }
        public string Comment { get; set; }
        public string ClientFullName { get; set; }
        public string ClientType { get; set; }
        public string ClientBankName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
