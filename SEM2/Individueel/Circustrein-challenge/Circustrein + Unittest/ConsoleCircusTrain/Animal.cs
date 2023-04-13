public class Animal
{
    private string _animalDiet;
    private string _animalSize;

    public string AnimalDiet
    {
        get => _animalDiet;
        set
        {
            if (value == "Carnivore" || value == "Herbivore")
            {
                _animalDiet = value;
            }
            else
            {
                throw new ArgumentException("Invalid diet value.");
            }
        }
    }

    public string AnimalSize
    {
        get => _animalSize;
        set
        {
            if (value == "Small" || value == "Medium" || value == "Large")
            {
                _animalSize = value;
            }
            else
            {
                throw new ArgumentException("Invalid size value.");
            }
        }
    }

    public int Points
    {
        get
        {
            if (_animalSize == "Small") return 1;
            if (_animalSize == "Medium") return 3;
            if (_animalSize == "Large") return 5;
            return 0;
        }
    }
}