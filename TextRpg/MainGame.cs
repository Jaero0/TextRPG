using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Numerics;
using System.Xml.Linq;
using TextRPG;
using Utility;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG
{
    class MainGame
    {
        public static Player player;
        public static Inven equipInven;
        public static Store store;

        public static EquipItemsInformation equipItem1;
        public static EquipItemsInformation equipItem2;
        public static EquipItemsInformation JaeRoItem1;
        public static EquipItemsInformation JaeRoItem2;

        public static EquipItemsInformation storeItem1;
        public static EquipItemsInformation storeItem2;
        public static EquipItemsInformation storeItem3;
        public static EquipItemsInformation storeItem4;
        public static EquipItemsInformation storeItem5;
        public static EquipItemsInformation storeItem6;



        static void PlayerData()
        {
            player = new Player("Tonton", "전사", 01, 10, 5, 100, 1500);
            equipInven = new Inven();
            store = new Store();

            equipItem1 = new EquipItemsInformation("", "무쇠 갑옷", 0, 5,  "무쇠로 만들어져 튼튼한 갑옷입니다.", "1000");
            equipItem2 = new EquipItemsInformation("", "낡은 검", 2, 0,  "쉽게 볼 수 있는 낡은 검 입니다.", "500");
            JaeRoItem1 = new EquipItemsInformation("", "오래된 일렉기타", 10, -10, "락큰롤 정신을 이어받아라!", "5000");
            JaeRoItem2 = new EquipItemsInformation("", "각잡힌 베레모", 5, 3, "그때 그 시절이 떠오릅니다", "2500");

            storeItem1 = new EquipItemsInformation("", "수련자 갑옷", 0, 2, "수련에 도움을 주는 갑옷입니다.", "500", "구매완료");
            storeItem2 = new EquipItemsInformation("", "무쇠 갑옷", 0, 5, "무쇠로 만들어져 튼튼한 갑옷입니다", "1000", "구매완료");
            storeItem3 = new EquipItemsInformation("", "스파르타의 값옷", 0, 15, "스파르타의 전사들이 사용했다는 갑옷입니다", "3500", "구매완료");
            storeItem4 = new EquipItemsInformation("", "낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다","500", "구매완료");
            storeItem5 = new EquipItemsInformation("", "청동도끼",5, 0, "어디선가 사용됐던것 같은 도끼입니다", "1500", "구매완료");
            storeItem6 = new EquipItemsInformation("", "스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 창입니다", "3000", "구매완료");

            equipInven.InvenItemIn(equipItem1);
            equipInven.InvenItemIn(equipItem2);
            equipInven.InvenItemIn(JaeRoItem1);
            equipInven.InvenItemIn(JaeRoItem2);

            store.StoreItemIn(storeItem1);
            store.StoreItemIn(storeItem2);
            store.StoreItemIn(storeItem3);
            store.StoreItemIn(storeItem4);
            store.StoreItemIn(storeItem5);
            store.StoreItemIn(storeItem6);
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
            Console.WriteLine("\r\n:::::::::   ::::::::   ::::::::  :::    ::: ::::::::::             :::::::::  :::    ::: ::::    :::  ::::::::  ::::::::::  ::::::::  ::::    ::: \r\n:+:    :+: :+:    :+: :+:    :+: :+:    :+: :+:                    :+:    :+: :+:    :+: :+:+:   :+: :+:    :+: :+:        :+:    :+: :+:+:   :+: \r\n+:+    +:+ +:+    +:+ +:+        +:+    +:+ +:+                    +:+    +:+ +:+    +:+ :+:+:+  +:+ +:+        +:+        +:+    +:+ :+:+:+  +:+ \r\n+#++:++#:  +#+    +:+ :#:        +#+    +:+ +#++:++#               +#+    +:+ +#+    +:+ +#+ +:+ +#+ :#:        +#++:++#   +#+    +:+ +#+ +:+ +#+ \r\n+#+    +#+ +#+    +#+ +#+   +#+# +#+    +#+ +#+                    +#+    +#+ +#+    +#+ +#+  +#+#+# +#+   +#+# +#+        +#+    +#+ +#+  +#+#+# \r\n#+#    #+# #+#    #+# #+#    #+# #+#    #+# #+#                    #+#    #+# #+#    #+# #+#   #+#+# #+#    #+# #+#        #+#    #+# #+#   #+#+# \r\n###    ###  ########   ########   ########  ##########             #########   ########  ###    ####  ########  ##########  ########  ###    #### \r\n");
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
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("3. 상점 ");
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
            else if (info.KeyChar == '3')
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("상점으로 진입합니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                store.MainStore();
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
            Console.WriteLine(" ::::::::  :::::::::::     :::     ::::::::::: :::    :::  ::::::::  \r\n:+:    :+:     :+:       :+: :+:       :+:     :+:    :+: :+:    :+: \r\n+:+            +:+      +:+   +:+      +:+     +:+    +:+ +:+        \r\n+#++:++#++     +#+     +#++:++#++:     +#+     +#+    +:+ +#++:++#++ \r\n       +#+     +#+     +#+     +#+     +#+     +#+    +#+        +#+ \r\n#+#    #+#     #+#     #+#     #+#     #+#     #+#    #+# #+#    #+# \r\n ########      ###     ###     ###     ###      ########   ########  ");
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
