using static MorpionApp.UserInterface;

namespace MorpionApp {
  public class GameManager {
    private UserInterface _userInterface;

    public GameManager(UserInterface userInterface) {
      _userInterface = userInterface;
    }

    public void Start() {
      _userInterface.DisplayGameSelectionPrompt();
      while (true) {
        Game game = GetSelectedGame();
        if (game != null) {
          game.Start();
        }
        if(!_userInterface.PromptPlayAnotherGame())
          break;
      }
      _userInterface.DisplayExitMessage();
    }

    private Game GetSelectedGame() {
      switch (_userInterface.GetGameSelection()) {
        case GameSelection.Morpion:
          return new MorpionGame();
        case GameSelection.PuissanceQuatre:
          return new ConnectFourGame();
        default:
          return null;
      }
    }
  }
}