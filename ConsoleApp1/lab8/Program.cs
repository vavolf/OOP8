using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassCollectionType<int> intCollection = new ClassCollectionType<int>(5);
            intCollection.Add(2);
            intCollection.Display();

            ClassCollectionType<double> doubleCollection = new ClassCollectionType<double>(3);
            doubleCollection.Add(2.4);
            doubleCollection.Display();

            Document document1 = new Document("ОАО", 12, 12, 2019, true);
            Document document2 = new Document("ООО", 9, 10, 2019, true);
            Document document3 = new Document("МММ", 10, 4, 1999, true);
            ClassCollectionType<Document> documentClollection = new ClassCollectionType<Document>(3);
            documentClollection.Add(document1);
            documentClollection.Add(document2);
            documentClollection.Add(document3);
            documentClollection.Display();

            documentClollection.ToFile();
            Console.WriteLine("Чтение из файла");
            documentClollection.FromFileToConsole();
            Console.ReadKey();
        }
    }
}
