using RestSharp;
using RadioBrowser.Net.Extensions;

namespace RadioBrowser.Net.Tests.Extensions {
    public class StationSearchFilterExtensionTests : SearchExtensionTests<StationSearchFilter> {

        public StationSearchFilterExtensionTests()
        {
            testDataList = new List<TestData> {
                new TestData(
                    null,
                    new List<Parameter>()
                    ),
                new TestData(
                    new StationSearchFilter {
                    },
                    new List<Parameter>() {
                        OrderParameter("name"),
                        ReverseParameter(),
                        HideBrokenParameter(),
                        OffsetParameter(),
                        LimitParameter()
                    }
                    ),
                new TestData(
                    new StationSearchFilter {
                        Order = StationSortOrder.State,
                        Reverse = true,
                        HideBroken = true,
                        Offset = 10,
                        Limit = 100
                    },
                    new List<Parameter>() {
                        OrderParameter("state"),
                        ReverseParameter(true),
                        HideBrokenParameter(true),
                        OffsetParameter(10),
                        LimitParameter(100)
                    }
                    ),
            };
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void ShouldReturnExpectedParametersForSearch(int index) {
            // Arrange
            var testData = testDataList.ElementAt(index);

            // Act
            var parameters = testData.SearchInput.ToParameters();

            // Assert
            Assert.That(parameters, Is.EqualTo(testData.ExpectedParameters));
        }
    }
}
