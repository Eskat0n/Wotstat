namespace Crawler.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PlayerInfoGetterTests
    {
        private const int PlayerId = 100;

        [Test]
        public void ShouldGetStatisticCorrectly()
        {
            var playerInfoProvider = new PlayerInfoProvider();
            var playerInfo = playerInfoProvider.GetPlayerInfo(PlayerId);
            
            Assert.NotNull(playerInfo);
        }
    }
}