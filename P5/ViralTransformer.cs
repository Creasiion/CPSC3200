//Imani Cage
//May 31, 2024
//Viral Transformer version 2.0
//Class/Interface Invariants are provided below:
//The constructor takes in a hidden value, and sets it as num. num is stable throughout the program.
//Constructor and reset is inherited from parent class Transformer.
//When guessing, the class outputs numbers 0-2 if parameter was too high, too low, or correct.
//outputValue alternates between multiplication and modulus based on bool alternate.
//If Transformer is inactive (isActive = false), then error exceptions will be thrown when trying to call on any methods.
//Default value is set to 5 for num

using TransformerClass;

namespace ViralTransformerClass
{
    public class ViralTransformer : Transformer
    {
        public ViralTransformer(int num = 5) : base(num)
        {
            
        }
        //Pre-Condition: userInput should be a valid integer in string form.
        //Post-Condition: Returns a calculated value. Value could either be num * userInput or num % userInput, based onn bool alternate.
        public override int outputValue(int userInput)
        {
            if (!isActive)
            {
                throw new NotSupportedException("Unable to update dead transformers.");
            }

            if (userInput == 0 || userInput == 1)
            {
                userInput++;
            }

            if (alternate)
            {
                alternate = !alternate;
                return num * userInput;
            }
            alternate = !alternate;
            return num % userInput;
        }
    }
}
//Implementation Invariants are provided below:
//If user input invalid error exception is thrown.
//If num has been found, object is declared as "dead" until reset is called.