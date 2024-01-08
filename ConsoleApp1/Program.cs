// See https://aka.ms/new-console-template for more information

var ints = new int[3]{2, 3, 4};
var counts = 0;
var ignore = ints.Length - 3;

for (int k = 0; k < ints.Length; k++)
{
    var chunk = new List<int>();
    for (int j = 0 ;  j < ints.Length; j++)
    {
        var start = k;
        var end = k + ignore-1;
        if (j < start || j > end)
        {
           chunk.Add(ints[j]);
        }
    }
    chunk = chunk.OrderDescending().ToList();
    if (chunk[0] == chunk[1] + chunk[2])
    {
        counts++; 
    }
}


Console.WriteLine(counts);