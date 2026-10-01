

class Inventario
{
    public const int LimiteBajo = 3;

    private string[] libros;
    private string[] sucursales;
    private int[,] stock;

    public Inventario(string[] libros, string[] sucursales)
    {
        this.libros = libros;
        this.sucursales = sucursales;
        stock = new int[libros.Length, sucursales.Length];
    }

    public int CantidadLibros
    {
        get { return stock.GetLength(0); }
    }

    public int CantidadSucursales
    {
        get { return stock.GetLength(1); }
    }

    public string NombreLibro(int libro)
    {
        return libros[libro];
    }

    public string NombreSucursal(int sucursal)
    {
        return sucursales[sucursal];
    }

    public int Consultar(int libro, int sucursal)
    {
        return stock[libro, sucursal];
    }

    public bool Actualizar(int libro, int sucursal, int cantidad)
    {
        if (cantidad < 0)
        {
            return false;
        }

        stock[libro, sucursal] = cantidad;
        return true;
    }

    public int TotalDeLibro(int libro)
    {
        int total = 0;

        for (int sucursal = 0; sucursal < CantidadSucursales; sucursal++)
        {
            total = total + stock[libro, sucursal];
        }

        return total;
    }

    public int TotalDeSucursal(int sucursal)
    {
        int total = 0;

        for (int libro = 0; libro < CantidadLibros; libro++)
        {
            total = total + stock[libro, sucursal];
        }

        return total;
    }

    public bool EsBajoInventario(int libro, int sucursal)
    {
        return stock[libro, sucursal] <= LimiteBajo;
    }

    public int SucursalConMayor(int libro)
    {
        int mejor = 0;

        for (int sucursal = 1; sucursal < CantidadSucursales; sucursal++)
        {
            if (stock[libro, sucursal] > stock[libro, mejor])
            {
                mejor = sucursal;
            }
        }

        return mejor;
    }
}

