using System;
using System.Collections.Generic;
using System.Threading;

namespace DelegateWork
{
    delegate void DelegateWorkDelegate();    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AnyDocument> list = new List<AnyDocument>() { 
                new AnyDocument("First", "pdf"), 
                new AnyDocument("First", "doc"),
                new AnyDocument("First", "txt"),
                new AnyDocument("First", "xslx"),
                new AnyDocument("First", "csv"),
            };
            WorkWithDocuments wwd = new WorkWithDocuments();            
            DelegateWorkDelegate dwd = null;
            foreach (AnyDocument file in list)
            {
                dwd = null;
                dwd += WorkWithDocuments.OutInfoDOC;
                file.ChangeType("doc");
                wwd.DocumentsToDOC(dwd);                
            }
            wwd.Start();
        }
        
    }
    class AnyDocument 
    { 
        public string Name { get; set; }
        public string Type { get; set; }

        public AnyDocument(string name, string type) 
        {
            Name = name;
            Type = type;
        }
        public void ChangeType(string newType)
        {
            Type = newType;
        }

        public override string ToString() 
        {
            return Name + "." + Type;
        }
    }
    class WorkWithDocuments 
    {
        event DelegateWorkDelegate DelegateEvent;

        public void DocumentsToDOC(DelegateWorkDelegate dwd) 
        {
            if(dwd != null)
            {
                DelegateEvent += dwd;
            }
            
        }
        public void Start ()
        {
            if (DelegateEvent != null)
            {
                DelegateEvent.Invoke();
            }

        }
        public static void OutInfoDOC()
        {
            Console.WriteLine("Это документ ворд");
        }
        public static void OutInfoTXT(string a)
        {
            Console.WriteLine("Это документ текстовый ({0})", a);
        }
        public static void OutInfoPDF(string a)
        {
            Console.WriteLine("Это документ PDF ({0})", a);
        }
        public static void OutInfoXLSX(string a)
        {
            Console.WriteLine("Это документ MS Excel ({0})", a);
        }
        public static void OutInfoCSV(string a)
        {
            Console.WriteLine("Это документ текстовый с разделителем ({0})", a);
        }
    }
}
