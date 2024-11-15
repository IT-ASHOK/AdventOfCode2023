
using System.Text.RegularExpressions;
using Day5;

//string allLines = File.ReadAllText($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day5\\TestFile.txt");
string allLines = File.ReadAllText($"D:\\AdventOFCode2023\\AdventOFCode2023\\Day5\\Input.txt");

SeedModel maps = CreateMaps(allLines);

List<long> locations = new List<long>();
foreach (var seed in maps.Seeds)
{
    var soil = GetMappedNumber(maps.Seed2SoilMap, seed);//maps.Seed2SoilMap[seed];
    var fert = GetMappedNumber(maps.Soil2FertilizerMap, soil);//maps.Soil2FertilizerMap[soil];
    var water = GetMappedNumber(maps.Fertilizer2Water, fert);
    var light = GetMappedNumber(maps.Water2Light, water);
    var temp = GetMappedNumber(maps.Light2Temp, light);
    var humidity = GetMappedNumber(maps.Temp2Humidity, temp);
    var location = GetMappedNumber(maps.Humidity2Location, humidity);

    locations.Add(location);
}

long GetMappedNumber(Dictionary<long,long> map, long key)
{
    long mappedValue = 0;
    if (map.ContainsKey(key))
    {
        mappedValue = map[key];
    }
    else
    {
        mappedValue = key;
    }

    return mappedValue;
}

Console.WriteLine($"smallest location: {locations.Min()}");

SeedModel CreateMaps(string allLines)
{
    SeedModel seedModel = new SeedModel();

    string[] allText = Regex.Split(allLines, GetRegularExpressionPattern("seeds:"));

    string []filter = Regex.Split(allText[2], GetRegularExpressionPattern(@"seed-to-soil map:"));

    seedModel.Seeds = GetNumericValues(filter[0]);

    filter = Regex.Split(filter[2], GetRegularExpressionPattern(@"soil-to-fertilizer map:"));
    string map = filter[0];
    List<long> numbers = GetNumericValues(map);
    seedModel.Seed2SoilMap = FillSourceAndDestination(numbers);

    filter = Regex.Split(filter[2], GetRegularExpressionPattern(@"fertilizer-to-water map:"));
    map = filter[0];
    numbers = GetNumericValues(map);
    seedModel.Soil2FertilizerMap = FillSourceAndDestination(numbers);

    filter = Regex.Split(filter[2], GetRegularExpressionPattern(@"water-to-light map:"));
    map = filter[0];
    numbers = GetNumericValues(map);
    seedModel.Fertilizer2Water = FillSourceAndDestination(numbers);

    filter = Regex.Split(filter[2], GetRegularExpressionPattern(@"light-to-temperature map:"));
    map = filter[0];
    numbers = GetNumericValues(map);
    seedModel.Water2Light = FillSourceAndDestination(numbers);


    filter = Regex.Split(filter[2], GetRegularExpressionPattern(@"temperature-to-humidity map:"));
    map = filter[0];
    numbers = GetNumericValues(map);
    seedModel.Light2Temp = FillSourceAndDestination(numbers);


    filter = Regex.Split(filter[2], GetRegularExpressionPattern(@"humidity-to-location map:"));
    map = filter[0];
    numbers = GetNumericValues(map);
    seedModel.Temp2Humidity = FillSourceAndDestination(numbers);

    map = filter[2];
    numbers = GetNumericValues(map);
    seedModel.Humidity2Location = FillSourceAndDestination(numbers);

    return seedModel;
}

string GetRegularExpressionPattern(string separator)
{
    return $"({Regex.Escape(separator)})";
}

List<long> GetNumericValues(string text)
{
    List<long> numbers = new List<long>();

    MatchCollection seedsMatchCollection = Regex.Matches(text, @"\d+");

    foreach (Match match in seedsMatchCollection)
    {
        numbers.Add(long.Parse(match.Value));
    }

    return numbers;
}

Dictionary<long, long>  FillSourceAndDestination(List<long> numbers)
{
    Dictionary<long,long> dictionary = new Dictionary<long,long>();

    for(int i=0;i<numbers.Count;)
    {
        long destination = numbers[i];
        long source = numbers[i+1];
        long range = numbers[i+2];

        for (long j = source; j < source + range; j++)
        {
            dictionary.Add(j, destination++);
        }
        i += 3;
    }

    long maxKey = dictionary.Keys.Max();
    for (long k = 0; k < maxKey; k++)
    {
        if (!dictionary.ContainsKey(k))
        {
            dictionary.Add(k, k);
        }
    }

    return dictionary;
}

IDictionary<T1, T2> SortDictionary<T1, T2>(IDictionary<T1, T2> dictionary)
{
    IDictionary<T1, T2> sortedDictionary = new Dictionary<T1, T2>();
    List<T1> sortedKeys = dictionary.Keys.ToList();
    sortedKeys.Sort();

    foreach (T1 key in sortedKeys)
    {
        sortedDictionary.Add(key, dictionary[key]);
    }

    return sortedDictionary;
}