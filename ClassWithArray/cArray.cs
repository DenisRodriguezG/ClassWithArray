using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWithArray
{
    internal class cArray
    {
        private int[] Element;
        private int counter;
        private string nameElement;
        private int max;

        public cArray()
        {
            
            nameElement = "Integer numbers";
        }
        public cArray(int max)
        {
            Element = new int[max];
            counter = 0;
            this.max = max;
            nameElement = "Integer numbers";
        }
        public bool full()
        {
            return counter == max;
        }
        public bool Empty()
        {
            return counter == 0;
        }
        
        public void insert()
        {
            if (full())
                Console.WriteLine("Sorry, but the Array Element is full");
            else
            {
                Console.WriteLine("How many numbers do you want: ");
                int n = int.Parse(Console.ReadLine());

                if (n > (this.max - counter))
                    Console.WriteLine("Sorry n must to be less than max");
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Enter a number: ");
                        Element[counter] = int.Parse(Console.ReadLine());
                        counter++;
                    }
                }
            }
        }
        public  int Delete()
        {
            /*
             * This function delete the last number of the array
             */
            if (!Empty())
                return Element[counter--];
            return counter = 0;
        }
        public void showElement()
        {
            /*
             * This function help to show all elements of array
             */
            Console.WriteLine("Information of the array");
            Console.WriteLine();
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            string aux = "";
            for(int i = 0; i < counter; i++)
            {
                if (i == 0)
                    aux += Element[i] + " <--- Beggining\n";
                else if (i == (counter - 1))
                    aux += Element[i] + " <--- End";
                else
                    aux += Element[i] + "\n";
            }
            return aux;
        }
        public int suma()
        {
            int total = 0;

            for (int i = 0; i < counter; i++)
                total += Element[i];
            return total;
        }
        public int Max()
        {
            int bigNumber = Element[0];

            for (int i = 1; i < counter; i++)
                if (bigNumber < Element[i])
                    bigNumber = Element[i];
            return bigNumber;
        }
        public int min()
        {
            int litteNumber = Element[0];

            for (int i = 1; i < counter; i++)
                if (litteNumber > Element[i])
                    litteNumber = Element[i];
            return litteNumber;
        }
        public double average()
        {
            return (suma() / 2);
        }
        public void knowTheSort()
        {
            bool ascendente = true;
            bool descendente = true;
           
            for(int i = 1; i < counter; i++)
            {
                if (Element[i - 1] < Element[i])
                    descendente = false;
                if (Element[i - 1] > Element[i])
                    ascendente = false;
            }
            if(ascendente)
            {
                if (descendente)
                    Console.WriteLine("Tiene un ordern no determinado");
                else
                    Console.WriteLine("Tiene un orden ascendente");
            }
            else
            {
                if (descendente)
                    Console.WriteLine("Tiene un orden descendente");
                else
                    Console.WriteLine("Los elementos están desordenados");
            }
        }
        public override bool Equals(object obj)
        {
            cArray aux = (cArray)obj;
            return this == aux;
        }
        public static bool operator ==(cArray Op1, cArray Op2)
        {
            bool isEqual = true;
            if (Op1.Empty()) 
            {
                if (Op2.Empty())
                    return true;
                else
                    return false;
            }   
            else
            {
                if (Op2.Empty())
                    return false;
                else
                {
                    if (Op1.counter == Op2.counter)
                    {
                        for(int i = 0; i < Op1.counter; i++)
                        {
                            if (Op1.Element[i] != Op2.Element[i])
                                isEqual = false;
                        }
                    }
                    else
                        return false;
                }      
            }
            if (isEqual)
                return true;
            return false;
        }
        public static bool operator !=(cArray Op1, cArray Op2)
        {
            if (Op1.Empty() != Op2.Empty())
                return true;
            if (Op1.counter != Op2.counter)
                return true;
            return false;
        }
        public static cArray operator +(cArray Op1, cArray Op2)
        {
            
            
            cArray Op3 = new cArray(200);
            //int maxCounter = Op1.counter + Op2.counter;
            Op3.counter = 0;
           /* for(int i = 0; i < maxCounter; i++)
            {
                if(i < Op1.counter)
                {
                    Op3.Element[Op3.counter] = Op1.Element[i];
                    Op3.counter++;
                }  
                if(i < Op2.counter)
                {
                    Op3.Element[Op3.counter] = Op2.Element[i];
                    Op3.counter++;
                }       
            }*/
           for(int i = 0; i < Op1.counter; i++)
                Op3.Element[Op3.counter++] = Op1.Element[i];
            for (int i = 0; i < Op2.counter; i++)
                Op3.Element[Op3.counter++] = Op2.Element[i];
            return Op3;
        }
        public void numbersPrimos()
        {
            int cPrimo = 0;

            for (int i = 0; i < counter; i++)
            {
                for (int j = 2; j <= Element[i]; j++)
                {
                    if (Element[i] % j == 0)
                        cPrimo++;
                }
                if (cPrimo == 1)
                    Console.WriteLine("Casilla [" + i + "] = " + Element[i] + " es un primo");
                cPrimo = 0;
            }    
            
        }
        public void menu()
        {
            int option;
            do
            {

                Console.WriteLine("------------------------------------");
                Console.WriteLine("                MENU                ");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("          " + nameElement + "       ");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1.- Insert element");
                Console.WriteLine("2.- Delete a element of the array");
                Console.WriteLine("3.- Show all of the array or element");
                Console.WriteLine("4.- Information of the array");
                Console.WriteLine("5.- Know the numbers primos");
                Console.WriteLine("6.- Exit");
                Console.WriteLine("");
                Console.Write("Choose one of the otions: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {

                    case 1:
                        insert();
                        break;
                    case 2:
                        if (!Empty())
                            Console.WriteLine("Deleting a number of the array");
                        else
                            Console.WriteLine("ERROR... The array is empty");
                        Delete();
                        break;
                    case 3:
                        showElement();
                        break;
                    case 4:
                        if (Empty())
                            Console.WriteLine("ERROR... The array is empty");
                        else
                        {
                            Console.WriteLine("            Information");
                            Console.WriteLine("The maximo number is " + Max());
                            Console.WriteLine("The minimo number is " + min());
                            Console.WriteLine("The suma is " + suma());
                            Console.WriteLine("The average is " + average());
                            knowTheSort();
                        }
                        break;
                    case 5:
                        Console.WriteLine("5.- The numbers primos");
                        numbersPrimos();
                        break;
                    case 6:
                        Console.WriteLine("Thank you for visit");
                        break;
                }
            }
            while (option != 6);


        }
    }
}
