using System;



void function(ref int a)
{
    a=3;
}

void main()
{
    int b=2;
    function(b)   
    Console.Write(b)
}