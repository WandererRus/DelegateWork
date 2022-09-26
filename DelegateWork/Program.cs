using System;

namespace DelegateWork
{
    delegate void DelegateWorkDelegate(string a);
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] massiveFiles = new string[10] {"first.doc", "second.doc", "third.txt", "four.pdf", "five.xlsx", "six.txt",
           "seven.pdf", "eight.xlsx","nine.csv","ten.csv"};
            DelegateWorkDelegate dwd = null;
            foreach (string file in massiveFiles)
            {
                dwd = null;
                string[] filemassiv = file.Split('.');
                switch (filemassiv[1]) 
                {
                    case "doc": dwd += OutInfoDOC; dwd(file); break;
                    case "txt": dwd += OutInfoTXT; dwd(file); break;
                    case "pdf": dwd += OutInfoPDF; dwd(file); break;
                    case "xlsx": dwd += OutInfoXLSX; dwd(file); break;
                    case "csv": dwd += OutInfoCSV; dwd(file); break;
                        default:Console.WriteLine("Что-то пошло не так");break;
                }
            }
        }
        static void OutInfoDOC(string a) {
            Console.WriteLine("Это документ MS Word ({0})",a);
        }
        static void OutInfoTXT(string a)
        {
            Console.WriteLine("Это документ текстовый ({0})", a);
        }
        static void OutInfoPDF(string a)
        {
            Console.WriteLine("Это документ PDF ({0})", a);
        }
        static void OutInfoXLSX(string a)
        {
            Console.WriteLine("Это документ MS Excel ({0})", a);
        }
        static void OutInfoCSV(string a)
        {
            Console.WriteLine("Это документ текстовый с разделителем ({0})", a);
        }
    }
}
