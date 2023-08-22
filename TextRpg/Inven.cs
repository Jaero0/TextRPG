using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{

    class Inven //인벤토리 클래스 
    {
        public bool IsEquip = false; // 장비가 장착되어있는지 확인하는 변수

        private List<EquipItem> equipItemList; // 장비 아이템 정보가 담긴 배열

        public Inven() // EquipItem클래스를 이용해 장비Inven 리스트를 만들 생성자 
        {
            equipItemList = new List<EquipItem>();
        }

        public void ItemIn(EquipItem equipItem) // 장비 Inven리스트에 장비정보를 넣어줄 메서드
        {
            equipItemList.Add(equipItem);
        }

        public void InvenStatus()
        {
            Console.Clear();
            Console.WriteLine("\r\n      :::::::::::       ::::    :::    :::     :::       ::::::::::       ::::    :::   :::::::::::       ::::::::       :::::::::    :::   ::: \r\n         :+:           :+:+:   :+:    :+:     :+:       :+:              :+:+:   :+:       :+:          :+:    :+:      :+:    :+:   :+:   :+:  \r\n        +:+           :+:+:+  +:+    +:+     +:+       +:+              :+:+:+  +:+       +:+          +:+    +:+      +:+    +:+    +:+ +:+    \r\n       +#+           +#+ +:+ +#+    +#+     +:+       +#++:++#         +#+ +:+ +#+       +#+          +#+    +:+      +#++:++#:      +#++:      \r\n      +#+           +#+  +#+#+#     +#+   +#+        +#+              +#+  +#+#+#       +#+          +#+    +#+      +#+    +#+      +#+        \r\n     #+#           #+#   #+#+#      #+#+#+#         #+#              #+#   #+#+#       #+#          #+#    #+#      #+#    #+#      #+#         \r\n###########       ###    ####        ###           ##########       ###    ####       ###           ########       ###    ###      ###          \r\n");
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[인벤토리 목록]");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < equipItemList.Count; i++)
            {
                if (equipItemList[i].itAtt != 0 || equipItemList[i].itDef != 0)
                {
                    string attackBonusText = "";
                    if (equipItemList[i].itAtt > 0)
                    {
                        attackBonusText = "공격력" + " + " + equipItemList[i].itAtt;
                    }
                    else if (equipItemList[i].itAtt < 0)
                    {
                        attackBonusText = "공격력" + " - " + (-equipItemList[i].itAtt);
                    }

                    string defenseBonusText = "";
                    if (equipItemList[i].itDef > 0)
                    {
                        defenseBonusText = "방어력" + " + " + equipItemList[i].itDef;
                    }
                    else if (equipItemList[i].itDef < 0)
                    {
                        defenseBonusText = "방어력" + " - " + (-equipItemList[i].itDef);
                    }

                    int itNameKoreanCount = CountKoreanCharacters(equipItemList[i].itName);
                    int attKoreanCount = CountKoreanCharacters(attackBonusText);
                    int defKoreanCount = CountKoreanCharacters(defenseBonusText);
                    int itInfoKoreanCount = CountKoreanCharacters(equipItemList[i].itInfo);

                    Console.Write($" - {equipItemList[i].equiped}");

                    Console.Write(string.Format("{0}", equipItemList[i].itName).PadRight(20  - itNameKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", attackBonusText).PadRight(15 - attKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", defenseBonusText).PadRight(15 - defKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", equipItemList[i].itInfo).PadRight(60 - itInfoKoreanCount) + "|");

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("1. 장착관리");

            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("0. 메인화면으로 ");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
            InvenChoose();
        }

        public void InvenChoose()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.KeyChar == '1')
            {
                Console.ReadKey();
                EquipManage();
            }
            else if (info.KeyChar == '0')
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("메인화면으로 진입합니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                MainGame.GameStart();
            }
            else
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잘못된 입력입니다. 숫자를 다시 입력하세요");
                Console.ReadKey();
                InvenStatus();
            }
        }

        public void EquipManage()
        {
            Console.Clear();
            Console.WriteLine("\r\n      :::::::::::   :::::::::::       ::::::::::         :::   :::                       :::   :::           :::        ::::    :::           :::        ::::::::       :::::::::: \r\n         :+:           :+:           :+:               :+:+: :+:+:                     :+:+: :+:+:        :+: :+:      :+:+:   :+:         :+: :+:     :+:    :+:      :+:         \r\n        +:+           +:+           +:+              +:+ +:+:+ +:+                   +:+ +:+:+ +:+      +:+   +:+     :+:+:+  +:+        +:+   +:+    +:+             +:+          \r\n       +#+           +#+           +#++:++#         +#+  +:+  +#+                   +#+  +:+  +#+     +#++:++#++:    +#+ +:+ +#+       +#++:++#++:   :#:             +#++:++#      \r\n      +#+           +#+           +#+              +#+       +#+                   +#+       +#+     +#+     +#+    +#+  +#+#+#       +#+     +#+   +#+   +#+#      +#+            \r\n     #+#           #+#           #+#              #+#       #+#                   #+#       #+#     #+#     #+#    #+#   #+#+#       #+#     #+#   #+#    #+#      #+#             \r\n###########       ###           ##########       ###       ###                   ###       ###     ###     ###    ###    ####       ###     ###    ########       ##########       \r\n");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    [아이템 목록]");
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < equipItemList.Count; i++)
            {
                if (equipItemList[i].itAtt != 0 || equipItemList[i].itDef != 0) // itAtt와 itDef중 하나라도 0이 아니면
                {
                    string attackBonusText = ""; //공격력 추가 메세지는 ""로 초기화 -> 아래 if문에서 초기화가 되지 않으면 빈칸으로 나옴
                    if (equipItemList[i].itAtt > 0)
                    {
                        attackBonusText = "공격력" + " + " + equipItemList[i].itAtt; // itAtt가 0보다 크면 attackBonusText에 할당
                    }
                    else if (equipItemList[i].itAtt < 0)
                    {
                        attackBonusText = "공격력" + " - " + (-equipItemList[i].itAtt);// itAtt가 0보다 작으면 attackBonusText에 할당
                    }

                    string defenseBonusText = "";//방어력 추가 메세지는 ""로 초기화 -> 아래 if문에서 초기화가 되지 않으면 빈칸으로 나옴
                    if (equipItemList[i].itDef > 0)
                    {
                        defenseBonusText = "방어력" + " + " + equipItemList[i].itDef;// itDef가 0보다 크면 defenseBonusText에 할당
                    }
                    else if (equipItemList[i].itDef < 0)
                    {
                        defenseBonusText = "방어력" + " - " + (-equipItemList[i].itDef);// itDef가 0보다 작으면 defenseBonusText에 할당
                    }

                    //Console.WriteLine($" - {i + 1}. " +
                    //    $"{equipItemList[i].equiped}{equipItemList[i].itName}    " +
                    //    $"| {attackBonusText} {defenseBonusText}    " +
                    //    $"| {equipItemList[i].itInfo}");

                    int itNameKoreanCount = CountKoreanCharacters(equipItemList[i].itName);
                    int attKoreanCount = CountKoreanCharacters(attackBonusText);
                    int defKoreanCount = CountKoreanCharacters(defenseBonusText);
                    int itInfoKoreanCount = CountKoreanCharacters(equipItemList[i].itInfo);

                    Console.Write($" - {i+1}. {equipItemList[i].equiped}");

                    Console.Write(string.Format("{0}", equipItemList[i].itName).PadRight(20 - itNameKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", attackBonusText).PadRight(15 - attKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", defenseBonusText).PadRight(15 - defKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", equipItemList[i].itInfo).PadRight(60 - itInfoKoreanCount) + "|");

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{equipItemList.Count + 1}. 인벤토리로 돌아가기");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"0. 메인 화면으로 나가기");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("장착할 장비의 번호를 입력하세요");
            Console.Write(">> ");

            ConsoleKeyInfo info = Console.ReadKey();
            int selectedEquipment = (info.KeyChar - '0') - 1; // 장비인벤토리 인덱스값을 확인하기 위한 변수

            if (0 <= selectedEquipment && selectedEquipment < equipItemList.Count) // info의 char값을 int로 변환
            {
                Console.ReadKey();
                Console.Clear();

                if (equipItemList[selectedEquipment].equiped.StartsWith("[E] "))
                {
                    equipItemList[selectedEquipment].equiped = equipItemList[selectedEquipment].equiped.Substring(4); // [E]가 있으면 제거

                    MainGame.player.att -= equipItemList[selectedEquipment].itAtt; // player객체의 공격력 값에 [E]가 해제되면 공격력 제거하기
                    MainGame.player.def -= equipItemList[selectedEquipment].itDef; // player객체의 방어력 값에 [E]가 해제되면 방어력 제거하기
                }
                else
                {
                    equipItemList[selectedEquipment].equiped = "[E] "; // [E]가 없으면 추가

                    MainGame.player.att += equipItemList[selectedEquipment].itAtt; // player객체의 공격력 값에 [E]가 되면 공격력 추가하기
                    MainGame.player.def += equipItemList[selectedEquipment].itDef; // player객체의 방어력 값에 [E]가 되면 방어력 추가하기
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("장착할 장비의 번호를 입력하세요");
                Console.Write(">> ");
                EquipManage();

            }

            else if (info.KeyChar - '0' == equipItemList.Count + 1)
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("인벤토리로 돌아갑니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                InvenStatus();
            }

            else if (info.KeyChar == '0')
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("메인화면으로 진입합니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                MainGame.GameStart();
            }

            else
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잘못된 입력입니다");
                Console.ReadKey();
                EquipManage();
            }
        }

        static int CountKoreanCharacters(string input) //한글 카운트 하기
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

    class EquipItem // 장비목록
    {
        public string equiped { get; set; }
        public string itName { get; }
        public int itAtt { get; }
        public int itDef { get; }
        public string itInfo { get; }

        public EquipItem(string _Equiped, string _ItName, int _ItAtt, int _ItDef, string _ItInfo)
        {
            equiped = _Equiped;
            itName = _ItName;
            itAtt = _ItAtt;
            itDef = _ItDef;
            itInfo = _ItInfo;
        }
    }
}

