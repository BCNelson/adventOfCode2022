
class Day1 {
    static void Main(string[] args) {
        StreamReader file = new StreamReader(args[0]);
        int Largest = 0;
        int CurrentTotal = 0;
        while (!file.EndOfStream) {
            string? line = file.ReadLine();
            if (line == null) {
                Console.WriteLine("Error reading file");
                continue;
            }
            if (line.Length == 0){
                if (CurrentTotal > Largest)
                    Largest = CurrentTotal;
                CurrentTotal = 0;
                continue;
            }
            // do something with line
            CurrentTotal += int.Parse(line);
        }
        if (CurrentTotal > Largest)
            Largest = CurrentTotal;
        Console.WriteLine(Largest);
    }
}