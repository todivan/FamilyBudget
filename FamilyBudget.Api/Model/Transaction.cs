namespace FamilyBudget.Api.Model
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public TransactionType Type { get; set; }
        public int Amount { get; set; }
        public TransactionCategory Category { get; set; }
    }
}
