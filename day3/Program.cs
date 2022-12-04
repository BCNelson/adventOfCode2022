
class Day3 {

    static int CharToPriority(char c) {
        if ((int)c >= 97) {
            return (int)c - 96;
        } else {
            return (int)c - 67 + 29;
        }
    }
    static void Main(string[] args) {
        StreamReader file = new StreamReader(args[0]);
        List<HashSet<char>> list = new List<HashSet<char>>();
        List<char> deuplcateItems = new List<char>();
        while (!file.EndOfStream) {
            string? line = file.ReadLine();
            if (line == null) {
                Console.WriteLine("Error reading file");
                continue;
            }
            // do something with line
            
            HashSet<char> fullSet = new HashSet<char>();
            HashSet<char> firstHalf = new HashSet<char>();
            HashSet<char> secondHalf = new HashSet<char>();
            for (int i = 0; i < line.Length; i++) {
                fullSet.Add(line[i]);
                if (i < line.Length / 2) {
                    firstHalf.Add(line[i]);
                } else {
                    secondHalf.Add(line[i]);
                }
            }
            list.Add(fullSet);
            firstHalf.IntersectWith(secondHalf);
            deuplcateItems.AddRange(firstHalf);
        }
        file.Close();

        int sum = 0;
        for(int i = 0; i < list.Count; i+=3) {
            list[i].IntersectWith(list[i+1]);
            list[i].IntersectWith(list[i+2]);
            if (list[i].Count != 1) {
                throw new Exception("Error" + i+ " " + list[i].Count);
            }
            sum += CharToPriority(list[i].First());
        }

        int total = 0;
        foreach (char item in deuplcateItems) {
            total += CharToPriority(item);
        }
        Console.WriteLine("Part 1: " + total);
        Console.WriteLine("Part 2: " + sum);
    }
}
