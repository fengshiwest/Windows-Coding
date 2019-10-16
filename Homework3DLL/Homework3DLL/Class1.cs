using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3DLL
{
    public class Class1
    {
        //阶乘
        public int factorial(int a)
        {
            int res = 1;

            while(a > 1)
            {
                res = res * a;
                a--;
            }
            return res;

        }

        //斐波拉契数列
        public int fibonacci(int b)
        {
            if(b == 1 || b == 2)
            {
                return 1;
            } 
            return fibonacci(b - 1) + fibonacci(b - 2);
            
        }
    }
}
