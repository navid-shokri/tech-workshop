using MessagePack;

namespace NRule;
[MessagePackObject]
public class Child : Parent
{
    [Key(0)]
    public string Hubby { get; set; }
}