using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStrategy;

namespace MyStrategyTest
{
    [TestClass]
    public class MyHtmlParserTest
    {
        [TestMethod]
        public void Test_�^�C�g�����擾�ł��邱��()
        {
            var p = new MyHtmlParser(new MyHttpClientDummy());
            var title = p.GetTitle("https://sample.com");
            Assert.AreEqual("�e�X�g�^�C�g��", title);
        }
    }
}
