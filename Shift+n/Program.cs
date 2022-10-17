using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Caesar_cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../TextFile1.txt");

            Console.WriteLine("Text original:");
            string line = load.ReadLine();
            Console.WriteLine(line);
            Console.Write("Key: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Encrypted text:");
            line = Encrypt(line, n);
            Console.WriteLine(line);
            Console.WriteLine("Decrypted text:");
            line = Decrypt(line, n);
            Console.WriteLine(line);
        }
        private static string Encrypt(string v, int n)
        {
            string encrypted = "";
            for (int i = 0; i < v.Length; i++)
            {
                if (isLetter(v[i]))
                {
                    if ((v[i] >= 'a' && v[i] <= 'z'))
                        encrypted += (char)((v[i] + n - 'a') % 26 + 'a');
                    else if ((v[i] >= 'A' && v[i] <= 'Z'))
                        encrypted += (char)((v[i] + n - 'A') % 26 + 'A');
                }
                else
                    encrypted += " ";
            }
            return encrypted;
        }

        private static string Decrypt(string v, int n)
        {
            string decrypted = "";
            for (int i = 0; i < v.Length; i++)
            {
                if (isLetter(v[i]))
                {
                    if ((v[i] >= 'a' && v[i] <= 'z'))
                        decrypted += (char)((v[i] + 26 - n - 'A') % 26 + 'A');
                    else if ((v[i] >= 'A' && v[i] <= 'Z'))
                        decrypted += (char)((v[i] + 26 - n - 'A') % 26 + 'A');
                }
                else
                    decrypted += " ";
            }
            return decrypted;
        }
        private static bool isLetter(char v)
        {
            if (('a' <= v && v <= 'z') || ('A' <= v && v <= 'Z'))
                return true;
            return false;
        }
    }
}
