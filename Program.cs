using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aho_Corasick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string[] dict = { "about", "at", "ate", "eat", "apple" };
                string text = "I ate an apple at about ten ";
                Aho_Corasick ahc = new Aho_Corasick(dict);

                ahc.init_All();
                ahc.run(text);
                //FileReader fileReader = new FileReader();
                //byte[] data = fileReader.ReadFile(@"E:\\yudA\\cs\\computer since\\Aho-Corasick\\Aho-Corasick.pptx");
                //for (int i = 0; i < data.Length; i++)
                //{
                //    Console.WriteLine(data[i] + " ");
                //}




            }
        }
        internal class FileReader
        {
            public byte[] ReadFile(string filename)
            {

                //byte[] buffer = null;
                //FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                return File.ReadAllBytes(filename);
                //BinaryReader br = new BinaryReader(fs);
                //long bytesnum = new FileInfo(filename).Length;
                //buffer = br.ReadAllBytes(m);
                //br.Close();
                //fs.Close();
                //return buffer;
            }
        }
    }
}