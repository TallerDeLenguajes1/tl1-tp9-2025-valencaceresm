using System;
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