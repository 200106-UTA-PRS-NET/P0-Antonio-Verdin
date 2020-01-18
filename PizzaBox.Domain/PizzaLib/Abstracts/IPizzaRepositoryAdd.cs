namespace PizzaBox.Domain.PizzaLib.Abstracts
{
    interface IPizzaRepositoryAdd<T>
    {
        void PizzaBoxAdd(T record);
    }
}
