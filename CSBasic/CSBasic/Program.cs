using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBasic
{
    class Program
    {
        static void ValMain()
        {
            int nScore = 0;
            float fRat = 1.0f / 4.0f;
            Console.WriteLine("Score:" + nScore);
            Console.WriteLine("Rat:" + fRat);
        }
        //1.플레이어가 몬스터를 (공격: 때린다.)한다.
        //1.1. 때린다?: 죽는다 -> 데미지를 입는다 -> (플레이어의 공격력)만큼 (몬스터의 체력)이 감소한다.
        //데이터: 몬스터의 체력, 플레이어의 공격력 -> 변수(데이터타입: 정수)
        //알고리즘(연산): 몬스터의체력 - 플레이어의공격력 = 몬스터의 체력
        //모든 변수의 값을 출력하고 연산후에도 모든 변수의 값을 확인한다.
        static void PlayerAttackMonsterMain()
        {
            //초기화: 변수를 만들고 바로 값을 설정함.
            int nMonsterHP = 100;
            int nPlayerAtk = 10;
            Console.WriteLine("1.MonsterHP:" + nMonsterHP);
            Console.WriteLine("1.PlayerAtk:" + nPlayerAtk);
            //연산결과(이전값) 
            //90(100) = 100 - 10
            nMonsterHP = nMonsterHP - nPlayerAtk;
            Console.WriteLine("2.MonsterHP:" + nMonsterHP);
            Console.WriteLine("2.PlayerAtk:" + nPlayerAtk);
        }
        //1. 플레이어가 몬스터에게 치명공격을 했다.
        //1.1. 치명: 약점? 많이 아프다 -> 데미지가 많이들어간다. 랜덤으로, 일정확률로
        //1.2. 랜덤(일정확률): 공을 준비한다. 이 공중에 1개를 뽑을 기대값, 50% -> 2개중 1개
        //1.3. 많이 들어간다? -> 1.5배
        static void PlayerCritcalAttackMonsterMain()
        {
            //초기화: 변수를 만들고 바로 값을 설정함.
            int nMonsterHP = 100;
            int nPlayerAtk = 10;

            Console.WriteLine("1.MonsterHP:" + nMonsterHP);
            Console.WriteLine("1.PlayerAtk:" + nPlayerAtk);

            Random cRandom = new Random();
            int nRandom = cRandom.Next(1, 3);
            Console.WriteLine("Random:" + nRandom);
            if (nRandom == 1)
            {
                nMonsterHP = nMonsterHP - (int)((float)nPlayerAtk * 1.5f);
            }
            else
            {
                //90(100) = 100 - 10
                nMonsterHP = nMonsterHP - nPlayerAtk;
            }

            //연산결과(이전값) 

            Console.WriteLine("2.MonsterHP:" + nMonsterHP);
            Console.WriteLine("2.PlayerAtk:" + nPlayerAtk);
        }

        //모르는 기능을 쓸때는 검색에서 작동되는 코드를 만들어,
        //실행결과를 통해 알아보기
        static void RandomMain()
        {
            Random cRandom = new Random();
            int nRandom = cRandom.Next();
            Console.WriteLine("Next:" + nRandom);
            nRandom = cRandom.Next(10);
            Console.WriteLine("Next:" + nRandom);
            nRandom = cRandom.Next(10, 20);
            Console.WriteLine("Next:" + nRandom);
        }
        //마을로 이동 구현하기
        //1. 입력은 텍스트로 가고 싶은 장소를 지정한다.
        //2. 해당하는 장소가 있다면 "[입력값] 입니다". 라고 출력한다.
        //3. 아닌경우 "[입력값] 해당장소는 없습니다."
        static void StageMain()
        {
            Console.WriteLine("어디로 갈지 입력하세요.(마을,상점,필드)");
            string strInput = Console.ReadLine();

            switch (strInput)
            {
                case "마을":
                    Console.WriteLine("{0} 입니다.", strInput);
                    break;
                case "상점":
                    Console.WriteLine("{0} 입니다.", strInput);
                    break;
                case "필드":
                    Console.WriteLine("{0} 입니다.", strInput);
                    break;
                default:
                    Console.WriteLine("{0} 해당 장소는 없습니다.", strInput);
                    break;
            }
        }

        static void PlayerAttackWhileMonsterMain()
        {
            //초기화: 변수를 만들고 바로 값을 설정함.
            int nMonsterHP = 100; //-2
            int nPlayerAtk = 11; //-1

            //while (true)//1 //4
            //while(nMonsterHP > 0)
            while (!(nMonsterHP <= 0))
            { //2 //5
                Console.WriteLine("1.MonsterHP:" + nMonsterHP);
                Console.WriteLine("1.PlayerAtk:" + nPlayerAtk);
                //연산결과(이전값) 
                //90(100) = 100 - 10
                nMonsterHP = nMonsterHP - nPlayerAtk;
                Console.WriteLine("2.MonsterHP:" + nMonsterHP);
                Console.WriteLine("2.PlayerAtk:" + nPlayerAtk);
                if (nMonsterHP <= 0) break; //몬스터가 죽으면 끝남.
            } //3 //6....
        }
        //1.플레이어가 공격하면 몬스터가 반격한다.
        //.........
        static void BattleMain()
        {
            //초기화: 변수를 만들고 바로 값을 설정함.
            int nMonsterHP = 100; //-2
            int nPlayerAtk = 11; //-1

            int nPlayerHP = 100; //-2
            int nMonterAtk = 11; //-1

            //while (true)//1 //4
            //while(nMonsterHP > 0)
            while (!(nMonsterHP <= 0))
            { //2 //5
                Console.WriteLine("######### Player Turn #########");
                Console.WriteLine("1.MonsterHP:" + nMonsterHP);
                Console.WriteLine("1.PlayerAtk:" + nPlayerAtk);
                //연산결과(이전값) 
                //90(100) = 100 - 10
                nMonsterHP = nMonsterHP - nPlayerAtk;
                Console.WriteLine("2.MonsterHP:" + nMonsterHP);
                Console.WriteLine("2.PlayerAtk:" + nPlayerAtk);
                if (nMonsterHP <= 0) break; //몬스터가 죽으면 끝남.

                Console.WriteLine("######### Monster Turn #########");
                Console.WriteLine("1.nPlayerHP:" + nPlayerHP);
                Console.WriteLine("1.nMonterAtk:" + nMonterAtk);
                //연산결과(이전값) 
                //90(100) = 100 - 10
                nPlayerHP = nPlayerHP - nMonterAtk;
                Console.WriteLine("2.nPlayerHP:" + nPlayerHP);
                Console.WriteLine("2.nMonterAtk:" + nMonterAtk);
                if (nMonsterHP <= 0) break; //몬스터가 죽으면 끝남.
            } //3 //6....
        }

        static void MonsterListMain()
        {
            List<string> listMonster = new List<string>();
            listMonster.Add("Slime");
            listMonster.Add("Skeleton");
            listMonster.Add("Zombie");
            listMonster.Add("Dragon");

            Console.WriteLine("어디로 갈지 입력하세요.(숲,던전,무덤,둥지)");
            string strInput = Console.ReadLine();

            switch (strInput)
            {
                case "늪":
                    Console.WriteLine("{0}은 {1}의 서식지 입니다.", strInput, listMonster[0]);
                    break;
                case "던전":
                    Console.WriteLine("{0}은 {1}의 서식지 입니다.", strInput, listMonster[1]);
                    break;
                case "무덤":
                    Console.WriteLine("{0}은 {1}의 서식지 입니다.", strInput, listMonster[2]);
                    break;
                case "둥지":
                    Console.WriteLine("{0}은 {1}의 서식지 입니다.", strInput, listMonster[3]);
                    break;
                default:
                    Console.WriteLine("{0} 해당 장소는 없습니다.", strInput);
                    break;
            }
        }

        static void MonsterStageSelectMain()
        {
            List<string> listMonster = new List<string>();
            listMonster.Add("Slime"); //숲
            listMonster.Add("Skeleton"); //던전
            listMonster.Add("Zombie"); //무덤
            listMonster.Add("Dragon"); //둥지

            Console.WriteLine(listMonster[0]);
            Console.WriteLine(listMonster[3]);

            for (int i = 0; i < listMonster.Count; i++)
            {
                Console.WriteLine("[{0}]:{1}", i, listMonster[i]);
            }
        }

        static void Main(string[] args)
        {
            //실행: CTRL+ F5
            //Console.WriteLine("khg");
            //Console.WriteLine("Add:" + Add(10, 20));
            //ValMain();//함수의 호출
            //PlayerAttackMonsterMain();
            //RandomMain();
            //PlayerCritcalAttackMonsterMain();
            //StageMain();
            //PlayerAttackWhileMonsterMain();
            //BattleMain();
            MonsterListMain();
        }
        //코드작성 시 주의점
        //1.함수를 추가할 공간을 확보한다.
        //2.코드작성시 첫글자를 입력하고 자동완성기능을 활용한다.
        //3.{} (중괄호) 작성시 엔터를 넣어 코드를 작성할수 있는 공간을 확보한다.
        static int Add(int a, int b)
        {
            int c = a + b;
            return c;
        }
    }
}
