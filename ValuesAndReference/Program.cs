using System;
using ValuesAndReference;
namespace ValueAndReference;
class Program
{
    public void Main(string[] args)
    {
        int number1=10;
        Console.WriteLine(number1);

        int number2=number1;
        Console.WriteLine(number2);
        
        number1=20;
        Console.WriteLine(number2);

        Student oldName=new Student();
        oldName.Name="thiru";

        Console.WriteLine(oldName.Name);

        Student newName=oldName;

        Console.WriteLine(newName.Name); 

        oldName.Name="arasu";

        Console.WriteLine(oldName.Name);
        Console.WriteLine(newName.Name);
    }
}