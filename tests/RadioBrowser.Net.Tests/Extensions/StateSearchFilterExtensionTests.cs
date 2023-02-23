using RestSharp;
using RadioBrowser.Net.Extensions;

namespace RadioBrowser.Net.Tests.Extensions {
    public class StateSearchFilterExtensionTests : SearchExtensionTests<StateSearchFilter> {
        public StateSearchFilterExtensionTests()
        {
            testDataList = new List<TestData<StateSearchFilter>> {
                new TestData<StateSearchFilter>(
                    null,
                    new List<Parameter>()
                    ),
                new TestData<StateSearchFilter>(
                    new StateSearchFilter {
                    },
                    new List<Parameter>() {
                        OrderParameter("name"),
                        ReverseParameter(),
                        HideBrokenParameter(),
                        OffsetParameter(),
                        LimitParameter()
                    }
                    ),
                new TestData<StateSearchFilter>(
                    new StateSearchFilter {
                        Order = SortOrder.StationCount,
                        Reverse = true,
                        HideBroken = true,
                        Offset = 10,
                        Limit = 100
                    },
                    new List<Parameter>() {
                        OrderParameter("stationcount"), 
                        ReverseParameter(true),
                        HideBrokenParameter(true),
                        OffsetParameter(10),
                        LimitParameter(100)
                    }
                    ),
                new TestData<StateSearchFilter>(
                    new StateSearchFilter {
                        Country = "Country",
                        Order = SortOrder.StationCount,
                        Reverse = true,
                        HideBroken = true,
                        Offset = 10,
                        Limit = 100
                    },
                    new List<Parameter>() {
                        OrderParameter("stationcount"),
                        ReverseParameter(true),
                        HideBrokenParameter(true),
                        OffsetParameter(10),
                        LimitParameter(100),
                        CountryParameter("Country"),
                    }
                    )
            };
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
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
