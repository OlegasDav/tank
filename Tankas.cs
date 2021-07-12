using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture06._1_Tankas
{
    public class Tankas
    {
        private string _pozicija;
        private int _ejimuSk;
        private int _suviuSk;
        private int _siaurePietus;
        private int _vakaraiRytai;
        private SuviuKryptys _suvioKr = new SuviuKryptys();
        private Kryptys _kryptis = Kryptys.Siaure;
        private List<string> _suvioStatistika = new List<string>();

        private readonly int _maxSuviu;
        private readonly int _maxEjimu;

        public Tankas(int maxSuviu, int maxEjimu)
        {
            _maxSuviu = maxSuviu;
            _maxEjimu = maxEjimu;
        }

        public void Pozicija()
        {
            if (_siaurePietus > 0 && _vakaraiRytai == 0)
            {
                _pozicija = $"{Kryptys.Siaure}: {_siaurePietus}";
            }
            else if (_siaurePietus < 0 && _vakaraiRytai == 0)
            {
                _pozicija = $"{Kryptys.Pietus}: {Math.Abs(_siaurePietus)}";
            }
            else if (_vakaraiRytai > 0 && _siaurePietus == 0)
            {
                _pozicija = $"{Kryptys.Rytai}: {_vakaraiRytai}";
            }
            else if (_vakaraiRytai < 0 && _siaurePietus == 0)
            {
                _pozicija = $"{Kryptys.Vakarai}: {Math.Abs(_vakaraiRytai)}";
            }
            else if (_siaurePietus > 0 && _vakaraiRytai > 0)
            {
                _pozicija = $"{Kryptys.Siaure}: {_siaurePietus}, {Kryptys.Rytai}: {_vakaraiRytai}";
            }
            else if (_siaurePietus > 0 && _vakaraiRytai < 0)
            {
                _pozicija = $"{Kryptys.Siaure}: {_siaurePietus}, {Kryptys.Vakarai}: {Math.Abs(_vakaraiRytai)}";
            }
            else if (_siaurePietus < 0 && _vakaraiRytai > 0)
            {
                _pozicija = $"{Kryptys.Pietus}: {Math.Abs(_siaurePietus)}, {Kryptys.Rytai}: {_vakaraiRytai}";
            }
            else if (_siaurePietus < 0 && _vakaraiRytai < 0)
            {
                _pozicija = $"{Kryptys.Pietus}: {Math.Abs(_siaurePietus)}, {Kryptys.Vakarai}: {Math.Abs(_vakaraiRytai)}";
            }
            else
            {
                Console.WriteLine($"Tankas stovi pradineje pozicijoje.");
            }
        }

        public void Pirmyn()
        {
            if (_ejimuSk < _maxEjimu)
            {
                Console.WriteLine($"Atsargiai tankas vaziuoja pirmyn!");

                switch (_kryptis)
                {
                    case Kryptys.Siaure:
                        _siaurePietus++;
                        break;
                    case Kryptys.Vakarai:
                        _vakaraiRytai--;
                        break;
                    case Kryptys.Pietus:
                        _siaurePietus--;
                        break;
                    case Kryptys.Rytai:
                        _vakaraiRytai++;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Baigesi degalai!!!");
            }

            _ejimuSk++;
        }

        public void Atgal()
        {
            if (_ejimuSk < _maxEjimu)
            {
                Console.WriteLine($"Atsargiai tankas vaziuoja atbulomis!");

                switch (_kryptis)
                {
                    case Kryptys.Siaure:
                        _siaurePietus--;
                        break;
                    case Kryptys.Vakarai:
                        _vakaraiRytai++;
                        break;
                    case Kryptys.Pietus:
                        _siaurePietus++;
                        break;
                    case Kryptys.Rytai:
                        _vakaraiRytai--;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Baigesi degalai!!!");
            }

            _ejimuSk++;
        }

        public void Kairen()
        {
            switch (_kryptis)
            {
                case Kryptys.Siaure:
                    _kryptis = Kryptys.Vakarai;
                    break;
                case Kryptys.Vakarai:
                    _kryptis = Kryptys.Pietus;
                    break;
                case Kryptys.Pietus:
                    _kryptis = Kryptys.Rytai;
                    break;
                case Kryptys.Rytai:
                    _kryptis = Kryptys.Siaure;
                    break;
            }
        }

        public void Desinen()
        {
            switch (_kryptis)
            {
                case Kryptys.Siaure:
                    _kryptis = Kryptys.Rytai;
                    break;
                case Kryptys.Rytai:
                    _kryptis = Kryptys.Pietus;
                    break;
                case Kryptys.Pietus:
                    _kryptis = Kryptys.Vakarai;
                    break;
                case Kryptys.Vakarai:
                    _kryptis = Kryptys.Siaure;
                    break;
            }
        }

        public void Suvis()
        {
            if (_suviuSk < _maxSuviu)
            {
                Console.WriteLine($"Visiems sleptis, tankas isove! BOOM!");

                _suviuSk++;

                Pozicija();

                switch (_kryptis)
                {
                    case Kryptys.Siaure:
                        _suvioKr.Siaure++;
                        break;
                    case Kryptys.Rytai:
                        _suvioKr.Rytai++;
                        break;
                    case Kryptys.Pietus:
                        _suvioKr.Pietus++;
                        break;
                    case Kryptys.Vakarai:
                        _suvioKr.Vakarai++;
                        break;
                }

                var suvioinfo = $"Tanko suvis nr {_suviuSk}: kryptis = {_kryptis}, pozicija ({_pozicija}).";

                _suvioStatistika.Add(suvioinfo);
    }
            else
            {
                Console.WriteLine("Nebeliko saudmenu!");
            }
            
        }

        public void Info()
        {
            //ATSPAUSDINTI KOORDINATES
            Pozicija();
            Console.WriteLine($"Tanko pozicija: {_pozicija}.");

            //ATSPAUSDINTI KRYPTI
            Console.WriteLine($"Tanko kriptis: {_kryptis}");

            //ATSPAUSDINTI SUVIU SKAICIU
            if (_suviuSk > 0)
            {
                Console.WriteLine($"Tanko issauti soviniai: {_suviuSk}.");
            }
            
            //ATSPAUSDINTI SUVIU KRYPTI
            if (_suvioKr.Siaure > 0)
            {
                Console.WriteLine($"Tanko sauti kartai i siaure: {_suvioKr.Siaure}");
            }
            if (_suvioKr.Pietus > 0)
            {
                Console.WriteLine($"Tanko sauti kartai i Pietus: {_suvioKr.Pietus}");
            }
            if (_suvioKr.Rytai > 0)
            {
                Console.WriteLine($"Tanko sauti kartai i rytus: {_suvioKr.Rytai}");
            }
            if (_suvioKr.Vakarai > 0)
            {
                Console.WriteLine($"Tanko sauti kartai i vakarus: {_suvioKr.Vakarai}");
            }

            for (var i = 0; i < _suvioStatistika.Count; i++)
            {
                Console.WriteLine(_suvioStatistika[i]);
            }

        }
    }
}
