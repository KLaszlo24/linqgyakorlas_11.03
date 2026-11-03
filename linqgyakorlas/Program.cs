using System.Globalization;

namespace linqgyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Diak> diakok = File.ReadAllLines("diakok.csv")
                .Skip(1)
                .Select(sor =>
                {
                string[] adatok = sor.Split(';');

                return new Diak(
                    adatok[0],
                    int.Parse(adatok[1]),
                    adatok[2],
                    double.Parse(adatok[3], CultureInfo.GetCultureInfo("hu-HU"))
                    );
                })
                .ToList();

            var eredmeny = diakok.Where(diak => diak.Eletkor >= 18);
            var nevek = diakok.Select(diak => diak.Nev);

            foreach (Diak diak in eredmeny)
            {
                Console.WriteLine($"{diak.Nev} - {diak.Eletkor} éves");
            }

            foreach (string nev in nevek)
            {
                Console.WriteLine(nev);
            }

            foreach (var diak in diakok)
            {
                Console.WriteLine($"{diak.Nev}");
            }

        }
    }
}
