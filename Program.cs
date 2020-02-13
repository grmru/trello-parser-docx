using System;
using Newtonsoft.Json;

namespace TIAS.Tools.Trello
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine($"First arg: {args[0]}");

                var JsonString = System.IO.File.ReadAllText(args[0]);
                if (JsonString == String.Empty) { Console.WriteLine("We have an empty input file"); return;}
                
                TrelloData TData = new TrelloData();
                try 
                {
                    TData = JsonConvert.DeserializeObject<TrelloData>(JsonString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"We have got some errors while converting JSON file: {ex.ToString()}");
                    return;
                }

                Console.WriteLine($"Board name: {TData.name}");

                string output_filename = $"{args[0]}.docx";
                TrelloParser.MakeDocx(output_filename, TData, "План работ");
                Console.WriteLine($"Output document done: {output_filename}");
            }
            else
            {
                Console.WriteLine("Need to pass a Trello JSON file as a first argument");
            }
        }
    }
}
