using System.ComponentModel;
using System.Runtime.Serialization;

namespace MapsterIntro;

public enum Weather
{
    Sunny,
    [EnumMember(Value = "Abri")]
    Cloudy, 
    [EnumMember(Value = "Barani")]
    Rainy,
    [EnumMember(Value = "Barfi")]
    Snowy,
    [EnumMember(Value = "Meh Alood")]
    Foggy
}