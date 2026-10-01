using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Inventario inventario = DatosIniciales.Crear();

        MenuInventario menu = new MenuInventario(inventario);
        menu.Iniciar();
    }
}

