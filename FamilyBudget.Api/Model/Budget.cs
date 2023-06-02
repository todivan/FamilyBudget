namespace FamilyBudget.Api.Model
{
    public class Budget : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Amount { get; set; }
    }
}
