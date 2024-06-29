//Imani Cage
//May 31, 2024
//P5 driver:
//The driver contains private constant ints of the array size of which will be used to make 
//the heterogenous collection, size/scale/usage/targetval and readonly array that holds the numbers
//1-3 all of which will be used for constructing TMagnifier objects, an input value to test
//TMagnifier transformer outputValue, and two integers (TOOHIGH and TOOLOW) with another readonly array
//all of which will be used to test the rest of TMagnifiers functions.
//Each object will test their scaling through the function printAllUsage in order to
//ensure correct output even after TMagnifier is inactive.
//Each object's transformer is tested TWICE in order to show alternating return outputs, and then
//will process a guess THREE TIMES using printStat to return if guess was correct or not.
//printIsDead states on whether the object is alive or not and used to ensure correct behavior.
//Guessing again when your object is dead will return 1 or 'correct', since it is inactive and needs to be reset.

using TMagnifierClass;

namespace P5
{
    internal class p5
    {
        private const int ARRAYSIZE = 3;
        private const int SIZE = 15;
        private const int SCALE = 7;
        private const int USAGE = 5;
        private const int TARGETVAL = 2048;
        private const int INPUTVAL = 10;
        private const int TOOLOW = 0;
        private const int TOOHIGH = 2;
        public static readonly int[] CODE = {
            1, 2, 3
        };
        public static readonly int[] EXPECTEDVALS = {
            2058, 2038, 2049, 2050, 20480, 8
        };

        public static void printAllUsage(TMagnifier a, int usage)
        {
            for (int i = 0; i < usage; i++)
            {
                Console.WriteLine("Printing scaled size #" + (i+1) + ": " + a.getScaledSize());
            }
            Console.WriteLine("Printing scaled size #" + (usage + 1) + ". Should return 0: " + a.getScaledSize());
        }

        public static string printIsDead(TMagnifier a)
        {
            if (a.getIsAlive())
            {
                return "alive";
            }
            else
            {
                return "dead";
            }
        }

        public static string printStat(int guessReturn)
        {
            if (guessReturn == TOOLOW)
            {
                return "too low";
            }else if (guessReturn == TOOHIGH)
            {
                return "too high";
            }
            else
            {
                return "correct";
            }
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Making a heterogeneous collection of type TMagnifier, but holding Transformer, AccelerateTransformer, and ViralTransformer \n");
            TMagnifier[] Objs = new TMagnifier[ARRAYSIZE];
            int output;
            for (int i = 0; i < ARRAYSIZE; i++)
            {
                if (i%ARRAYSIZE == 0)
                {
                    Objs[i] = new TMagnifier(CODE[0], SIZE, SCALE, USAGE, TARGETVAL);
                }else if (i % ARRAYSIZE == 1)
                {
                    Objs[i] = new TMagnifier(CODE[1], SIZE, SCALE, USAGE, TARGETVAL);
                }
                else
                {
                    Objs[i] = new TMagnifier(CODE[2], SIZE, SCALE, USAGE, TARGETVAL);
                }
            }
            Console.WriteLine("Will now scale each of the objects 6 times. The 6th time will output 0, the rest will output 105\n");
            for (int i = 0; i < ARRAYSIZE; i++)
            {
                Console.WriteLine("\nNow testing Obj" + (i+1));
                printAllUsage(Objs[i], USAGE);
            }
            
            Console.WriteLine("\nWill now see if each of the objects are dead and will reset if so. All objects should be dead.\n");
            for (int i = 0; i < ARRAYSIZE; i++)
            {
                Console.WriteLine("Obj" + (i+1) + " is " + printIsDead(Objs[i]) + "");
            }
            
            Console.WriteLine("\nWill now reset each object.\n");
            for (int i = 0; i < ARRAYSIZE; i++)
            {
                Objs[i].reset();
                Console.WriteLine("Obj" + (i+1) + " is now " + printIsDead(Objs[i]) + "");
            }

            Console.WriteLine("\nWill now test their output value from their transformers. \n");
            for (int i = 0; i < ARRAYSIZE; i++)
            {
                if (i%ARRAYSIZE == 0)
                {
                    Console.WriteLine("Expected value for Obj" + (i+1) + " is " + EXPECTEDVALS[0] + ". Output value is: " + Objs[i].outputValue(INPUTVAL));
                    Console.WriteLine("Expected value for Obj" + (i+1) + " is " + EXPECTEDVALS[1] + ". Output value is: " + Objs[i].outputValue(INPUTVAL));
                }else if (i % ARRAYSIZE == 1)
                {
                    Console.WriteLine("Expected value for Obj" + (i+1) + " is " + EXPECTEDVALS[2] + ". Output value is: " + Objs[i].outputValue(INPUTVAL));
                    Console.WriteLine("Expected value for Obj" + (i+1) + " is " + EXPECTEDVALS[3] + ". Output value is: " + Objs[i].outputValue(INPUTVAL));
                }
                else
                {
                    Console.WriteLine("Expected value for Obj" + (i+1) + " is " + EXPECTEDVALS[4] + ". Output value is: " + Objs[i].outputValue(INPUTVAL));
                    Console.WriteLine("Expected value for Obj" + (i+1) + " is " + EXPECTEDVALS[5] + ". Output value is: " + Objs[i].outputValue(INPUTVAL));
                }
            }
            Console.WriteLine("\nWill now test out each object's guessing. First will guess too low, then too high, and then the correct value. Will check if it's alive after each guess (should be alive until answer is correct) \n");
            for (int i = 0; i < ARRAYSIZE; i++)
            {
                Console.WriteLine("First guess for Obj" + (i+1) + " is " + printStat(Objs[i].processGuess(TARGETVAL-1)) + " and is currently " + printIsDead(Objs[i]));
                Console.WriteLine("Second guess for Obj" + (i+1) + " is " + printStat(Objs[i].processGuess(TARGETVAL+1)) + " and is currently " + printIsDead(Objs[i]));
                Console.WriteLine("Final guess for Obj" + (i+1) + " is " + printStat(Objs[i].processGuess(TARGETVAL)) + " and is now " + printIsDead(Objs[i]) + "\n");
            }
            
            Console.WriteLine("\nWill now check that the object is dead. Guessing again should print out the value 1 since it was previously guessed correctly. \n");
            for (int i = 0; i < ARRAYSIZE; i++)
            {
                Console.WriteLine("Obj" + (i+1) + " is " + printIsDead(Objs[i]) + ". Expected value after trying to guess again is 1. Actual Output: " + Objs[i].processGuess(INPUTVAL));
            }
        }
    }
}

