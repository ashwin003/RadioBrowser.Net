using RestSharp;
using RadioBrowser.Net.Extensions;

namespace RadioBrowser.Net.Tests.Extensions {
    public class StationCheckFilterExtensionTests : SearchExtensionTests<StationCheckFilter> {
        public StationCheckFilterExtensionTests()
        {
            var guid = Guid.NewGuid();
            testDataList = new List<TestData<StationCheckFilter>> {
                new TestData<StationCheckFilter>(
                    null,
                    new List<Parameter>()
                    ),
                new TestData<StationCheckFilter>(
                    new StationCheckFilter {
                    },
                    new List<Parameter>() {
                        LimitParameter(999999)
                    }
                    ),
                new TestData<StationCheckFilter>(
                    new StationCheckFilter {
                        Limit = 100
                    },
                    new List<Parameter>() {
                        LimitParameter(100)
                    }
                    ),
                new TestData<StationCheckFilter>(
                    new StationCheckFilter {
                        Seconds = 5,
                        Limit = 100
                    },
                    new List<Parameter>() {
                        SecondsParameter(5),
                        LimitParameter(100),
                    }
                    ),
                new TestData<StationCheckFilter>(
                    new StationCheckFilter {
                        LastCheckId = guid,
                        Seconds = 5,
                        Limit = 100
                    },
                    new List<Parameter>() {
                        LastCheckUUIDParameter(guid),
                        SecondsParameter(5),
                        LimitParameter(100),
                    }
                    )
            };
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
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
