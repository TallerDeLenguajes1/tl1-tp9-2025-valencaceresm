﻿internal class Program
{
    private static void Main(string[] args)
    {
        string path = "";

        do
        {
            Console.WriteLine("Ingrese la ruta de la carpeta a analizar:");
            path = Console.ReadLine();
        } while (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path));

        if (Directory.Exists(path))
        {
            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            if (directories.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Listados de directorios en {path}");
                Console.ResetColor();
                foreach (var directory in directories)
                {
                    var nameDirectory = Path.GetFileName(directory);
                    Console.WriteLine(nameDirectory);
                }
            }
            else
            {
                Console.WriteLine($"El directorio {path} no contiene subdirectorios");
            }

            Console.WriteLine();
            if (files.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Listados de archivos en {path}");
                Console.ResetColor();

                string path_file = "reporte_archivos.csv";
                string path_reporte = Path.Combine(path, path_file);

                using (var stream = new StreamWriter(path_reporte))
                {

                    stream.WriteLine($"Nombre del Archivo;   Tamaño (KB);   Fecha de ultima modificacion");
                    foreach (var item in files)
                    {
                        string nombre = Path.GetFileName(item);
                        var info = new FileInfo(item);
                        var length = info.Length / 1024.0;
                        var date = info.LastWriteTime;
                        Console.WriteLine($" {nombre} - Tamaño {info.Length / 1024} KB ");
                        stream.WriteLine($"{nombre};{length};{date}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"El directorio {path} no contiene archivos");
            }

        }
        else
        {
            Console.WriteLine($"No se encontro el directorio: {path}");
        }

    }
}
/*using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(){
        string path;

        //Solicitar y validar el Path
        do
        {
            Console.Write("Ingrese el path del directorio a analizar: ");
            path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("El directorio no existe. Intente nuevamente.");
            } else
            {
                break;
            }
        } while (true);

        //Mostrar subdirectorios
        Console.WriteLine("\nCarpetas:");
        string[] subdirs = Directory.GetDirectories(path);
        foreach (string dir in subdirs)
        {
            Console.WriteLine($"- {Path.GetFileName(dir)}");
        }

        //Mostrar archivos y sus tamaños
        Console.WriteLine("\nArchivos:");
        string[] files = Directory.GetFiles(path);
        var csv = new StringBuilder();
        csv.AppendLine("Nombre del Archivo, Tamaño (KB), Fecha de Última Modificación");

        foreach (string file in files)
        {
            FileInfo fi = new FileInfo(file);
            string name = fi.Name;
            double sizeKB = Math.Round(fi.Length / 1024.0, 2);
            string modified = fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

            Console.WriteLine($"- {name} ({sizeKB} KB)");

            csv.AppendLine($"-{name}; {sizeKB}; {modified}");
        }

        //Guardar CSV
        string outputCsv = Path.Combine(path, "reporte_archivos.csv");
        File.WriteAllText(outputCsv, csv.ToString());

        Console.WriteLine($"-\nInforme generado: {outputCsv}");
    }
}
*/