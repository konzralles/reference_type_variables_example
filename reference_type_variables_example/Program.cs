using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reference_type_variables_example
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namelist = {"Ali","Ayşe","Mehmet"};
            ref string name = ref namelist[0];
            name = ReturnIndex(namelist, "Ayşe");
            Console.WriteLine(name);

            int a = 0;
            Console.WriteLine(a);
            increase_ref(ref a);
            Console.WriteLine(a);
            sum_out(out a, ref a);
            Console.WriteLine(a);

            Console.ReadKey();
        }

        public static ref string ReturnIndex(string[] strings, string control)
        {
            ref string reference = ref strings[0];
            for(int i=0; i < strings.Length; i++)
            {
                if(strings[i] == control) reference = strings[i];
            }
            return ref reference;
        }

        //referans tipli parametreler değişkene değeri değil referansı gönderir.
        //dolayısı ile yapılan değişiklik adresi verilen değişkeni direk olarak etkiler.
        public static void increase_ref(ref int a)
        {
            a++;
        }

        //out parametreler o referansın değiştirileceğinin garantisi verir.
        //eğer out referanslı bir parametrenin değeri method içine değişmezse hata verecektir.
        public static void sum_out(out int o, ref int o_referance)
        {
            o = o_referance+15;
        }

        //in parametreler o referansın değiştirilmeyeceğinin garantisini verir.
        //eğer in referanslı bir parametrenin değeri method içinde değiştirilirse hata verecektir.
        public static void DoNothing(in int a)
        {
            int localint = a;
            localint++;
        }
    }
}
