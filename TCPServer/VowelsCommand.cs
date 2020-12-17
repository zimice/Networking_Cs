using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCPServer
{
    class VowelsCommand : Command
    {
        private static StreamWriter writer;
        private static StreamReader reader;

        public VowelsCommand(StreamWriter sWriter,StreamReader sReader) {
            writer = sWriter;
            reader = sReader;

        }
        public override string[] Alias()
        {
            string[] aliases = {"vowels","vowel","samohlasky","samohlaska" };
            return aliases;
        }

        public override string Execute()
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            char[] constant = { 'q', 'w', 'r', 't', 'y', 'p', 's', 'd','f','g','h','j','k','l','z','x','c','v','b','n','m' };
            writer.WriteLine("Server>Napiste slovo na spocitani");
            writer.Write("Client> ");
            writer.Flush();
            String sData = reader.ReadLine();
            Console.WriteLine(sData);
            int vowelCount=0;
            int consonantCount=0;
            foreach (char vowel in vowels)
                vowelCount += sData.Split(vowel).Length - 1;

            foreach (char constant in vowels)
                consonantCount += sData.Split(constant).Length - 1;
            return "Vowel count: " + vowelCount + " Consonant count: " + consonantCount;
        }

        public override string getHelp()
        {
            return "This command return count of vowels and souhlasek";
        }
    }
}
