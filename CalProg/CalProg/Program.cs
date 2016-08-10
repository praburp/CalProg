using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalProg
{
    public class MathEvaluator
    {

        static void Main(string[] args)
        {

            double i;
            double number;
            int[] array = new int[2];
            int[] array1 = new int[2];
            int h;
            int n, p = 0, m = 0;
            int j, k = 0;
            string z, t;
            Console.WriteLine("Enter the values:");

            string s = Console.ReadLine();

            for (j = 0; j < s.Length; j++)
            {
                string c = s.Substring(j, 1);
                if (c.Equals("s"))
                {
                    array[m] = j;
                    m++;
                }
                if (c.Equals(")"))
                {

                    array[m] = j + 1;
                    string e = s.Substring(array[0], array[1] - array[0]);
                    for (n = 0; n < e.Length; n++)
                    {
                        string d = e.Substring(n, 1);
                        if (d.Equals("("))
                        {
                            array1[p] = n + 1;
                            p++;
                        }
                        if (d.Equals(")"))
                        {

                            array1[p] = n;

                        }


                        //i=Math.Sqrt[number];

                    }
                    string f = e.Substring(array1[0], array1[1] - array1[0]);
                    Double.TryParse(f, out number);
                    //Console.WriteLine(number);
                    i = Math.Sqrt(number);
                    t = i.ToString();
                    s = s.Replace(e, t);
                  //  Console.WriteLine(s);
                    //Console.Read();

                }

            }

            for (j = 0; j < s.Length; j++)
            {
                String b = s.Substring(j, 1);

                if (b.Equals("+") || b.Equals("-") || b.Equals("*") || b.Equals("^") || b.Equals("/") || b.Equals("1") || b.Equals("2") || b.Equals("3") || b.Equals("4") || b.Equals("5") || b.Equals("6") || b.Equals("7") || b.Equals("8") || b.Equals("9") || b.Equals("0"))
                {

                    k = 0;
                }
                else
                {
                    k = 1;
                    break;
                }
            }

            if (k == 0)
            {
                i = Evaluate(s);
                Console.WriteLine(i);
                Console.Read();
            }
            if (k == 1)
            {

                Console.WriteLine("invalid input");
                Console.Read();
            }



            Console.Read();

        }


        public static double Evaluate(String input)
        {
            String expr = "(" + input + ")";
            Stack<String> ops = new Stack<String>();
            Stack<Double> vals = new Stack<Double>();

            for (int i = 0; i < expr.Length; i++)
            {
                String s = expr.Substring(i, 1);
                if (s.Equals("(")) { }
                else if (s.Equals("^")) ops.Push(s);
                else if (s.Equals("/")) ops.Push(s);
                else if (s.Equals("*")) ops.Push(s);
                else if (s.Equals("+")) ops.Push(s);
                else if (s.Equals("-")) ops.Push(s);
                else if (s.Equals(")"))
                {
                    int count = ops.Count;
                    while (count > 0)
                    {
                        String op = ops.Pop();
                        double v = vals.Pop();
                        if (op.Equals("+")) v = vals.Pop() + v;
                        else if (op.Equals("-")) v = vals.Pop() - v;
                        else if (op.Equals("*")) v = vals.Pop() * v;
                        else if (op.Equals("/")) v = vals.Pop() / v;
                        //else if (op.Equals("a")) v = Math.Sqrt(v);
                        else if (op.Equals("^")) v = Math.Pow(v, vals.Pop());
                        vals.Push(v);

                        count--;
                    }
                }
                else vals.Push(Double.Parse(s));
            }
            return vals.Pop();
        }


    }
}



