
static class DatosIniciales
{
    public static Inventario Crear()
    {
        string[] libros =
        {
            "Cien años de soledad",
            "El principito",
            "1984",
            "Rayuela",
            "Pedro Páramo"
        };

        string[] sucursales = { "Centro", "Norte", "Sur" };

        int[,] cantidades =
        {
            { 12, 5, 2 },
            { 8, 3, 10 },
            { 0, 7, 4 },
            { 6, 1, 9 },
            { 15, 2, 3 }
        };

        Inventario inventario = new Inventario(libros, sucursales);

        for (int libro = 0; libro < libros.Length; libro++)
        {
            for (int sucursal = 0; sucursal < sucursales.Length; sucursal++)
            {
                inventario.Actualizar(libro, sucursal, cantidades[libro, sucursal]);
            }
        }

        return inventario;
    }
}

