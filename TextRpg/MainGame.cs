using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Numerics;
using System.Xml.Linq;
using TextRPG;

namespace TextRPG
{
    class MainGame
    {
        public static Player player;
        public static Inven equipInven;
        public static EquipItem equipItem1;
        public static EquipItem equipItem2;
        public static EquipItem JaeRoItem1;
        public static EquipItem JaeRoItem2;


        static void PlayerData()
        {
            player = new Player("Tonton", "전사", 01, 10, 5, 100, 1500);
            
            equipInven = new Inven();

            equipItem1 = new EquipItem("", "무쇠 갑옷", 0, 5,  "무쇠로 만들어져 튼튼한 갑옷입니다.");
            equipItem2 = new EquipItem("", "낡은 검", 2, 0,  "쉽게 볼 수 있는 낡은 검 입니다.");
            JaeRoItem1 = new EquipItem("", "오래된 일렉기타", 10, -10, "정신나간 공격력을 자랑하지만 그만큼 방어력도 낮아진다");
            JaeRoItem2 = new EquipItem("", "각잡힌 베레모", 5, 3, "그때 그 시절이 떠오릅니다");
            equipInven.ItemIn(equipItem1);
            equipInven.ItemIn(equipItem2);
            equipInven.ItemIn(JaeRoItem1);
            equipInven.ItemIn(JaeRoItem2);
        }

        

        public static void Main(string[] args)
        {
            //PlayerChoose()
            
            PlayerData();
            GameStart();
        }

        public static void GameStart() // 
        {
            Console.Clear();
            Console.SetWindowSize(210, 40);
            Console.WriteLine("\r\n      :::::::::       ::::::::       ::::::::      :::    :::       ::::::::::                     :::::::::      :::    :::       ::::    :::       ::::::::       ::::::::::       ::::::::       ::::    ::: \r\n     :+:    :+:     :+:    :+:     :+:    :+:     :+:    :+:       :+:                            :+:    :+:     :+:    :+:       :+:+:   :+:      :+:    :+:      :+:             :+:    :+:      :+:+:   :+:  \r\n    +:+    +:+     +:+    +:+     +:+            +:+    +:+       +:+                            +:+    +:+     +:+    +:+       :+:+:+  +:+      +:+             +:+             +:+    +:+      :+:+:+  +:+   \r\n   +#++:++#:      +#+    +:+     :#:            +#+    +:+       +#++:++#                       +#+    +:+     +#+    +:+       +#+ +:+ +#+      :#:             +#++:++#        +#+    +:+      +#+ +:+ +#+    \r\n  +#+    +#+     +#+    +#+     +#+   +#+#     +#+    +#+       +#+                            +#+    +#+     +#+    +#+       +#+  +#+#+#      +#+   +#+#      +#+             +#+    +#+      +#+  +#+#+#     \r\n #+#    #+#     #+#    #+#     #+#    #+#     #+#    #+#       #+#                            #+#    #+#     #+#    #+#       #+#   #+#+#      #+#    #+#      #+#             #+#    #+#      #+#   #+#+#      \r\n###    ###      ########       ########       ########        ##########                     #########       ########        ###    ####       ########       ##########       ########       ###    ####       \r\n");
            Console.WriteLine();
            Console.WriteLine("   Rogue DunGeon에 오신 여러분 환영합니다.");
            Console.WriteLine("   이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("1. 상태 보기");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("2. 인벤토리 ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine();
            Console.Write(">> ");
            ForkKeyInput();
        }

        public static void ForkKeyInput()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.KeyChar == '1')
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("상태창으로 진입합니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                PlayerStatus();
            }
            else if (info.KeyChar == '2')
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("인벤토리로 진입합니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                equipInven.InvenStatus();
            }
            else
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("아직 미구현입니다. 아무키나 눌러 처음화면으로 되돌아가세요");
                Console.ReadKey();
                GameStart();
            }
        }

        public static void PlayerStatus() // 플레이어 스테이터스 출력 함수
        {
            Console.Clear();
            Console.SetWindowSize(150, 40);
            Console.WriteLine("\r\n      ::::::::   :::::::::::           :::    :::::::::::      :::    :::       :::::::: \r\n    :+:    :+:      :+:             :+: :+:      :+:          :+:    :+:      :+:    :+: \r\n   +:+             +:+            +:+   +:+     +:+          +:+    +:+      +:+         \r\n  +#++:++#++      +#+           +#++:++#++:    +#+          +#+    +:+      +#++:++#++   \r\n        +#+      +#+           +#+     +#+    +#+          +#+    +#+             +#+    \r\n#+#    #+#      #+#           #+#     #+#    #+#          #+#    #+#      #+#    #+#     \r\n########       ###           ###     ###    ###           ########        ########       \r\n");
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("현재 스탯");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"    {player.name} ( {player.job} )");
            Console.WriteLine($"    Lv. {player.lv}");

            if (player.att - Math.Abs(player.att - player.baseAtt) >= player.baseAtt)
            {
                Console.WriteLine($"    공격력 : {player.att} (+{player.att - player.baseAtt})");
            }
            else
            {
                Console.WriteLine($"    공격력 : {player.att} ({player.att - player.baseAtt})");
            }

            if (player.def - Math.Abs(player.def - player.baseDef) >= player.baseDef)
            {
                Console.WriteLine($"    공격력 : {player.def} (+{player.def - player.baseDef})");
            }
            else
            {
                Console.WriteLine($"    공격력 : {player.def} ({player.def - player.baseDef})");
            }
            
            Console.WriteLine($"    체력   : {player.hp}");
            Console.WriteLine($"    Gold   : {player.currentGold} G");
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0. 나가기");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");

            ConsoleKeyInfo info = Console.ReadKey();
            if (info.KeyChar == '0')
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
                GameStart();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("아직 미구현입니다. 아무키나 눌러 처음화면으로 되돌아가세요");
                Console.ReadKey();
                PlayerStatus();
            }
        }
    }

    
}
