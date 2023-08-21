using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Player //플레이어 클래스
    {
        public string name { get; }
        public string job { get; }
        public int lv { get; }
        public int att { get; set; }
        public int def { get; set; }
        public int hp { get; set; }
        public int currentGold { get; set; }

        public int baseAtt { get; }
        public int baseDef { get; }

        public Player(string _Name, string _Job, int _Lv, int _Att, int _Def, int _Hp, int _CurrentGold)
        {
            name = _Name;
            job = _Job;
            lv = _Lv;
            att = _Att;
            def = _Def;
            hp = _Hp;
            currentGold = _CurrentGold;
            baseAtt = _Att;
            baseDef = _Def;
        }
    }
}
