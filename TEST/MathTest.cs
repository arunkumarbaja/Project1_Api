using BBL;

namespace TEST
{
    public class MathTest
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
         // Arrange 
         MyMath myMath = new MyMath();
            int x = 5; int y = 10;

            // Act
            int result = myMath.Add(x, y);

            // Assert
            Assert.Equal(15, result);
        }
    }
}