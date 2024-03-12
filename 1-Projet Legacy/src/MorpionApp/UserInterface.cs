namespace MorpionApp {
  public class UserInterface {

    public void DisplayGameSelectionPrompt(){
      Console.WriteLine("Jouer à quel jeu ? Appuyez sur [X] pour le Morpion et sur [P] pour le Puissance 4.");
    }

    public GameSelection GetGameSelection(){
      switch (Console.ReadKey(true).Key) {
        case ConsoleKey.X:
          return GameSelection.Morpion;
        case ConsoleKey.P:
          return GameSelection.PuissanceQuatre;
        default:
          return GameSelection.None;
      }
    }

    public bool PromptPlayAnotherGame(){
      Console.WriteLine("Jouer à un autre jeu ? Appuyez sur [R] pour changer de jeu. Appuyez sur [Echap] pour quitter.");
      switch (Console.ReadKey(true).Key) {
        case ConsoleKey.R:
          return true;
        case ConsoleKey.Escape:
          return false;
        default:
          return PromptPlayAnotherGame();
      }
    }

    public void DisplayExitMessage(){
      Console.WriteLine("Merci d'avoir joué !");
    }

    public enum GameSelection {
      Morpion,
      PuissanceQuatre,
      None
    }
  }
}