using MoneyWeapon.Managers;
using MoneyWeapon.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Utils
{
    internal class Guide
    {
        public static MenuList _townGuide = new MenuList();
        public static MenuList _townGuide2 = new MenuList();
        public static MenuList _mineGuide = new MenuList();
        public static MenuList _dungeonGuide = new MenuList();
        public static MenuList _dungeonGuide2 = new MenuList();
        public static MenuList _exchangeGuide = new MenuList();
        public static MenuList _battleGuide = new MenuList();

        public Guide()
        {
            Init();
        }

        private void Init()
        {
            _townGuide.Add("[마을 가이드]", Null);
            _townGuide.Add("어서오시게 나는 이 마을의 가이드라네.", Null);
            _townGuide.Add("마을의 건물을 설명해 주겠네.", Null);
            _townGuide.Add("[거래소] : $ , [광산] : 남쪽 포탈 (@) , [던전] : 동쪽 포탈 (@)", Null);
            _townGuide.Add("이동하고 싶은 곳의 포탈로 가서 [Enter] 키를 누르면 되네.", Null);
            _townGuide.Add("[I] 키를 누르면 현재 소지 금액을 확인할 수 있네.", Null);
            _townGuide.Add("일단 거래소로 가서 주식 거래를 해보게.", Null);

            _townGuide2.Add("[마을 가이드]", Null);
            _townGuide2.Add("[랜덤 횟수]를 모두 사용하였거나 [돈]이 부족하다면 [광산]으로 가보게", Null);
            _townGuide2.Add("돈을 꽤 모았다면 [던전]에 도전해보는것도 방법이겠지. 보상이 엄청나다네.", Null);
            _townGuide2.Add("이 세계에서는 [소지 금액]이 곧 [공격력]이네! 아 주식은 제외라네", Null);
            _townGuide2.Add("[I] 키를 누르면 현재 소지 금액을 확인할 수 있네.", Null);
            _townGuide2.Add("[거래소] : $ , [광산] : 남쪽 포탈 (@) , [던전] : 동쪽 포탈 (@)", Null);

            _exchangeGuide.Add("[거래소 가이드]", Null);
            _exchangeGuide.Add("[<- , ->] 키를 통해 거래소와 인벤토리로 이동할 수 있네", Null);
            _exchangeGuide.Add("[상호작용] : Enter 키를 통해 주식을 구매/판매 할 수 있네", Null);
            _exchangeGuide.Add("[랜덤] : R 키를 누르면 주식 가격이 변동 될거네.", Null);
            _exchangeGuide.Add("랜덤 횟수를 모두 썼거나 돈이 부족하다면 광산으로 가서 폐지를 줍게나!", Null);
            _exchangeGuide.Add("나가는 키는 [Esc] 키라네.", Null);

            _mineGuide.Add("[광산 가이드]", Null);
            _mineGuide.Add("어서오시게 여기는 광산이라네.", Null);
            _mineGuide.Add("[폐지] : ! , [노다지] : * 라네.", Null);
            _mineGuide.Add("근처에 가서 Enter 키를 누르면 주울 수 있네.", Null);
            _mineGuide.Add("[폐지]를 [3개] 팔거나 [노다지]를 [1개] 팔면 [랜덤횟수]가 [1] 증가하네.", Null);
            _mineGuide.Add("북쪽의 포탈을 통해 마을로 돌아갈 수 있네", Null);
            _mineGuide.Add("마을로 돌아가면 현재 광산의 아이템들은 초기화되고 새로 생성되네.", Null);
            _mineGuide.Add("노다지는 아주 낮은확률로 등장하니 잘 노려보게나 허허허", Null);

            _dungeonGuide.Add("[던전 가이드]", Null);
            _dungeonGuide.Add("어서오시게 벌써 [던전]에 오다니 용기가 대단하구만.", Null);
            _dungeonGuide.Add("던전 중간의 [M] : 몬스터 이고 근처에가서 [Space Bar] 키를 누르면 [전투]를 시작할 수 있네", Null);
            _dungeonGuide.Add("[몬스터]를 잡게되면 [보물상자]가 확정적으로 드랍된다네.", Null);
            _dungeonGuide.Add("[보물상자]는 몬스터 뒤에 드랍될거고 [R] 모양으로 생겼다네", Null);
            _dungeonGuide.Add("[몬스터]를 잡고 [보물상자]까지 먹었다면 [마을]로 돌아갔다 [던전]으로 들어와보게", Null);
            _dungeonGuide.Add("그러면 [던전]의 [층수]가 올라있을거고 [몬스터], [보상]도 더 강력해 질거네", Null);
            _dungeonGuide.Add("아 추가적으로 [주식 금액]도 일괄적으로 [상승]하게 된다네.", Null);
            _dungeonGuide.Add("[주식]과 [보유금액(공격력)]을 잘 조율해서 몬스터를 잡아야 할거네 허허허", Null);

            _dungeonGuide2.Add("[던전 가이드]", Null);
            _dungeonGuide2.Add("이런! 벌써 1층을 클리어 한겐가", Null);
            _dungeonGuide2.Add("이제 어느정도 게임을 플레이 하는법은 알았겠지", Null);
            _dungeonGuide2.Add("던전을 10층까지 클리어한 뒤 마을로 돌아가면 엔딩을 볼 수 있네", Null);
            _dungeonGuide2.Add("엔딩 후에도 던전은 무한정으로 올라갈 수 있으니 자네의 한계를 시험해 보게나 허허허", Null);

            _battleGuide.Add("[전투 가이드]", Null);
            _battleGuide.Add("[공격] : SpaceBar 로 공격할 수 있다네", Null);
            _battleGuide.Add("[현재 쿨타임] 이 [공격 쿨타임] 이상이 되어야 공격이 가능하다네", Null);
            _battleGuide.Add("[배틀 경과시간] 이 [최대 배틀시간] 이상이 되거나 [ESC] 키를 누르면 전투는 종료되네", Null);
            _battleGuide.Add("만약 [몬스터]를 못잡고 [전투]가 [종료]되면 [몬스터]의 [HP]는 [최대]로 [회복]되니 잘 잡아보게나 허허허", Null);
        }

        public void Render()
        {
            if (SceneManager.curScene() is TitleScene) return;
            else if (SceneManager.curScene() is TownScene)
            {
                if (SceneManager.prevScene() is TitleScene)
                    _townGuide.GuideRender(43, 0);
                else _townGuide2.GuideRender(43, 0);
            }
            else if (SceneManager.curScene() is MineScene) _mineGuide.GuideRender(40, 10);
            else if (SceneManager.curScene() is ExchangeScene) _exchangeGuide.GuideRender(45, 0);
            else if (SceneManager.curScene() is DungeonScene)
            {
                if(DungeonScene._curFloor == 1)
                _dungeonGuide.GuideRender(5, 15);
                else _dungeonGuide2.GuideRender(5, 15);

            }
            else if (SceneManager.curScene() is BattleScene) _battleGuide.GuideRender(2, 22);
        }

        private void Null()
        {

        }
    }
}
