using RadioBrowser.Net.Extensions;
using RestSharp;

namespace RadioBrowser.Net.Tests.Extensions {
    public class AdvancedStationSearchExtensionTests : SearchExtensionTests<AdvancedStationSearch> {
        public AdvancedStationSearchExtensionTests()
        {
            testDataList = new List<TestData<AdvancedStationSearch>>()
            {
                new TestData<AdvancedStationSearch>(
                    null,
                    new List<Parameter>()
                    ),
                new TestData<AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        Name = "Name",
                    },
                    new List<Parameter>()
                    {
                        NameParameter("Name"),
                        NameExactParameter(),
                        CountryExactParameter(),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData<AdvancedStationSearch>(
                    new AdvancedStationSearch(),
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryExactParameter(),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData <AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        Country = "Country"
                    },
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryParameter("Country"),
                        CountryExactParameter(),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData <AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        CountryCode = "CC"
                    },
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryExactParameter(),
                        CountryCodeParameter("CC"),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData <AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        State = "State"
                    },
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryExactParameter(),
                        StateParameter("State"),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData <AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        Language = "Language"
                    },
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryExactParameter(),
                        StateExactParameter(),
                        LanguageParameter("Language"),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData <AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        Tag = "Tag"
                    },
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryExactParameter(),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagParameter("Tag"),
                        TagExactParameter(),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData <AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        TagList = new List<string> { "Tag" }
                    },
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryExactParameter(),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        TagListParameter("Tag"),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
                    }
                    ),
                new TestData <AdvancedStationSearch>(
                    new AdvancedStationSearch
                    {
                        Codec = "Codec"
                    },
                    new List<Parameter>()
                    {
                        NameExactParameter(),
                        CountryExactParameter(),
                        StateExactParameter(),
                        LanguageExactParameter(),
                        TagExactParameter(),
                        CodecParameter("Codec"),
                        MinimumBitrateParameter(),
                        MaximumBitrateParameter(),
                        OrderParameter("name"),
                        ReverseParameter(),
                        OffsetParameter(),
                        LimitParameter(),
                        HideBrokenParameter()
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
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void ShouldReturnExpectedParametersForAdvancedSearch(int index)
        {
            // Arrange
            var testData = testDataList.ElementAt(index);

            // Act
            var parameters = testData.SearchInput.ToParameters();

            // Assert
            Assert.That(parameters, Is.EqualTo(testData.ExpectedParameters));
        }
    }
}
