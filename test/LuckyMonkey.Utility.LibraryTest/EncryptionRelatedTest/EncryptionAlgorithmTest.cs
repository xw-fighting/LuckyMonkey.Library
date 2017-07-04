using LuckyMonkey.Utility.Library.EncryptionRelated;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LuckyMonkey.Utility.LibraryTest.EncryptionRelated
{
    /// <summary>
    /// 算法加密的测试方法
    /// </summary>
    public class EncryptionAlgorithmTest
    {
        private const string  testInput = "welcome to LuckyMonkey's program";
        /// <summary>
        /// SHA1加密测试方法
        /// </summary>
        [Fact]
        public void Sha1EncryptTest()
        {
            var result = EncryptionAlgorithm.Sha1Encrypt(testInput);
            Assert.True(result.Equals("b7a90b0f379ed3dad6d7699b80ad7ace517e130c"));
        }

        /// <summary>
        /// Md5的16为加密算法就是取32为加密后的字符串的8-24位的字符串
        /// </summary>
        [Fact]
        public void Md5EncryptToStr16Test()
        {
            var result = EncryptionAlgorithm.Md5EncryptToStr16(testInput).ToLower() ;
            Assert.True(result.Equals("d361a567f1ea411d"));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Md5EncryptToStr32()
        {
            var result = EncryptionAlgorithm.Md5EncryptToStr32(testInput);
            Assert.True(result.Equals("820fae05d361a567f1ea411d24c4bf1f"));
        }

    }
}
