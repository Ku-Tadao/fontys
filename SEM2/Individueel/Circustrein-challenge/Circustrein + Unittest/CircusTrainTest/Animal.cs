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
            switch (AnimalSize)
            {
                case Size.Small:
                    return 1;
                case Size.Medium:
                    return 3;
                case Size.Large:
                    return 5;
                default:
                    return 0;
            }
        }
    }
}