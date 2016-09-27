using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Deleter
{
    class Program
    {
        static void Main(string[] args)
        {




            Console.WriteLine("Escolha a pasta:");
            Console.WriteLine("1 - Downloads");
            Console.WriteLine("2 - Documentos");
            Console.WriteLine("3 - Imagens");
            Console.WriteLine("4 - Musicas");
            Console.WriteLine("5 - Videos");
            string resp = Console.ReadLine();
            Console.WriteLine("Log? (S/N)");
            string resp2 = Console.ReadLine().ToUpper();
            Console.WriteLine("Qual prefixo deseja usar? (Case Sensitive)");
            string resp3 = Console.ReadLine();
            string resp4 = "^" + resp3;

            string diretorio = "undefined";

            switch (resp)
            {
                case "teste":
                    diretorio = @"C:\Users\LeanZo\Desktop\Teste";
                    break;
                case "1":
                    diretorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    break;
                case "2":
                    diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    break;
                case "3":
                    diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    break;
                case "4":
                    diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    break;
                case "5":
                    diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                    break;
            }

            DirectoryInfo di = new DirectoryInfo(diretorio);

            Console.WriteLine("Excluindo...");
            Console.WriteLine();

            Regex rgx = new Regex(resp4);
            foreach (var fi in di.GetFiles())
            {
                if (!rgx.IsMatch(fi.Name))
                {
                    string arquivo = Path.Combine(diretorio, fi.Name);
                    File.Delete(arquivo);
                    if (resp2 == "S")
                        Console.WriteLine(arquivo);
                }
            }




        }
    }
}
