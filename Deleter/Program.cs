using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Deleter
{
    class Program
    {
        static void Deleter()
        {
            Console.WriteLine("Escolha a pasta:");
            Console.WriteLine("1 - Downloads");
            Console.WriteLine("2 - Documentos");
            Console.WriteLine("3 - Imagens");
            Console.WriteLine("4 - Musicas");
            Console.WriteLine("5 - Videos");
            Console.Write(">");
            string resp = Console.ReadLine();
            bool interruptor = true;

            string diretorio = "undefined";

            while (interruptor)
            {
                switch (resp)
                {
                    case "teste":
                        diretorio = @"C:\Users\LeanZo\Desktop\teste";
                        interruptor = false;
                        break;
                    case "1":
                        diretorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                        interruptor = false;
                        break;
                    case "2":
                        diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        interruptor = false;
                        break;
                    case "3":
                        diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                        interruptor = false;
                        break;
                    case "4":
                        diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                        interruptor = false;
                        break;
                    case "5":
                        diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                        interruptor = false;
                        break;
                    default:
                        Console.WriteLine("'{0}' Não é válido, escolha uma das opções acima:", resp);
                        Console.Write(">");
                        resp = Console.ReadLine();
                        break;   
                 }
            }

            Console.WriteLine("Log? (S/N)");
            string resp2 = Console.ReadLine().ToUpper();
            Console.WriteLine("Qual prefixo deseja usar? (Case Sensitive)");
            string resp3 = Console.ReadLine();
            if (String.IsNullOrEmpty(resp3) || String.IsNullOrWhiteSpace(resp3))
                resp3 = "textosafayashi3322";
            string resp4 = "^" + resp3;

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
            Console.WriteLine("Concluido!");

        }


        static void Main(string[] args)
        {
            bool interruptor = true;
            string resp = "undefined";
            do
            {
                Deleter();
                Console.WriteLine();
                Console.WriteLine("Deseja realizar outra operação?(S/N)");
                Console.Write(">");
                resp = Console.ReadLine().ToUpper();
                if (resp != "S")
                {
                    interruptor = false;
                }

            } while (interruptor);



        }
    }
}
