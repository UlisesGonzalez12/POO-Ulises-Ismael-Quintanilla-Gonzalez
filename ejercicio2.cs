// sistema basico para una biblioteca
using System;
using System.Collections.Generic;

class ItemBiblioteca
{
    public string Titulo { get; set; }
    public int AnioPublicacion { get; set; }

    public ItemBiblioteca(string titulo, int anioPublicacion)
    {
        Titulo = titulo;
        AnioPublicacion = anioPublicacion;
    }

    public virtual void MostrarDetalles()
    {
        Console.WriteLine($"Título: {Titulo}, Año de publicación: {AnioPublicacion}");
    }
}

class Libro : ItemBiblioteca
{
    public int NumeroPaginas { get; set; }

    public Libro(string titulo, int anioPublicacion, int numeroPaginas) : base(titulo, anioPublicacion)
    {
        NumeroPaginas = numeroPaginas;
    }

    public override void MostrarDetalles()
    {
        base.MostrarDetalles();
        Console.WriteLine($"Número de páginas: {NumeroPaginas}");
    }
}

class Revista : ItemBiblioteca
{
    public string Editorial { get; set; }

    public Revista(string titulo, int anioPublicacion, string editorial) : base(titulo, anioPublicacion)
    {
        Editorial = editorial;
    }

    public override void MostrarDetalles()
    {
        base.MostrarDetalles();
        Console.WriteLine($"Editorial: {Editorial}");
    }
}

class Biblioteca
{
    private List<ItemBiblioteca> items = new List<ItemBiblioteca>();

    public void AgregarItem(ItemBiblioteca item)
    {
        items.Add(item);
    }

    public void MostrarCatalogo()
    {
        foreach (var item in items)
        {
            item.MostrarDetalles();
        }
    }

    public static int CalcularTotalPaginas(Biblioteca biblioteca)
    {
        int totalPaginas = 0;
        foreach (var item in biblioteca.items)
        {
            if (item is Libro)
            {
                totalPaginas += ((Libro)item).NumeroPaginas;
            }
        }
        return totalPaginas;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        Libro libro1 = new Libro("Cien años de soledad", 1967, 432);
        Libro libro2 = new Libro("El nombre del viento", 2007, 662);
        Revista revista1 = new Revista("National Geographic", 2021, "National Geographic Society");

        biblioteca.AgregarItem(libro1);
        biblioteca.AgregarItem(libro2);
        biblioteca.AgregarItem(revista1);

        Console.WriteLine("Catálogo de la biblioteca:");
        biblioteca.MostrarCatalogo();

        int totalPaginas = Biblioteca.CalcularTotalPaginas(biblioteca);
        Console.WriteLine($"El total de páginas en la biblioteca es: {totalPaginas}");
    }
}


