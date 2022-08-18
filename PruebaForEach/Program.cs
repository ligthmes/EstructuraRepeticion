int[] valore;
valore = new int[] { 3, 5, 2, 1, 5, 3, 7, 9, 8 };
string[] paises = new string[] { "Argentina", "Bolivia", "peru", "Chile", "Nicaragua" };

int total = 0;

foreach ( int i in valore)
{
    total += i;
    Console.WriteLine("{0}", i);
}

Console.WriteLine("___-______--_____");
Console.WriteLine("total" + total);

// Tammbien arreglo  multidimensionales
int [,] numero = new int [3,3] { { 1, 4, 8 }, { 2, 5, 6 },{2,9,10 } };

foreach ( int i in numero)
{
    Console.WriteLine("{0", i);
}

//arreglo de arreglo
int [][] matriz = new int [3][];

for ( int i = 0; i < matriz.Length; i++ )
{
    matriz [i] = new int [4];
}

valore[1] = 4;
numero[2, 1] = 10;

foreach( int i in numero)
    {
    Console.WriteLine("{0}", i);
}

