namespace MapsterIntro;

public abstract class FilterMiddleWare
{
    public string Filter(int num) =>
        num switch
        {
            
            _ => AdditionalActions(num)
        };

    protected abstract string AdditionalActions(int num);
}