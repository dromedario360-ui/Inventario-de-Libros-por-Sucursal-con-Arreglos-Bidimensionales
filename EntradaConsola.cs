using System;

static class EntradaConsola
{
    public static int LeerEntero()
    {
        int numero;
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Valor no válido, intente de nuevo: ");
        }
        return numero;
    }

    public static int LeerEnRango(string mensaje, int minimo, int maximo)
    {
        Console.Write(mensaje);
        int numero = LeerEntero();

        while (numero < minimo || numero > maximo)
        {
            Console.Write("Debe estar entre " + minimo + " y " + maximo + ": ");
            numero = LeerEntero();
        }

        return numero;
    }
}

