using System;

class MenuInventario
{
    private Inventario inventario;

    public MenuInventario(Inventario inventario)
    {
        this.inventario = inventario;
    }

    public void Iniciar()
    {
        int opcion = -1;

        while (opcion != 0)
        {
            MostrarMenu();
            opcion = EntradaConsola.LeerEntero();

            switch (opcion)
            {
                case 1: MostrarInventarioCompleto(); break;
                case 2: ConsultarDisponibilidad(); break;
                case 3: ActualizarDisponibilidad(); break;
                case 4: TotalDeUnLibro(); break;
                case 5: TotalPorSucursal(); break;
                case 6: MostrarBajoInventario(); break;
                case 7: SucursalConMayorDisponibilidad(); break;
                case 0: Console.WriteLine("Hasta luego."); break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }

    private void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("====== INVENTARIO POR SUCURSAL ======");
        Console.WriteLine();
        Console.WriteLine("1. Mostrar inventario completo");
        Console.WriteLine("2. Consultar disponibilidad");
        Console.WriteLine("3. Actualizar disponibilidad");
        Console.WriteLine("4. Total disponible de un libro");
        Console.WriteLine("5. Total de inventario por sucursal");
        Console.WriteLine("6. Mostrar libros con bajo inventario");
        Console.WriteLine("7. Sucursal con mayor disponibilidad");
        Console.WriteLine("0. Salir");
        Console.WriteLine();
        Console.Write("Seleccione una opción: ");
    }

    private int PedirLibro()
    {
        Console.WriteLine();
        for (int i = 0; i < inventario.CantidadLibros; i++)
        {
            Console.WriteLine((i + 1) + ". " + inventario.NombreLibro(i));
        }

        int numero = EntradaConsola.LeerEnRango("Número del libro: ", 1, inventario.CantidadLibros);
        return numero - 1;
    }

    private int PedirSucursal()
    {
        Console.WriteLine();
        for (int j = 0; j < inventario.CantidadSucursales; j++)
        {
            Console.WriteLine((j + 1) + ". " + inventario.NombreSucursal(j));
        }

        int numero = EntradaConsola.LeerEnRango("Número de la sucursal: ", 1, inventario.CantidadSucursales);
        return numero - 1;
    }

    private void MostrarInventarioCompleto()
    {
        Console.WriteLine();
        Console.Write("Libro".PadRight(28));
        for (int j = 0; j < inventario.CantidadSucursales; j++)
        {
            Console.Write(inventario.NombreSucursal(j).PadRight(10));
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 28 + 10 * inventario.CantidadSucursales));

        for (int i = 0; i < inventario.CantidadLibros; i++)
        {
            string etiqueta = (i + 1) + ". " + inventario.NombreLibro(i);
            Console.Write(etiqueta.PadRight(28));

            for (int j = 0; j < inventario.CantidadSucursales; j++)
            {
                Console.Write(inventario.Consultar(i, j).ToString().PadRight(10));
            }
            Console.WriteLine();
        }
    }

    private void ConsultarDisponibilidad()
    {
        int libro = PedirLibro();
        int sucursal = PedirSucursal();

        int cantidad = inventario.Consultar(libro, sucursal);

        Console.WriteLine();
        Console.WriteLine("\"" + inventario.NombreLibro(libro) + "\" en " +
                          inventario.NombreSucursal(sucursal) + ": " + cantidad + " unidades.");
    }

    private void ActualizarDisponibilidad()
    {
        int libro = PedirLibro();
        int sucursal = PedirSucursal();

        Console.WriteLine("Cantidad actual: " + inventario.Consultar(libro, sucursal));
        Console.Write("Nueva cantidad: ");
        int nueva = EntradaConsola.LeerEntero();

        if (inventario.Actualizar(libro, sucursal, nueva))
        {
            Console.WriteLine("Disponibilidad actualizada.");
        }
        else
        {
            Console.WriteLine("La cantidad no puede ser negativa.");
        }
    }

    private void TotalDeUnLibro()
    {
        int libro = PedirLibro();

        Console.WriteLine();
        Console.WriteLine("Total de \"" + inventario.NombreLibro(libro) + "\": " +
                          inventario.TotalDeLibro(libro) + " unidades.");
    }

    private void TotalPorSucursal()
    {
        int sucursal = PedirSucursal();

        Console.WriteLine();
        Console.WriteLine("Total en la sucursal " + inventario.NombreSucursal(sucursal) + ": " +
                          inventario.TotalDeSucursal(sucursal) + " unidades.");
    }

    private void MostrarBajoInventario()
    {
        Console.WriteLine();
        Console.WriteLine("Libros con " + Inventario.LimiteBajo + " unidades o menos:");

        int encontrados = 0;

        for (int i = 0; i < inventario.CantidadLibros; i++)
        {
            for (int j = 0; j < inventario.CantidadSucursales; j++)
            {
                if (inventario.EsBajoInventario(i, j))
                {
                    Console.WriteLine("- " + inventario.NombreLibro(i) + " | " +
                                      inventario.NombreSucursal(j) + " | " +
                                      inventario.Consultar(i, j) + " unidades");
                    encontrados++;
                }
            }
        }

        if (encontrados == 0)
        {
            Console.WriteLine("No hay libros con bajo inventario.");
        }
    }

    private void SucursalConMayorDisponibilidad()
    {
        int libro = PedirLibro();
        int mejor = inventario.SucursalConMayor(libro);

        Console.WriteLine();
        Console.WriteLine("\"" + inventario.NombreLibro(libro) + "\" tiene más disponibilidad en " +
                          inventario.NombreSucursal(mejor) + " (" +
                          inventario.Consultar(libro, mejor) + " unidades).");
    }
}

