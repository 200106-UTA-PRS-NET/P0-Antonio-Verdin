namespace PizzaBox.Models
{
    public partial class PizzaIngredients
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public bool Finished { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
