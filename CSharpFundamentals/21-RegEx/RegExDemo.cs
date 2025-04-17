using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpFundamentals._21_RegEx
{
    public static class RegExDemo
    {
        const int MAX_EXTENSION_POSITION_INDEX = 5;

        public static void Demo()
        {
            //string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            //string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
            //             "Abraham Adams", "Ms. Nicole Norris" };
            //foreach (string name in names)
            //    Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
            //return;

            //string regex = @"^pato1{2,}A$";
            //string text = "pato11A";
            //string regex = "<beer>.*?</beer>";
            //string text = "<beer>corona</beer><beer>heineken</beer>";
            //var match = Regex.Match(text, regex);
            //Console.WriteLine(match.Groups);
            //return;

            var sourcefile = @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\7Z\text-and-pictures.7z.001";
            var fileExtensions = GetExtensionsWithRegex(sourcefile);  //GetExtensionsFile(sourcefile);
            //Console.WriteLine(Environment.NewLine);
            //Console.WriteLine(fileExtensions);

            //var sourcefile = @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.7z.001";
            //bool res = IsMultipartZip(sourcefile);
            //Console.WriteLine(res);
            #region test
            //var separators = new char[] {
            //  Path.DirectorySeparatorChar,
            //  Path.AltDirectorySeparatorChar
            //};


            //string sourcefile = @"\\?\C:\Users\jchavez\Documents\MyNotes\PROC-1968\PROC-1968\TestDataSet01_2.zip.003";
            //sourcefile = @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.7z.001";
            //string extension = Path.GetExtension(sourcefile).ToUpper();

            //string extension = ".ad1"; //".ad1"; // ".zip.001";  // ".001"; //".ad1";
            //var match = System.Text.RegularExpressions.Regex.Match(extension, @"^([^0-9]+)([0-9]+)$");
            //foreach (var item in match.Groups)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //.ad1 .ad 1

            //FileExtension();

            //var basePath = @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test";
            //var result = GetZipFormat(basePath);

            //var isValid = true;
            //foreach (var fmt in GetZipFormat(basePath))
            //    switch (fmt)
            //    {
            //        case "TAR":
            //            isValid = isValid & IsZipValid(basePath, "500mbInputData.tar.*");
            //            break;
            //        case "ZIP":
            //            isValid = isValid & IsZipValid(basePath, "500mbInputData.zip.*");
            //            break;
            //        case "7ZIP":
            //            isValid = isValid & IsZipValid(basePath, "500mbInputData.7z.*");
            //            break;
            //        default:
            //            break;
            //    }
            #endregion
        }
        public static (string LastExtension, string ExtensionBeforelast) GetExtensionsWithRegex(string sourcefile)
        {
            string lastExtension = "", extensionBeforelast = "";
            //string extensionPattern = @"(zip|7z|tar|tag)\.(\d+)|(?i)(\.part\d*)|(?i)(\.z\d+)$";
            string extensionPattern = @"(?<zipExtensionAsItIs>zip|7z|tar|tag)\.(?<anyNumbers>\d+)|(?i)(?<partExtension>\.part\d*)|(?i)(?<zNumExtension>\.z\d+)$";

            //  ?i = case insensitive
            //  \w+ = allows any characters
            //  \D allows all except numbers
            //  \s = espacios en blanco
            //var example = @"\w+\s+d+$";  //must exist a letter or more, an space or more and a number or more at the end.

            var match = Regex.Match(sourcefile, extensionPattern);
            PrintResults(match);

            sourcefile = @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.zip.001";
            match = Regex.Match(sourcefile, extensionPattern);
            PrintResults(match);

            sourcefile = @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.part1";
            match = Regex.Match(sourcefile, extensionPattern);
            PrintResults(match);

            sourcefile = @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.z01";
            match = Regex.Match(sourcefile, extensionPattern);
            PrintResults(match);

            return (lastExtension, extensionBeforelast);
        }
        private static void PrintResults(Match match)
        {
            Console.WriteLine($"Extension is: {match.Value}");
            var result = GetExtensions(match);
            PrintMatchGroups(match.Groups);
            Console.WriteLine(result + Environment.NewLine); 
        }
        private static (string LastExtension, string ExtensionBeforelast) GetExtensions(Match match)
        {
            string lastExtension = "", extensionBeforelast = "";
            if (match.Success && match.Groups.Count == MAX_EXTENSION_POSITION_INDEX)
            {
                if (match.Groups[1].Value == "" && match.Groups[2].Value == "")
                {
                    lastExtension = match.Groups[0].Value;
                }
                else
                {
                    extensionBeforelast = match.Groups[1].Value;
                    lastExtension = match.Groups[2].Value;
                }
            }
            return (lastExtension, extensionBeforelast);
        }
        private static void PrintMatchGroups(GroupCollection group)
        {
            int i = -1;
            while (++i < group.Count)
            {
                Console.WriteLine($"{i} {group[i]}");
            }
        }
        private static (string LastExtension, string ExtensionBeforelast) GetExtensionsFile(string sourcefile)
        {
            try
            {
                string fileNameWithExtension = GetFilename(sourcefile);
                string[] fileNameSplited = fileNameWithExtension.Split('.');
                return (fileNameSplited[fileNameSplited.Length - 1], fileNameSplited[fileNameSplited.Length - 2]);
            }
            catch (Exception)
            {
                return ("", "");
            }
        }
        public static string GetFilename(string filePath)
        {
            string retval;
            try
            {
                if (filePath.IsS3())
                {
                    if (filePath.LastIndexOf('/') != -1)
                        retval = filePath.Substring(filePath.LastIndexOf('/') + 1);
                    else
                        retval = filePath;
                }
                else
                {
                    if (filePath.LastIndexOf('\\') != -1)
                        retval = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                    else
                        retval = filePath;
                }
            }
            catch
            {
                retval = filePath;
            }
            return retval.TrimEnd(new char[] { '\\' });
        }
        public static bool IsS3(this string str) { return (str.StartsWith("s3:", StringComparison.InvariantCultureIgnoreCase) || str.StartsWith(@"/")); }
        
        
        private static bool IsMultipartZip(string sourcefile)
        {
            string fileNameWithExtension = Path.GetFileName(sourcefile);  //eg: text-and-pictures.7z.001
            string[] fileNameSplited = fileNameWithExtension.Split('.');
            //TODO: validate edge cases, for example not extensions or string array is empty
            string LastExtension = fileNameSplited[fileNameSplited.Length - 1];
            if (IsNumericFileSegment(LastExtension))  //001,002,003,...NNN
            {
                string ExtensionBeforeLast = fileNameSplited[fileNameSplited.Length - 2];
                return IsZipExtension(ExtensionBeforeLast); //zip,7z,tar
            }
            return false;
        }
        private static bool IsNumericFileSegment(string fileExtension) => int.TryParse(fileExtension, out _);
        private static bool IsZipExtension(string fileExtension)
        {
            string[] validZipExtensions = new string[] { "ZIP", "7Z", "TAR" };
            return validZipExtensions.Contains(fileExtension.ToUpper());
        }

        public static void FileExtension()
        {
            //const string file = "TestDataSet01_2.zip.001";
            //var pattern = "^.*\.(jpg | JPG | gif | GIF | doc | DOC | pdf | PDF)$";

            //string pattern = @"\b[M]\w+";
            //Regex rg = new Regex(pattern);
            //string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";
            //MatchCollection matchedAuthors = rg.Matches(authors);

        }

        public static List<string> GetZipFormat(string path)
        {
            bool filesFound(string basePath, string pattern) => System.IO.Directory.EnumerateFiles(
                    basePath, pattern, SearchOption.TopDirectoryOnly).Any();

            var isTar = filesFound(path, "*.tar.???");
            var isZip = filesFound(path, "*.z??");
            var is7Zip = filesFound(path, "*.7z.???");

            var result = new List<string>();
            if (isTar) result.Add("TAR");
            if (isZip) result.Add("ZIP");
            if (is7Zip) result.Add("7ZIP");
            return result;
        }
    }
}
