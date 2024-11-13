using System;

namespace Course.Entities
{
    class ComboDevice : Device, IPrinter, IScanner
    {
        public override void ProcessDoc(string document)
        {
            Console.WriteLine("ComboDevice processing: " + document);
        }

        public void Print(string document)
        {
            Console.WriteLine("ComboDevice printing: " + document);
        }

        public string Scan()
        {
            return "ComboDevice scanning";
        }
    }
}