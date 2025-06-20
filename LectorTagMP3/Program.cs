// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la ruta del archivo MP3:");
        string ruta = Console.ReadLine();

        if (!File.Exists(ruta))
        {
            Console.WriteLine("El archivo no existe.");
            return;
        }

        using FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
        if (fs.Length < 128)
        {
            Console.WriteLine("El archivo es demasiado pequeño para contener un tag ID3v1.");
            return;
        }

        // Posicionarse en los últimos 128 bytes
        fs.Seek(-128, SeekOrigin.End);
        using BinaryReader reader = new BinaryReader(fs, Encoding.GetEncoding("latin1"));

        byte[] tag = reader.ReadBytes(3);
        string header = Encoding.GetEncoding("latin1").GetString(tag);

        if (header != "TAG")
        {
            Console.WriteLine("El archivo no contiene un tag ID3v1 válido.");
            return;
        }

        Id3v1Tag id3 = new Id3v1Tag
        {
            Titulo = Encoding.GetEncoding("latin1").GetString(reader.ReadBytes(30)).Trim(),
            Artista = Encoding.GetEncoding("latin1").GetString(reader.ReadBytes(30)).Trim(),
            Album = Encoding.GetEncoding("latin1").GetString(reader.ReadBytes(30)).Trim(),
            Anio = Encoding.GetEncoding("latin1").GetString(reader.ReadBytes(4)).Trim()
        };

        Console.WriteLine("Información extraída del MP3:");
        Console.WriteLine($"Título: {id3.Titulo}");
        Console.WriteLine($"Artista: {id3.Artista}");
        Console.WriteLine($"Álbum: {id3.Album}");
        Console.WriteLine($"Año: {id3.Anio}");
    }
}
