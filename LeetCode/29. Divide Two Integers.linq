<Query Kind="Program" />

void Main()
{
    Cal(55, 3).Dump();
    
}

// Define other methods and classes here
public int Cal(int dividened, int divisor)
{
    int result = 0;
    
    for (int i = 0; i < 100; i++)
    {
        int value = divisor << i;
        
        if(i==0)
            result = 1;
        else if(i==1)
            result = 2;
        else
            result = result*2;
        
        if(value > dividened)
            break;
    }
    return result;
}