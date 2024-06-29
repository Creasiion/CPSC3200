//Imani Cage
//May 31, 2024
//Class/Interface Invariants are provided below:
//The constructor takes in a code that will be used to decide what the encapsulated Transformer will be.
//All other constructor parameters are for the parent class Magnifier.
//code has 2 and 3. 2 makes the encapsulated Transformer tObj an AccelerateTransformer, 3 makes it a viralTransformer.
//Any other value including 1 defaults to just Transformer. code 1 (Transformer) is used if no parameters were specified.
//Only able to call getScale function numUsage amount of times. Afterwards TMagnifier is inactive.
//processGuess function will return value given from tObj. Outputs numbers 0-2 if parameter was too high, too low, or correct.
//After guessing correctly the value inside of tObj, TMagnifier is inactive.
//processGuess function will return 1 if TMagnifier is inactive.
//outputValue function returns tObj's outputValue number. If a Transformer will alternate between addition and subtraction of the hidden value given an input value,
//if an AccelerateTransformer will incrementally add one to the encapsulated hidden value each time it is called, and if
//a viralTransformer will alternate between multiplication and modulo of the hidden value given an input value.

namespace TMagnifierClass;

using InterfaceTransformer;
using TransformerClass;
using AccelerateTransformerClass;
using ViralTransformerClass;
using MagnifierClass;

public class TMagnifier : Magnifier, ITransformer
{
    protected Transformer tObj;
    protected int killT;

    public TMagnifier(int code = 1, int userSize = 1, int userScale = 1, int numUsage = 5, int input = 5) : base(userSize, userScale, numUsage)
    {
        if (code == 2)
        {
            tObj = new AccelerateTransformer(input);
        }else if (code == 3)
        {
            tObj = new ViralTransformer(input);        
        }
        else
        {
            tObj = new Transformer(input);
        }

        killT = input;
    }

    //Pre-Condition:
    //Post-Condition:
    public int outputValue(int userInput)
    {
       return tObj.outputValue(userInput);
    }

    //Pre-Condition: User should input valid integers.
    //Post-Condition: Returns value 0-2; 0 if User input is too low, 1 if User input is correct or TMagnifier is inactive, and 2 if User input is too high.
    public int processGuess(int userGuess)
    {
        if (!isAlive)
        {
            return 1;
        }
        int result = tObj.processGuess(userGuess);
        if (!tObj.getIsActive())
        {
            isAlive = false;
        }

        return result;
    }

    //Pre-Condition: None.
    //Post-Condition: Returns a calculated value of size multiplied by scalingFactor, or 0 if it's been called more than specified amount of time.
    public int getScaledSize()
    {
        int result = base.scaledSize();
        if (!isAlive && tObj.getIsActive())
        {
            tObj.processGuess(killT);
        }

        return result;
    }
    
    //Pre-Condition: None
    //Post-Condition: Resets the transformer's state and the magnifier's state, allowing it to be used again.
    public void reset()
    {
        base.reset();
        tObj.reset();
    }
    
    //Pre-Condition: None
    //Post-Condition: Returns whether or not the TMagnifier is active.
    public bool getIsActive()
    {
        return isAlive;
    }
}

//Implementation Invariants are provided below:
//In the function getScaledSize, only kill tObj if isAlive is false AND if the object isn't already dead, so we can still return an integer (0)
//In processGuess if Tmagnifier is no longer active, return 1 because that means the guess was already answered, or user exceeded numUsage count,
//for either situation any other guess doesn't matter, since both cases requires a reset. Needed so transformer doesn't
//throw exception when trying to guess again during inactive TObj.
//outputValue can still be called even if TMagnifier is dead.