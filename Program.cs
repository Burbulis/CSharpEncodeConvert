using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{


    class convertor
    {

       public convertor(String str)
        {
            utf8 = Encoding.GetEncoding("Utf-8");
            windows1251 = Encoding.GetEncoding("Windows-1251");

            this.utf8Byte = utf8.GetBytes(str);
            this.windows125Byte = Encoding.Convert(utf8, windows1251, utf8Byte);
        }

        public
        string 
        getString()
        {
          
            return( windows1251.GetString(windows125Byte));
        }
        //   
        public 
        byte[]
            getWinBuffer()
        {
            return (windows125Byte);
        }

        Encoding utf8;
        Encoding windows1251;
        private byte[] utf8Byte;
        private byte[] windows125Byte;
    }

    class Program
    {
        static void Main(string[] args)
        {

            /*   byte[] bytes = new byte[49];
               // Create index for current position of array.
               int index = 0;

               Encoding asciiEncoding = Encoding.ASCII;
               String stringValue = "Привет Чувак!!!";
               Console.WriteLine("Strings to encode:");
                   Console.WriteLine("   {0}", stringValue);

                   int count = asciiEncoding.GetByteCount(stringValue);
                       Array.Resize(ref bytes, bytes.Length + 50);

                   int written = asciiEncoding.GetBytes(stringValue, 0,
                                                        stringValue.Length,
                                                        bytes, index);

               */

            convertor conv = new convertor( "Привет Чувак!\r\nТы обосрался!");
       

            //Sms.SendSms("89138052076", str);
            Console.WriteLine(conv.getString());

            byte[] buff = conv.getWinBuffer();
            FileStream fs = File.Create("c:\\esd\\test.txt");
            fs.Write(buff, 0, buff.Length);


        }
    }
}
