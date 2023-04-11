public class Animal
{
    public enum Diet { Herbivore, Carnivore };
    public enum Size { Small, Medium, Large };

    public Diet AnimalDiet { get; set; }
    public Size AnimalSize { get; set; }

    public int Points
    {
        get
        {
            return AnimalSize switch
            {
                Size.Small => 1,
                Size.Medium => 3,
                Size.Large => 5,
                _ => 0
            };
        }
    }
}