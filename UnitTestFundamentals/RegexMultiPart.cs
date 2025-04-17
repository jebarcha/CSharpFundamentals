using Xunit;

namespace UnitTestFundamentals
{
    public class RegexMultiPart
    {
        [Theory]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.7z.001")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.7z.002")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.zip.001")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.zip.01")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.part1")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.part2")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.part01")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.z01")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.z02")]
        public void ShouldMatch_MultiPartZip_Extensions(string sourcefile)
        {
            var match = CSharpFundamentals._21_RegEx.RegExZipExtensions.GetMatchMultipartExtension(sourcefile);

            Assert.True(match.Success);
        }

        [Theory]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.7z")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.zip")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.part")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\7Z\demo.z")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.docx")]
        [InlineData(@"C:\Users\user\Documents\MyDocs\demo.xlsx")]
        public void ShouldNotMatch_MultiPartZip_Extensions(string sourcefile)
        {
            var match = CSharpFundamentals._21_RegEx.RegExZipExtensions.GetMatchMultipartExtension(sourcefile);

            Assert.False(match.Success);
        }


    }
}