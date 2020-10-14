using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Customer
    {
        public string Name;
        public string State;
        public string Phone;

        public Customer(string n, string s, string p)
        {
            Name = n;
            State = s;
            Phone = p;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var customers = new List<Customer>();
            customers.Add(new Customer("Chandler", "OR", "555-555-5555"));
            customers.Add(new Customer("Monica", "CO", "555-666-6666"));
            customers.Add(new Customer("Joey", "CO", "555-777-7777"));
            customers.Add(new Customer("Ross", "NY", "555-000-0000"));
            customers.Add(new Customer("Phoebe", "NY", "555-111-1111"));
            customers.Add(new Customer("Rachel", "NJ", "555-222-2222"));

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string[] numNames = { "nulla", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };

            //5 alatti számok kiíratása
            var otAlatt = from szam in numbers
                          where szam < 5
                          orderby szam descending
                          select szam;
            //Azonnali kiértékelés átalakítással
            //var ujTomb = otAlatt.ToList();
            foreach (var o in otAlatt)
            {
                Console.Write(o+" ");
            }
            // Kik laknak "CO" államban?
            Console.WriteLine();
            var coState = from co in customers
                          where co.State == "CO"
                          orderby co.Name
                          select co;
            Console.WriteLine("'CO' államban élők");
            foreach (var c in coState)
            {
                Console.WriteLine($"{c.Name,6} -- {c.State}");
            }
            Console.WriteLine();
            // számok értéke növelve 2-vel
            var kettovel = from n in numbers
                           select n + 2;
            int a = 0;
            var kettoTomb = kettovel.ToArray();
            for (int i = 0; i < kettoTomb.Length; i++)
            {
                Console.WriteLine($"{numbers[i]}-->{kettoTomb[i]}");
            }
            Console.WriteLine();
            foreach (var k in kettovel)
            {
                Console.WriteLine($"{numbers[a++]}-->{k}");
            }
            // A Customer-ből csak név és telefonszám kell --> anonim objektum típus felhasználása
            var namePhone = from c in customers
                            orderby c.Name
                            select new { nev = c.Name, tel = c.Phone };
            //Anonim objektumot a "new" kulcs(szóval) adunk meg
            Console.WriteLine();
            foreach (var i in namePhone)
            {
                Console.WriteLine($"{i.nev,8} {i.tel}");
            }
            // számokból --> szöveg
            Console.WriteLine();
            int[] tomb = { 2, 4, 0, 1, 9, 6 };
            var szoveges = from u in tomb
                           select numNames[u];
            foreach (var i in szoveges)
            {
                Console.Write(i+" ");
            }
            // csoportosítás 
            Console.WriteLine();
            var nevek = from c in customers
                        select c.Name;
            var nevLista = nevek.ToList();
            var kezdoBetu = from n in nevLista
                            group n by n[0] into tempNevek
                            select tempNevek;
           
            Console.ReadLine();
        }

    }

}
