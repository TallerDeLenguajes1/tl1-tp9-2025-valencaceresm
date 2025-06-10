// See https://aka.ms/new-console-template for more information
public class Cancion
{
    public string Header { get; set; }
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Album { get; set; }
    public uint anio { get; set; }
    public string Comentario { get; set; }
    public string Genero { get; set; }
}

//------------
using System;
using System.Collections.Generic;
using System.IO;
using TagLib;

class Program
{
    static void Main(){
        List<Cancion> canciones = new List<Cancion>();

        Console.Write("Ingrese la ruta de una carpeta con archivos MP3: ");
        string path = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Carpeta no encontrada.");
            return;
        }

        string[] archivos = Directory.GetFiles(path, "*.mp3");

        foreach (string archivo in archivos)
        {
            try
            {
                var mp3 = TagLib.File.Create(archivo);
                Cancion c = new Cancion
                //=================TERMINARRRRRRRRR
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
