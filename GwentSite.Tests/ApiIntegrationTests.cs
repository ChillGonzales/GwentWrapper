using System;
using NUnit.Framework;
using Moq;
using GwentSite.ApiWrapper;
using System.Threading.Tasks;
using System.Net.Http;

namespace GwentSite.Tests
{
    [TestFixture]
    public class ApiIntegrationTests
    {
        private static Client client = new Client(new HttpClient());
        private const string aRushHref = "https://api.gwentapi.com/v0/cards/rLuBBJg8QB2c_tyfktLnbQ";

        [Test]
        [TestCase(20, 0)]
        [TestCase(40, 20)]
        public async Task PageTest(int count, int offset)
        {
            var result = await client.GetPageOfCards(new ApiWrapper.Requests.GetPageOfCardsRequest()
            {
                Count = count,
                Offset = offset 
            });
            Assert.AreEqual(count, result.Results.Count);
        }
        [Test]
        [TestCase(20, 20)]
        [TestCase(20, 40)]
        [TestCase(40, 40)]
        public async Task NextPageTest(int count, int offset)
        {
            var result = await client.GetPageOfCards(new ApiWrapper.Requests.GetPageOfCardsRequest()
            {
                Count = count,
                Offset = offset
            });
            Assert.AreNotEqual("Adrenaline Rush", result.Results[0].Name);
            Assert.AreEqual(count, result.Results.Count);
        }
        [Test]
        [TestCase(aRushHref)]
        public async Task GetCardDataTest(string cardHref)
        {
            var result = await client.GetCardData(new ApiWrapper.Requests.GetCardDataRequest()
            {
                Href = cardHref
            });
            Assert.AreEqual("Adrenaline Rush", result.Name);
        }
    }
}
