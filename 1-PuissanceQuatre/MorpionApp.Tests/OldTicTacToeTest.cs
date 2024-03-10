using MorpionApp;

namespace MorpionAppTest;

public class MorpionTest
{
    [Fact]
    public void HorizontalVictoryTest()
    {
        Morpion morpion = new Morpion();

        morpion.grille = new char[3, 3]
        {
            { ' ', ' ', ' '},
            { 'X', 'X', 'X'},
            { ' ', ' ', ' '},
        };

        Assert.True(morpion.verifVictoire('X'));
    }

    [Fact]
    public void VerticalVictoryTest()
    {
        Morpion morpion = new Morpion();

        morpion.grille = new char[3, 3]
        {
            { ' ', ' ', 'X'},
            { ' ', ' ', 'X'},
            { ' ', ' ', 'X'},
        };

        Assert.True(morpion.verifVictoire('X'));
    }

    [Fact]
    public void DiagonalVictoryTest()
    {
        Morpion morpion = new Morpion();

        morpion.grille = new char[3, 3]
        {
            { ' ', ' ', 'X'},
            { ' ', 'X', ' '},
            { 'X', ' ', ' '},
        };

        Assert.True(morpion.verifVictoire('X'));
    }

    [Fact]
    public void LosingTest()
    {
        Morpion morpion = new Morpion();

        morpion.grille = new char[3, 3]
        {
            { ' ', ' ', ' '},
            { 'X', ' ', ' '},
            { 'X', ' ', ' '},
        };

        Assert.False(morpion.verifVictoire('X'));
    }
}