namespace ClassLibrary1
{

    public abstract class Class1<T> 
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }

    public class Class2 : Class1<string>
    {
    }
    
    public class Class3 : Class1<int>
    {
    }

    public class Arg
    {
        public int Cost { get; set; }
    }

    public class Class4 : Class1<Arg>
    {
    }

    public class Factory
    {
        public T Create<T, A>(int x) where T : Class1<A>
        {
             o =  x switch
            {
                1 => new Class2(),
                2 => new Class3(),
                3 => new Class4()
            };
        }
    }

}