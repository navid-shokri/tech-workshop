using System.Diagnostics.SymbolStore;
using MessagePack;

namespace NRule;
[Union(0,typeof(Child))]
[MessagePackObject]
public class Parent
{
    [Key(0)]
    public string Name { get; set; }
    [Key(1)]
    public string Familt { get; set; }
}