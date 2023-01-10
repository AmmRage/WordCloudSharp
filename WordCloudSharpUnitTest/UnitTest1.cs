using System;
using System.Drawing;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using System.Drawing.Imaging;
using WordCloudSharp;
using System.Diagnostics;

namespace WordCloudSharpUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Process proc = Process.GetCurrentProcess();
            var totalRam = proc.PeakVirtualMemorySize64;
            var ramUsage = proc.PrivateMemorySize64;

            for (var i = 0; i < 10000;i++)
            {
                if(proc.PrivateMemorySize64 > ramUsage)
                    ramUsage = proc.PrivateMemorySize64;
                var img = Image.FromFile(@"..\..\..\..\WordCloudTestApp\content\st.png");
                var image = new FastImage(img);
                image.Dispose();
            }

            Assert.IsTrue(ramUsage / totalRam < 0.9);
        }
    }
}