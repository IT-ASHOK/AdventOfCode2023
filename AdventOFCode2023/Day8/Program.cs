
using Day8;

//List<string> allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day8\\TestFile.txt").ToList();
List<string> allLines = File.ReadAllLines($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day8\\Input.txt").ToList();


char[] directions = allLines[0].ToCharArray();
allLines.RemoveAt(0);
var nodes = GetAllNodes(allLines);

/*-- Part 1 of puzzle --*/
//int allPaths = PathFinder.GetAllPaths(directions, nodes);
//Console.WriteLine(allPaths);

/*-- part 2 of puzzle --*/
int allPaths = PathFinder2.GetAllPaths(directions, nodes);
Console.WriteLine(allPaths);

List<Node> GetAllNodes(List<string> allLines)
{

    List<Node> nodes = new List<Node>();
    foreach (var line in allLines)
    {
        string name = line.Split("=")[0].Trim();
        string left = line.Split("=")[1].Split(',')[0].Trim().Replace("(","").Trim();
        string right = line.Split("=")[1].Split(',')[1].Trim().Replace(")","").Trim();

        var node = new Node
        {
            LeftNode = left,
            RightNode = right,
            Name = name
        };

        nodes.Add(node);
    }
    return nodes;
}