using RadioBrowser.Net.Extensions;

namespace RadioBrowser.Net.Tests.Extensions {
    public class EnumerableExtensionTests {

        [Test]
        public void ShouldShuffleTheGivenListAsExpected() {
            // Arrange
            var numberOfElements = 10;
            var list = Enumerable.Range(0, numberOfElements);

            // Act
            var shuffledList = list.Shuffle();

            // Assert
            Assert.That(list.Count, Is.EqualTo(shuffledList.Count()));
            Assert.That(list, Is.Not.EqualTo(shuffledList));
        }

        [Test]
        public void ShouldPickRandomElementAsExpected() {
            // Arrange
            var numberOfElements = 1000;
            var list = Enumerable.Range(0, numberOfElements);

            // Act
            var randomElementOne = list.PickRandom();
            var randomElementTwo = list.PickRandom();

            // Assert
            Assert.That(randomElementOne, Is.Not.EqualTo(randomElementTwo));
        }

        [Test]
        public void ShouldPickRandomElementsAsExpected() {
            // Arrange
            var numberOfElements = 1000;
            var list = Enumerable.Range(0, numberOfElements);

            // Act
            var randomElementsOne = list.PickRandom(2);
            var randomElementsTwo = list.PickRandom(2);

            // Assert
            Assert.That(randomElementsOne, Is.Not.EqualTo(randomElementsTwo));
        }
    }
}
