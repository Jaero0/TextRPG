using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace TextRPG
{
    class Store
    {
        private List<EquipItemsInformation> storeItemList;

        public Store()
        {
            storeItemList = new List<EquipItemsInformation>();
        }

        public void StoreItemIn(EquipItemsInformation storeItem) // 장비 Inven리스트에 장비정보를 넣어줄 메서드
        {
            storeItemList.Add(storeItem);
        }

        public void MainStore() //상점 메인화면
        {
            Console.Clear();
            Console.WriteLine(" ::::::::  :::::::::::  ::::::::  :::::::::  :::::::::: \r\n:+:    :+:     :+:     :+:    :+: :+:    :+: :+:        \r\n+:+            +:+     +:+    +:+ +:+    +:+ +:+        \r\n+#++:++#++     +#+     +#+    +:+ +#++:++#:  +#++:++#   \r\n       +#+     +#+     +#+    +#+ +#+    +#+ +#+        \r\n#+#    #+#     #+#     #+#    #+# #+#    #+# #+#        \r\n ########      ###      ########  ###    ### ########## ");
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[보유한 골드]");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MainGame.player.currentGold + " G ");
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < storeItemList.Count; i++)
            {
                bool itemAlreadyInInventory = false;

                if (storeItemList[i].itAtt != 0 || storeItemList[i].itDef != 0)
                {
                    string attackBonusText = "";
                    if (storeItemList[i].itAtt > 0)
                    {
                        attackBonusText = "공격력" + " + " + storeItemList[i].itAtt;
                    }
                    else if (storeItemList[i].itAtt < 0)
                    {
                        attackBonusText = "공격력" + " - " + (-storeItemList[i].itAtt);
                    }

                    string defenseBonusText = "";
                    if (storeItemList[i].itDef > 0)
                    {
                        defenseBonusText = "방어력" + " + " + storeItemList[i].itDef;
                    }
                    else if (storeItemList[i].itDef < 0)
                    {
                        defenseBonusText = "방어력" + " - " + (-storeItemList[i].itDef);
                    }

                    int itNameKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].itName);
                    int attKoreanCount = KoreanCount.CountKoreanCharacters(attackBonusText);
                    int defKoreanCount = KoreanCount.CountKoreanCharacters(defenseBonusText);
                    int itInfoKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].itInfo);
                    int itBuyPriceKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].buyPrice);
                    int itSoldOutKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].soldOut);

                    Console.Write($" - ");

                    Console.Write(string.Format("{0}", storeItemList[i].itName).PadRight(20 - itNameKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", attackBonusText).PadRight(15 - attKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", defenseBonusText).PadRight(15 - defKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", storeItemList[i].itInfo).PadRight(50 - itInfoKoreanCount) + "|");

                    for (int j = 0; j < Inven.equipItemList.Count; j++)
                    {
                        if (storeItemList[i].itName == Inven.equipItemList[j].itName)
                        {
                            itemAlreadyInInventory = true;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(string.Format(" {0}", storeItemList[i].soldOut).PadRight(10 - itSoldOutKoreanCount));
                            Console.ResetColor();
                            Console.Write("|");

                            break;
                        }
                    }

                    if (!itemAlreadyInInventory)
                    {
                        Console.Write(string.Format(" {0} G{1}", storeItemList[i].buyPrice, "").PadRight(10 - itBuyPriceKoreanCount) + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }


            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("1. 아이템 구매");
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("2. 아이템 판매 ");
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
            StoreChoose();
        }

        public void StoreChoose() //상점 메인화면 선택분기
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.KeyChar == '1')
            {
                Console.ReadKey();
                StoreBuy();
            }
            if (info.KeyChar == '2')
            {
                Console.ReadKey();
                StoreSell();
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
                MainStore();
            }
        }

        public void StoreBuy() //상점구매 선택시 상점구매화면
        {
            Console.Clear();
            Console.WriteLine(" ::::::::  :::::::::::  ::::::::  :::::::::  :::::::::: \r\n:+:    :+:     :+:     :+:    :+: :+:    :+: :+:        \r\n+:+            +:+     +:+    +:+ +:+    +:+ +:+        \r\n+#++:++#++     +#+     +#+    +:+ +#++:++#:  +#++:++#   \r\n       +#+     +#+     +#+    +#+ +#+    +#+ +#+        \r\n#+#    #+#     #+#     #+#    #+# #+#    #+# #+#        \r\n ########      ###      ########  ###    ### ########## ");
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[보유한 골드]");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MainGame.player.currentGold + " G ");
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[상점 아이템 목록]");
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < storeItemList.Count; i++)
            {
                bool itemAlreadyInInventory = false;

                if (storeItemList[i].itAtt != 0 || storeItemList[i].itDef != 0)
                {
                    string attackBonusText = "";
                    if (storeItemList[i].itAtt > 0)
                    {
                        attackBonusText = "공격력" + " + " + storeItemList[i].itAtt;
                    }
                    else if (storeItemList[i].itAtt < 0)
                    {
                        attackBonusText = "공격력" + " - " + (-storeItemList[i].itAtt);
                    }

                    string defenseBonusText = "";
                    if (storeItemList[i].itDef > 0)
                    {
                        defenseBonusText = "방어력" + " + " + storeItemList[i].itDef;
                    }
                    else if (storeItemList[i].itDef < 0)
                    {
                        defenseBonusText = "방어력" + " - " + (-storeItemList[i].itDef);
                    }

                    int itNameKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].itName);
                    int attKoreanCount = KoreanCount.CountKoreanCharacters(attackBonusText);
                    int defKoreanCount = KoreanCount.CountKoreanCharacters(defenseBonusText);
                    int itInfoKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].itInfo);
                    int itBuyPriceKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].buyPrice);
                    int itSoldOutKoreanCount = KoreanCount.CountKoreanCharacters(storeItemList[i].soldOut);

                    Console.Write($" - {i + 1}. ");

                    Console.Write(string.Format("{0}", storeItemList[i].itName).PadRight(20 - itNameKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", attackBonusText).PadRight(15 - attKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", defenseBonusText).PadRight(15 - defKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", storeItemList[i].itInfo).PadRight(50 - itInfoKoreanCount) + "|");

                    for (int j = 0; j < Inven.equipItemList.Count; j++)
                    {
                        if (storeItemList[i].itName == Inven.equipItemList[j].itName)
                        {
                            itemAlreadyInInventory = true;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(string.Format(" {0}", storeItemList[i].soldOut).PadRight(10 - itSoldOutKoreanCount));
                            Console.ResetColor();
                            Console.Write("|");

                            break;
                        }
                    }

                    if (!itemAlreadyInInventory)
                    {
                        Console.Write(string.Format(" {0} G{1}", storeItemList[i].buyPrice, "").PadRight(10 - itBuyPriceKoreanCount) + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{storeItemList.Count + 1}. 상점으로 돌아가기");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("0. 나가기 ");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("구매할 장비의 숫자를 입력해주세요");
            Console.Write(">> ");
            BuyManage();
        }

        public void BuyManage() //구매시 로직
        {
            ConsoleKeyInfo info = Console.ReadKey();
            int selectedInfo = info.KeyChar - '0' - 1;

            if (0 <= selectedInfo && selectedInfo <= storeItemList.Count - 1)
            {
                Console.ReadKey();

                for (int i = 0; i < Inven.equipItemList.Count; i++)
                {
                    if (Inven.equipItemList[i].itName == storeItemList[selectedInfo].itName)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("이미 구매한 아이템입니다");
                        Console.WriteLine("숫자를 다시 입력하세요");
                        Console.ReadLine();
                        StoreBuy();
                    }
                    else if (MainGame.player.currentGold >= int.Parse(storeItemList[selectedInfo].buyPrice))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"{storeItemList[selectedInfo].itName}을/를 구매하시겠습니까?");
                        Console.WriteLine();
                        Console.WriteLine("1. 네" + "\n" + "2. 아니오");
                        Console.Write(">> ");
                        ConsoleKeyInfo info2 = Console.ReadKey();
                        Console.ReadKey();
                        if (info2.KeyChar == '1')
                        {
                            MainGame.player.currentGold -= int.Parse(storeItemList[selectedInfo].buyPrice);
                            Inven.equipItemList.Add(storeItemList[selectedInfo]);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine($"{storeItemList[selectedInfo].itName}을/를 구매하였습니다");
                            Console.WriteLine();
                            Console.ReadLine();
                            StoreBuy();
                        }
                        else if (info2.KeyChar == '2')
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("구매를 취소했습니다");
                            Console.WriteLine();
                            Console.ReadLine();
                            StoreBuy();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("숫자를 다시 입력하세요");
                            Console.WriteLine();
                            Console.ReadLine();
                            StoreBuy();
                        }
                    }
                    else if (MainGame.player.currentGold < int.Parse(storeItemList[selectedInfo].buyPrice))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("골드가 부족합니다");
                        Console.WriteLine();
                        Console.ReadLine();
                        StoreBuy();
                    }
                }
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
            else if (info.KeyChar - '0' == (storeItemList.Count + 1))
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("메인 상점화면으로 진입합니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                MainStore();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("숫자를 다시 입력하세요");
                Console.WriteLine();
                Console.ReadLine();
                StoreSell();
            }
        }

        public void StoreSell() //상점 판매 선택시 상점판매화면
        {
            Console.Clear();
            Console.WriteLine(" ::::::::  :::::::::::  ::::::::  :::::::::  :::::::::: \r\n:+:    :+:     :+:     :+:    :+: :+:    :+: :+:        \r\n+:+            +:+     +:+    +:+ +:+    +:+ +:+        \r\n+#++:++#++     +#+     +#+    +:+ +#++:++#:  +#++:++#   \r\n       +#+     +#+     +#+    +#+ +#+    +#+ +#+        \r\n#+#    #+#     #+#     #+#    #+# #+#    #+# #+#        \r\n ########      ###      ########  ###    ### ########## ");
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[보유한 골드]");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(MainGame.player.currentGold + " G ");
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[내 아이템 목록]");
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < Inven.equipItemList.Count; i++)
            {
                if (Inven.equipItemList[i].itAtt != 0 || Inven.equipItemList[i].itDef != 0) // itAtt와 itDef중 하나라도 0이 아니면
                {
                    string attackBonusText = ""; //공격력 추가 메세지는 ""로 초기화 -> 아래 if문에서 초기화가 되지 않으면 빈칸으로 나옴
                    if (Inven.equipItemList[i].itAtt > 0)
                    {
                        attackBonusText = "공격력" + " + " + Inven.equipItemList[i].itAtt; // itAtt가 0보다 크면 attackBonusText에 할당
                    }
                    else if (Inven.equipItemList[i].itAtt < 0)
                    {
                        attackBonusText = "공격력" + " - " + (-Inven.equipItemList[i].itAtt);// itAtt가 0보다 작으면 attackBonusText에 할당
                    }

                    string defenseBonusText = "";//방어력 추가 메세지는 ""로 초기화 -> 아래 if문에서 초기화가 되지 않으면 빈칸으로 나옴
                    if (Inven.equipItemList[i].itDef > 0)
                    {
                        defenseBonusText = "방어력" + " + " + Inven.equipItemList[i].itDef;// itDef가 0보다 크면 defenseBonusText에 할당
                    }
                    else if (Inven.equipItemList[i].itDef < 0)
                    {
                        defenseBonusText = "방어력" + " - " + (-Inven.equipItemList[i].itDef);// itDef가 0보다 작으면 defenseBonusText에 할당
                    }

                    int itNameKoreanCount = KoreanCount.CountKoreanCharacters(Inven.equipItemList[i].itName);
                    int attKoreanCount = KoreanCount.CountKoreanCharacters(attackBonusText);
                    int defKoreanCount = KoreanCount.CountKoreanCharacters(defenseBonusText);
                    int itInfoKoreanCount = KoreanCount.CountKoreanCharacters(Inven.equipItemList[i].itInfo);
                    int sellPriceKoreanCount = KoreanCount.CountKoreanCharacters(Inven.equipItemList[i].sellPrice);

                    Console.Write($" - {i + 1}. ");

                    Console.Write(string.Format("{0}{1}", Inven.equipItemList[i].equiped, Inven.equipItemList[i].itName).PadRight(25 - itNameKoreanCount - 3) + "|");

                    Console.Write(string.Format(" {0}", attackBonusText).PadRight(15 - attKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", defenseBonusText).PadRight(15 - defKoreanCount) + "|");

                    Console.Write(string.Format(" {0}", Inven.equipItemList[i].itInfo).PadRight(60 - itInfoKoreanCount) + "|");

                    Console.Write(" 판매가 :");

                    Console.Write(string.Format(" {0} G", (int.Parse(Inven.equipItemList[i].sellPrice) / 100) * 85).PadRight(10 - sellPriceKoreanCount) + "|");

                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{Inven.equipItemList.Count + 1}. 메인 상점화면으로 돌아가기");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("0. 나가기 ");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("판매할 장비의 숫자를 입력해주세요");
            Console.Write(">> ");
            SellManage();
        }

        public void SellManage() //상점 판매 로직
        {
            ConsoleKeyInfo info = Console.ReadKey();
            int selectedInfo = info.KeyChar - '0' - 1;

            if (0 <= selectedInfo && selectedInfo <= Inven.equipItemList.Count - 1)
            {
                Console.ReadKey();

                if (Inven.equipItemList[selectedInfo].equiped.StartsWith("[E] "))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"{Inven.equipItemList[selectedInfo].itName}은/는 현재 장착중인 아이템입니다");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"정말 {Inven.equipItemList[selectedInfo].itName}을/를 판매하시겠습니까?");
                    Console.WriteLine();
                    Console.WriteLine("1. 네" + "\n" + "2. 아니오");
                    Console.Write(">> ");
                    ConsoleKeyInfo info2 = Console.ReadKey();
                    Console.ReadKey();
                    if (info2.KeyChar == '1')
                    {
                        MainGame.player.currentGold += (int.Parse(Inven.equipItemList[selectedInfo].sellPrice) / 100) * 85;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"{Inven.equipItemList[selectedInfo].itName}을/를 판매하였습니다");
                        Inven.equipItemList.RemoveAt(selectedInfo);
                        Console.WriteLine();
                        Console.ReadLine();
                        StoreSell();
                    }
                    else if (info2.KeyChar == '2')
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("판매를 취소했습니다");
                        Console.WriteLine();
                        Console.ReadLine();
                        StoreSell();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("숫자를 다시 입력하세요");
                        Console.WriteLine();
                        Console.ReadLine();
                        StoreSell();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"{Inven.equipItemList[selectedInfo].itName}을/를 판매하시겠습니까?");
                    Console.WriteLine();
                    Console.WriteLine("1. 네" + "\n" + "2. 아니오");
                    Console.Write(">> ");
                    ConsoleKeyInfo info2 = Console.ReadKey();
                    Console.ReadKey();
                    if (info2.KeyChar == '1')
                    {
                        MainGame.player.currentGold += (int.Parse(Inven.equipItemList[selectedInfo].sellPrice) / 100) * 85;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"{Inven.equipItemList[selectedInfo].itName}을/를 판매하였습니다");
                        Inven.equipItemList.RemoveAt(selectedInfo);
                        Console.WriteLine();
                        Console.ReadLine();
                        StoreSell();
                    }
                    else if (info2.KeyChar == '2')
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("판매를 취소했습니다");
                        Console.WriteLine();
                        Console.ReadLine();
                        StoreSell();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("숫자를 다시 입력하세요");
                        Console.WriteLine();
                        Console.ReadLine();
                        StoreSell();
                    }
                }

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
            else if (info.KeyChar - '0' == (Inven.equipItemList.Count + 1))
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("잠시만 기다려주세요.");
                Console.WriteLine();
                Console.Write("메인 상점화면으로 진입합니다.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                MainStore();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("숫자를 다시 입력하세요");
                Console.WriteLine();
                Console.ReadLine();
                StoreSell();
            }
        }
    }
}
