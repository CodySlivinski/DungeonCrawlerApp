using DungeonLibrary;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Weapon wep = new Weapon("", 8, 10, 5, WeaponType.Shoe);
            Player player = new Player("", 5, 6, 15, Race.Knitter, wep);
            int expected = 6;
            int actual = player.CalcBlock();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            Weapon wep = new Weapon("", 8, 10, 5, WeaponType.Shoe);
            Player player = new Player("", 5, 6, 15, Race.Knitter, wep);
            
            int actual = player.CalcDamage();

            Assert.InRange(actual, 8, 10);
        }
    }
}