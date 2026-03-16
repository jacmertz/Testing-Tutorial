using System.Security.Cryptography;

namespace TestProject
{
    public class FanUnitTests
    {
        //default values
        [Fact]
        public void FanShouldBeOffWithSpeed0Initially()
        {
            Fan f = new Fan();
            Assert.Equal(0, f.CurSpeed);
            Assert.False(f.FanOn);
        }

        //test that we are enforcing boundaries as needed

        //1) should only be able to set speed between 0-5
        // (if I try to set it to something outside that range, speed shouldn't change)

        [Theory]
        [InlineData(-50)]
        [InlineData(-1)]
        [InlineData(6)]
        [InlineData(75)]
        public void SpeedWontChangeIfSetOutside0to5(int speed)
        {
            Fan f = new Fan();
            f.CurSpeed = speed;

            Assert.Equal(0, f.CurSpeed);
        }

        //2) when speed is 0, fan is also off
        [Fact]
        public void SpeedTo0TurnsFanOff()
        {
            Fan f = new Fan();
            f.CurSpeed = 3;
            f.CurSpeed = 0;

            Assert.False(f.FanOn);
        }

        //3) when speed is 1-5, fan is also on
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Speed1to5TurnsFanOn(int speed)
        {
            Fan f = new Fan();
            f.CurSpeed = speed;

            Assert.True(f.FanOn);
        }

        //test properties/methods that are derived or changed by other properties

        [Theory]
        [InlineData(1, 200)]
        [InlineData(2, 250)]
        [InlineData(3, 300)]
        [InlineData(4, 350)]
        [InlineData(5, 400)]
        [InlineData(0, 0)]
        public void RPMIsCorrect(int speed, int expectedRPM)
        {
            Fan f = new Fan();
            f.CurSpeed = speed;

            Assert.Equal(expectedRPM, f.RPM);
        }
    }
}