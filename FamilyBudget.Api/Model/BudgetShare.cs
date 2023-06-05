namespace FamilyBudget.Api.Model
{
    public class BudgetShare : IEntity
    {
        public int Id { get; set; }
        public string UserGuid { get; set; }
        public int BudgetId { get; set; }
    }
}
