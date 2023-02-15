using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStrategy;

namespace MyStrategyTest
{
    [TestClass]
    public class MyHtmlParserTest
    {
        [TestMethod]
        public void Test_タイトルが取得できること()
        {
            var p = new MyHtmlParser(new MyHttpClientDummy());
            var title = p.GetTitle("https://sample.com");
            Assert.AreEqual("テストタイトル", title);
        }
    }
}
