using MorpionApp;

namespace MorpionAppTest
{
    public class PuissanceQuatreTest
    {
        [Fact]
        public void HorizontalVictoryTest()
        {
            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();

            puissanceQuatre.grille = new char[4, 7]
            {
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'X', 'X', 'X', 'X', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };

            Assert.True(puissanceQuatre.verifVictoire('X'));
        }

        [Fact]
        public void VerticalVictoryTest()
        {
            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();

            puissanceQuatre.grille = new char[4, 7]
            {
                { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
            };

            Assert.True(puissanceQuatre.verifVictoire('X'));
        }

        [Fact]
        public void DiagonalVictoryTest()
        {
            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();

            puissanceQuatre.grille = new char[4, 7]
            {
                { ' ', ' ', ' ', 'X', ' ', ' ', ' '},
                { ' ', ' ', 'X', ' ', ' ', ' ', ' '},
                { ' ', 'X', ' ', ' ', ' ', ' ', ' '},
                { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
            };

            Assert.True(puissanceQuatre.verifVictoire('X'));
        }

        [Fact]
        public void LosingTest()
        {
            PuissanceQuatre puissanceQuatre = new PuissanceQuatre();

            puissanceQuatre.grille = new char[4, 7]
            {
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
                { 'X', ' ', ' ', ' ', ' ', ' ', ' '},
            };

            Assert.False(puissanceQuatre.verifVictoire('X'));
        }
    }
}
