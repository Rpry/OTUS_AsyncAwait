using System.Xml;

namespace Otus.AsyncAwait
{
    public class YieldControlProgram
    {
        public void Example1_Method1()
        {
            var res1 = Example1_Method2();
            Console.WriteLine(res1);
            
            var res2 = Example1_Method2();
            Console.WriteLine(res2);
        }
        
        public int Example1_Method2()
        {
            return 1;
        }
        
        public void Example2_Method1()
        {
            foreach (var item in Example2_Method2())
            {
                Console.WriteLine(item);    
            }
        }
        
        public IEnumerable<int> Example2_Method2()
        {
            yield return 1;
            yield return 2;
        }
    }
}