 public class ValidationHelper
    {
        public static bool IsValidTaxNumber(string taxNumber)
        {
            long tResult;
            if (string.IsNullOrEmpty(taxNumber) || taxNumber.Length != 10 || !long.TryParse(taxNumber, out tResult))
                return false;
            var array = taxNumber.Select(t => Convert.ToInt16(t.ToString())).ToArray();
            short lastOne = 0;
            var sum = 0;
            for (var i = 1; i <= array.Length; i++)
            {
                if (i != array.Length)
                {
                    var a = (array[i - 1] + (10 - i)) % 10;
                    int b = (int)(a * (Math.Pow(2, (10 - i)))) % 9;
                    if (a != 0 && b == 0)
                        sum += 9;
                    else
                        sum += b;
                }
                else
                    lastOne = array[i - 1];
            }
            if (sum % 10 == 0)
                sum = 0;
            else
                sum = (10 - (sum % 10));
            return sum == lastOne;
        }
        public static bool IsValidIdentityNumber(string identityNumber)
        {
            if (!string.IsNullOrEmpty(identityNumber) && identityNumber.Length == 11 && identityNumber != "11111111111" &&
                identityNumber != "00000000000")
            {
                var tcNo = long.Parse(identityNumber);

                var atcno = tcNo / 100;
                var btcno = tcNo / 100;

                var c1 = atcno % 10;
                atcno = atcno / 10;
                var c2 = atcno % 10;
                atcno = atcno / 10;
                var c3 = atcno % 10;
                atcno = atcno / 10;
                var c4 = atcno % 10;
                atcno = atcno / 10;
                var c5 = atcno % 10;
                atcno = atcno / 10;
                var c6 = atcno % 10;
                atcno = atcno / 10;
                var c7 = atcno % 10;
                atcno = atcno / 10;
                var c8 = atcno % 10;
                atcno = atcno / 10;
                var c9 = atcno % 10;
                var q1 = ((10 - ((((c1 + c3 + c5 + c7 + c9) * 3) + (c2 + c4 + c6 + c8)) % 10)) % 10);
                var q2 = ((10 - (((((c2 + c4 + c6 + c8) + q1) * 3) + (c1 + c3 + c5 + c7 + c9)) % 10)) % 10);
                return ((btcno * 100) + (q1 * 10) + q2 == tcNo);
            }
            return false;
        }

        public static bool IsValidTaxNumber(string taxNumber)
        {
            long tResult;
            if (string.IsNullOrEmpty(taxNumber) || taxNumber.Length != 10 || !long.TryParse(taxNumber, out tResult))
                return false;

            var array = taxNumber.Select(t => Convert.ToInt16(t.ToString())).ToArray();

            short lastOne = 0;
            var sum = 0;
            for (var i = 1; i <= array.Length; i++)
            {
                if (i != array.Length)
                {
                    var a = (array[i - 1] + (10 - i)) % 10;
                    int b = (int)(a * (Math.Pow(2, (10 - i)))) % 9;
                    if (a != 0 && b == 0)
                        sum += 9;
                    else
                        sum += b;
                }
                else
                    lastOne = array[i - 1];
            }

            if (sum % 10 == 0)
                sum = 0;
            else
                sum = (10 - (sum % 10));

            return sum == lastOne;

        }

        public static bool IsValidPostCode(string postCode)
        {
            if (string.IsNullOrEmpty(postCode))
                return false;
            if (postCode.Length < 5)
                return false;
            long result;
            return long.TryParse(postCode, out result);
        }

        public static bool IsValidCreditCard(string creditCardNumber)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            var sumOfDigits = creditCardNumber.Where(e => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum(e => e / 10 + e % 10);

            return sumOfDigits % 10 == 0;
        }
    }