
class Day2 {
    enum Choice {
        rock,
        paper,
        scissors,
        unknown
    }

    enum Outcome {
        win,
        lose,
        draw
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

    static Outcome ConvertOutcome(string outcome) {
        if (outcome == "Z") {
            return Outcome.win;
        } else if (outcome == "X") {
            return Outcome.lose;
        } else if (outcome == "Y") {
            return Outcome.draw;
        }
        throw new Exception("Invalid outcome");
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
    static int ScoreMyChoice(Choice MyChoice) {
        switch (MyChoice) {
                case Choice.rock:
                    return 1;
                case Choice.paper:
                    return 2;
                case Choice.scissors:
                    return 3;
                default:
                    throw new Exception("Invalid choice");
            }
    }

    static Choice Part2Choice(Choice OpponentChoice, Outcome outcome) {
        if (outcome == Outcome.win) {
            if (OpponentChoice == Choice.rock) {
                return Choice.paper;
            } else if (OpponentChoice == Choice.paper) {
                return Choice.scissors;
            } else if (OpponentChoice == Choice.scissors) {
                return Choice.rock;
            }
        } else if (outcome == Outcome.lose) {
            if (OpponentChoice == Choice.rock) {
                return Choice.scissors;
            } else if (OpponentChoice == Choice.paper) {
                return Choice.rock;
            } else if (OpponentChoice == Choice.scissors) {
                return Choice.paper;
            }
        } else if (outcome == Outcome.draw) {
            return OpponentChoice;
        }
        throw new Exception("Invalid choice");
    }

    static void Main(string[] args) {
        StreamReader file = new StreamReader(args[0]);
        int ScorePart1 = 0;
        int ScorePart2 = 0;
        while (!file.EndOfStream) {
            string? line = file.ReadLine();
            if (line == null) {
                Console.WriteLine("Error reading file");
                continue;
            }
            string[] choices = line.Split(' ');
            Choice OpponentChoice = ConvertChoice(choices[0]);
            Choice MyChoicePart1 = ConvertChoice(choices[1]);
            ScorePart1 += ScoreMatch(OpponentChoice, MyChoicePart1);
            ScorePart1 += ScoreMyChoice(MyChoicePart1);
            Outcome outcome = ConvertOutcome(choices[1]);
            Choice MyChoicePart2 = Part2Choice(OpponentChoice, outcome);
            ScorePart2 += ScoreMatch(OpponentChoice, MyChoicePart2);
            ScorePart2 += ScoreMyChoice(MyChoicePart2);
        }
        Console.WriteLine("Part 1:" + ScorePart1);
        Console.WriteLine("Part 2:" + ScorePart2);
        file.Close();
    }
}