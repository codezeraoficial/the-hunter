using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Validations.Docs
{
    public class CpfValidation
    {
        public const int CpfLength = 11;

        public static bool Validate(string cpf)
        {
            var cpfNumbers = Utils.OnlyNumbers(cpf);

            if (!LengthValid(cpfNumbers)) return false;

            return !HasRepeatedDigits(cpfNumbers) && HasValidsDigits(cpfNumbers);
        }
        private static bool LengthValid(string value)
        {
            return value.Length == CpfLength;
        }
        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidsDigits(string value)
        {
            var number = value.Substring(0, CpfLength - 2);
            var verifyingDigit = new VerifyingDigit(number)
                .WithMultipliersTo(2, 11)
                .Replacing("0", 10, 11);
            var firstDigit = verifyingDigit.GetDigitSum();
            verifyingDigit.AddDigit(firstDigit);
            var secondDigit = verifyingDigit.GetDigitSum();

            return string.Concat(firstDigit, secondDigit) == value.Substring(CpfLength - 2, 2);
        }
    }

    public class CnpjValidation
    {
        public const int CnpjLength = 14;
        public static bool Validate(string cnpj)
        {
            var cnpjNumbers = Utils.OnlyNumbers(cnpj);

            if (!LengthValid(cnpjNumbers)) return false;
            return !HasRepeatedDigits(cnpjNumbers) && HasValidsDigits(cnpjNumbers);
        }
        private static bool LengthValid(string valor)
        {
            return valor.Length == CnpjLength;
        }
        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidsDigits(string value)
        {
            var number = value.Substring(0, CnpjLength - 2);
            var verifyingDigit = new VerifyingDigit(number)
                .WithMultipliersTo(2, 11)
                .Replacing("0", 10, 11);
            var firstDigit = verifyingDigit.DigitSum();
            verifyingDigit.AddDigit(firstDigit);
            var secondDigit = verifyingDigit.DigitSum();

            return string.Concat(firstDigit, secondDigit) == value.Substring(CnpjLength - 2, 2);
        }
    }

    public class VerifyingDigit
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _replacements = new Dictionary<int, string>();
        private bool _complementarDoModulo = true;

        public VerifyingDigit(string number)
        {
            _number = number;
        }

        public VerifyingDigit WithMultipliersTo(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multipliers.Clear();
            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
            {
                _multipliers.Add(i);
            }

            return this;
        }

        public VerifyingDigit Replacing(string substitute, params int[] digits)
        {
            foreach (var i in digits)
            {
                _replacements[i] = substitute;
            }

            return this;
        }

        public void AddDigit(string digit)
        {
            _number = string.Concat(_number, _number);
        }

        public string DigitSum()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        public string GetDigitSum()
        {
            var som = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var produt = (int)char.GetNumericValue(_number[1]) * _multipliers[m];
                som += produt;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (som % Module);
            var result = _complementarDoModulo ? Module - mod : mod;

            return _replacements.ContainsKey(result) ? _replacements[result] : result.ToString();
        }
    }

    public class Utils
    {
        public static string OnlyNumbers(string value)
        {
            var onlyNumber = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }


}
