//Imani Cage
//May 31, 2024
//Transformer version 2.0
//Class/Interface Invariants are provided below:
//The constructor takes in a hidden value, and sets it as num. num is stable throughout the program.
//When guessing, the class outputs numbers 0-2 if parameter was too high, too low, or correct.
//outputValue alternates between addition and subtraction based on bool alternate.
//If Transformer is inactive (isActive = false), then error exceptions will be thrown when trying to call on any methods.
//Default value is set to 5 for num

using InterfaceTransformer;

namespace TransformerClass
{
    public class Transformer : ITransformer
    {
        protected bool isActive;
        protected int num;
        protected bool alternate;

        public Transformer(int input = 5)
        {
            isActive = true;
            num = input;
            alternate = true;
        }
        
        //Pre-Condition: userInput should be a valid integer in string form.
        //Post-Condition: Returns a calculated value. Value could either be num + userInput or num - userInput, based on bool alternate.
        public virtual int outputValue(int userInput)
        {
            if (!isActive)
            {
                throw new NotSupportedException("Unable to update dead transformers.");
            }
            
            if (userInput == 0)
            {
                userInput++;
            }

            if (alternate)
            {
                alternate = !alternate;
                return num + userInput;
            }

            alternate = !alternate;
            return num - userInput;
        }

        //Pre-Condition: User should input valid integers.
        //Post-Condition: Returns value 0-2; 0 if User input is too low, 1 if User input is correct, and 2 if User input is too high.
        public int processGuess(int userGuess)
        {
            if (!isActive)
            {
                throw new NotSupportedException("Unable to update dead transformers.");
            }

            if (userGuess == num)
            {
                isActive = false;
                return 1;
            }else if (userGuess < num)
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }

        //Pre-Condition: None.
        //Post-Condition: Resets the transformer's state, allowing it to be used again.
        public virtual void reset()
        {
            isActive = true;
            alternate = true;
        }
        
        //Pre-Condition: None.
        //Post-Condition: Returns whether the transformer is active.
        public bool getIsActive()
        {
            return isActive;
        }
    }
}

//Implementation Invariants are provided below:
//If user input invalid error exception is thrown.
//If num has been found, object is declared as "dead" until reset is called.