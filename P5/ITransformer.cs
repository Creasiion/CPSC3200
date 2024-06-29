//Imani Cage
//May 31, 2024

namespace InterfaceTransformer;

public interface ITransformer
{
    int outputValue(int userInput);
    int processGuess(int userGuess);
    void reset();
    bool getIsActive();
}