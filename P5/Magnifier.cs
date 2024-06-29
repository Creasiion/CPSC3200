//Imani Cage
//May 31, 2024
//Class/Interface Invariants are provided below:
//The constructor takes in a hidden number set as size, and integers for scalingFactor, maxUsage.
//All of them are set to 1 if user puts in anything that is not a positive integer. 
//Default values are also 1 other than numUsage, which is 5.
//isAlive is set to true and counter is set to 0 upon initializing. 
//scaledSize function returns the hidden number userSize multiplied by userScale. Counter increments each time it's called.
//Only able to call scaledSize numUsage amount of times, after that object will no longer be active.
//Calling it scaledSize afterwards will return 0.
//reset function will turn object alive again and reset the counter to 0, allowing users to
//call scaledSize function again numUsage amount of times.

namespace MagnifierClass;

public class Magnifier
{
    protected bool isAlive;
    protected int size;
    protected int scalingFactor;
    protected int maxUsage;
    protected int counter;
    
    public Magnifier(int userSize = 1, int userScale = 1, int numUsage = 5)
    {
        if (userSize < 1)
        {
            userSize = 1;
        }

        if (userScale < 1)
        {
            userScale = 1;
        }

        if (numUsage < 1)
        {
            numUsage = 1;
        }
        isAlive = true;
        size = userSize;
        scalingFactor = userScale;
        maxUsage = numUsage;
        counter = 0;
    }

    //Pre-Condition: None.
    //Post-Condition: Returns a calculated value of size multiplied by scalingFactor, or 0 if it's been called more than maxUsage number.
    public int scaledSize()
    {
        if (!isAlive)
        {
            return 0;
        }
        counter++;
        if (counter == maxUsage)
        {
            isAlive = false;
        }
        return size * scalingFactor;
    }

    //Pre-Condition: None.
    //Post-Condition: Resets the magnifier's state, allowing it to be used again.
    public void reset()
    {
        isAlive = true;
        counter = 0;
    }

    //Pre-Condition:  None.
    //Post-Condition: Returns whether or not the magnifier is active.
    public bool getIsAlive()
    {
        return isAlive;
    }
}

//Implementation Invariants are provided below:
//If user initializes with invalid integers to a variable, the object will set the variable to 1.
//Invalid integers will not set all variables to 1, just the specific variable it would have gone into.