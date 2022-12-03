
class Day1 {
    static void Main(string[] args) {
        StreamReader file = new StreamReader(args[0]);
        List<int> counts = new List<int>();
        int CurrentTotal = 0;
        while (!file.EndOfStream) {
            string? line = file.ReadLine();
            if (line == null) {
                Console.WriteLine("Error reading file");
                continue;
            }
            if (line.Length == 0){
                counts.Add(CurrentTotal);
                CurrentTotal = 0;
                continue;
            }
            // do something with line
            CurrentTotal += int.Parse(line);
        }
        counts.Prepend(CurrentTotal);
        counts.Sort();
        counts.Reverse();
        Console.WriteLine("Part 1: " + counts[0]);
        Console.WriteLine("Part 2: " + (counts[0] + counts[1] + counts[2]));
    }
}