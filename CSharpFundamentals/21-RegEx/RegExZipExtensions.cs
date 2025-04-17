using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpFundamentals._21_RegEx
{
    public static class RegExZipExtensions
    {
        //string extensionPattern = @"(?i)(zip|7z|tar|tar)\.(\d+)|(?i)(\.part\d*)|(?i)(\.z\d+)$";
        //(?i) = case insensitive
        //const string EXTENSIONREGEXPATTERN = @"\.(?i)(?<singleExtension>zip|7z|rar|tar)\.(?<numberExtension>\d+)|(?i)(?<partExtension>\.part\d+)|(?i)(?<zNumExtension>\.z\d+)$";
        private const string MULTIPART_EXTENSIONS_REGEX_PATTERN = @"\.(?i)(?<singleExtension>zip|7z|rar|tar)\.(?<numberExtension>\d+)|(?i)\.(?<partNRarExtension>\.part\d+\.rar)|(?i)(?<zNumExtension>\.z\d+)$";
        const int MAX_EXTENSION_POSITION_INDEX = 5;
        const string ZIPEXTENSION = "singleZipExtension"; //cover: .zip, .7z, .rar, .tar
        const string NUMBEREXTENSION = "numberExtension"; //cover: .001, .002.. .NNN OR .01, .02, .NN
        const string PARTEXTENSION = "partExtension";     //cover: .part1, .part2.. .partN
        const string ZNumEXTENSION = "zNumExtension";     //cover: .z01, .z02.. .zNN
        public static void Demo()
        {
            string filePath = @"\Employee Discounts Aguascalientes 2021.part4";
            string[] fileSplitted = filePath.Split('.');
            fileSplitted[fileSplitted.Length - 1] = "part";
            filePath = string.Join('.', fileSplitted);
            //int dotIndex = filePath.ToLower().IndexOf(".part");
            //string partN = filePath.Substring(dotIndex);
            //filePath = filePath.Replace(partN, "part");
            string pattern = $"%{filePath}%[0-9].rar";  //e.g. '%\Demo.part%[0-9].rar'
            Console.WriteLine(pattern);

            return;



            PrintResults(GetMatchMultipartExtension(@"C:\Demo\TestDataSet01.part1.rar"));

            //List<string> zipFiles = new List<string>() { @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\7Z\text-and-pictures.7z.001",
            //    @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.rar.001",
            //    @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.zip.001",
            //    @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.part1",
            //    @"C:\Users\user\Documents\MyDocs\RevealData\ITEMS-userstories\PROC-1968\test\text-and-pictures.z01"};
            //zipFiles.ForEach(file => PrintResults(GetMatchExtension(file)));
        }
        public static Match GetMatchMultipartExtension(string sourcefile) => Regex.Match(sourcefile, MULTIPART_EXTENSIONS_REGEX_PATTERN); 
        private static void PrintResults(Match match)
        {
            Console.WriteLine($"Extension is: {match.Value}");
            PrintMatchGroups(match.Groups);
            //var result = GetExtensions(match);
            //Console.WriteLine($"Tuple: {result}{Environment.NewLine}");

            var multipartExtension = !string.IsNullOrEmpty(match.Groups["singleExtension"].Value) ? match.Groups["singleExtension"].Value : match.Groups["partNRarExtension"].Value;
            Console.WriteLine($"singleExtension: {multipartExtension}");
        }
        public static string GetMultipartSingleExtension(string sourcefile)
        {
            Match matchMultipartFileExtension = GetMatchMultipartExtension(sourcefile);
            return matchMultipartFileExtension.Success
                        ? $".{matchMultipartFileExtension.Groups["singleExtension"].Value.ToUpper()}"
                        : ".other";
        }
        private static (string LastExtension, string ExtensionBeforelast) GetExtensions(Match match)
        {
            string lastExtension = "", extensionBeforelast = "";
            if (match.Success && match.Groups.Count == MAX_EXTENSION_POSITION_INDEX)
            {
                if (match.Groups[ZIPEXTENSION].Value == "" && match.Groups[NUMBEREXTENSION].Value == "")
                {
                    lastExtension = match.Value;
                }
                else
                {
                    extensionBeforelast = match.Groups[ZIPEXTENSION].Value;
                    lastExtension = match.Groups[NUMBEREXTENSION].Value;
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

        //public static string GetFileExtension(string sourcefile, bool isMultipartFile = false)
        //{
        //    if (isMultipartFile)
        //    {
        //        var fileExtensions = GetExtensionsFile(sourcefile);
        //        return $".{fileExtensions.ExtensionBeforelast}.{fileExtensions.LastExtension}";
        //    }

        //    return LongFileIO.Path.GetASCIIExtension(sourcefile).ToUpper();
        //}
        //public static bool IsMultipartZip(string sourcefile)
        //{
        //    var fileExtensions = GetExtensionsFile(sourcefile);
        //    return IsNumericFileSegment(fileExtensions.LastExtension) && IsZipExtension(fileExtensions.ExtensionBeforelast);
        //}
        //private static (string LastExtension, string ExtensionBeforelast) GetExtensionsFile(string sourcefile)
        //{
        //    try
        //    {
        //        string fileNameWithExtension = TV.LongFileIO.Path.GetFilename(sourcefile);
        //        string[] fileNameSplited = fileNameWithExtension.Split('.');

        //        if (fileNameSplited.Length >= 3)
        //        {
        //            return (fileNameSplited[fileNameSplited.Length - 1], fileNameSplited[fileNameSplited.Length - 2]);
        //        }
        //        else if (fileNameSplited.Length == 2)
        //        {
        //            return (fileNameSplited[fileNameSplited.Length - 1], "");
        //        }

        //        return ("", "");
        //    }
        //    catch (Exception)
        //    {
        //        return ("", "");
        //    }
        //}
        //private static bool IsNumericFileSegment(string fileExtension) => int.TryParse(fileExtension, out _);
        //private static bool IsZipExtension(string fileExtension) => new string[] { "ZIP", "7Z", "TAR", "RAR" }.Contains(fileExtension.ToUpper());

    }
}
