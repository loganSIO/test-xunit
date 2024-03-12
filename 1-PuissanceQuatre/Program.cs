namespace MorpionApp {
  public class Program {
    static void Main(string[] args) {
        GameManager gameManager = new GameManager(new UserInterface());
        gameManager.Start();
    }
  }
}