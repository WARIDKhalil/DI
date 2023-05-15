
using DI.container;
using DI.ServiceRegistry;

ServiceRegistry services = new();

services.RegisterSingleton<IA, A1>();

Container container = (Container)services.BuildContainer();

var s1 = container.Resolve<IA>();
var s2 = container.Resolve<IA>();

s1?.print();
s2?.print();


// Test class/interface //
public interface IA
{
    void print();
}
public class A1 : IA
{
    public void print()
    {
        Console.WriteLine("A1 : " + this.GetHashCode());
    }
}

