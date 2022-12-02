
class Day2 {
    enum Choice {
        rock,
        paper,
        scissors,
        unknown
    }

    static Choice ConvertChoice(string choice) {

        if (choice == "A" || choice == "X") {
            return Choice.rock;
        } else if (choice == "B" || choice == "Y") {
            return Choice.paper;
        } else if (choice == "C" || choice == "Z") {
            return Choice.scissors;
        }
        throw new Exception("Invalid choice");
    }
    static int ScoreMatch(Choice OpponentChoice, Choice MyChoice) {
        if (OpponentChoice == MyChoice) {
            return 3; // Draw
        } else if (OpponentChoice == Choice.rock && MyChoice == Choice.paper) {
            return 6; // Win
        } else if (OpponentChoice == Choice.paper && MyChoice == Choice.scissors) {
            return 6; // Win
        } else if (OpponentChoice == Choice.scissors && MyChoice == Choice.rock) {
            return 6; // Win
        } else {
            return 0; // Lose
        }
    }
    static void Main(string[] args) {
        StreamReader file = new StreamReader(args[0]);
        int Score = 0;
        while (!file.EndOfStream) {
            string? line = file.ReadLine();
            if (line == null) {
                Console.WriteLine("Error reading file");
                continue;
            }
            string[] choices = line.Split(' ');
            Choice OpponentChoice = ConvertChoice(choices[0]);
            Choice MyChoice = ConvertChoice(choices[1]);
            Score += ScoreMatch(OpponentChoice, MyChoice);
            switch (MyChoice) {
                case Choice.rock:
                    Score += 1;
                    break;
                case Choice.paper:
                    Score += 2;
                    break;
                case Choice.scissors:
                    Score += 3;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        Console.WriteLine(Score);
    }
}