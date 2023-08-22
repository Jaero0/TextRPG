using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace Utility
{
    class KoreanCount
    {
        public static int CountKoreanCharacters(string input) //한글 카운트 하기
        {
            int koreanCount = 0;
            foreach (char c in input)
            {
                // 한글 범위: 0xAC00 - 0xD7A3
                if (c >= 0xAC00 && c <= 0xD7A3)
                {
                    koreanCount++;
                }
            }
            return koreanCount;
        }
    }

    class CheckInput
    {
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
