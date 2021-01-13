using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise1
{
    public static class FileFiller
    {


        private static Random charRandomizer = new Random();
        private static Random stringRandomizer = new Random();
        private static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static int fileLength = 100000;
        private static int maxStringLength = 100;

        public static string RandomString(int length)
        {
            var randomString = new StringBuilder();

            for (int i = 0; i < length; i++)
                randomString.Append(chars[charRandomizer.Next(chars.Length)]);

            return randomString.ToString();
        }

        public static void FillFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName)) File.Delete(fileName);
            }
            catch (Exception e) { throw ( new Exception("File already exists, but cannot be deleted: " + e.Message)); }


            try
            {
                using (StreamWriter file = new StreamWriter(fileName))
                {
                    try
                    {
                        string[] lines = new string[fileLength];
                        for (var lineNum = 0; lineNum < fileLength; lineNum++)
                            file.WriteLine(RandomString(stringRandomizer.Next(1, maxStringLength)));
                    }
                    catch (Exception e) { throw (new Exception("Exception while trying to write to a file: " + e.Message)); }
                    finally { file.Close(); }
                }
            }


            catch (Exception e) { throw (new Exception("Exception while trying to create a file: " + e.Message)); }
        }
    }
}
