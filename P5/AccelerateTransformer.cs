//Imani Cage
//May 31, 2024
//Accelerate Transformer version 2.0
//Class/Interface Invariants are provided below:
//The constructor takes in a hidden value, and sets it as num. num is stable throughout the program.
//Constructor is inherited from parent class Transformer, and adds counter initialization.
//Reset is inherited from parent class Transformer, and resets counter value.
//When guessing, the class outputs numbers 0-2 if parameter was too high, too low, or correct.
//outputValue progressively adds one to num each time it is returned
//If Transformer is inactive (isActive = false), then error exceptions will be thrown when trying to call on any methods.
//Default value is set to 5 for num

using TransformerClass;

namespace AccelerateTransformerClass
{
    public class AccelerateTransformer : Transformer
    {
        protected int counter;

        public AccelerateTransformer(int num = 5) : base(num)
        {
            counter = 0;
        }
        
        //Pre-Condition: userInput should be a valid integer in string form.
        //Post-Condition: Returns a calculated value. 1 is progressively added each time to num i.e. num + 1, num + 2, num +3.
        public override int outputValue(int userInput)
        {
            if (!isActive)
            {
                throw new NotSupportedException("Unable to update dead transformers.");
            }

            counter++;
            return num + counter;
        }
        //Pre-Condition: None.
        //Post-Condition: Resets the transformer's state, allowing it to be used again. Resets counter back to 0.
        public override void reset()
        {
            base.reset();
            counter = 0;
        }
    }
}
//Implementation Invariants are provided below:
//If user input invalid error exception is thrown.
//If num has been found, object is declared as "dead" until reset is called.
//Counter is reset so outputValue numbers output properly back to adding one to num each time.