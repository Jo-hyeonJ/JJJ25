using System.Dynamic;

namespace JJJ25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // dynamic 자료형
            // => 컴파일시에 type을 체크하지 않고 runtime에 결정되는 자료형
            // object를 사용하기 때문에 유사하지만 실제로 값을 사용할 때 형변환이 필요없다.

            // 형변환이 필요한 object자료형
            object obj = 10;
            int num = (int)obj;

            // 값을 대입할 때 사실상 자료형이 결정된다.
            dynamic dynamic = 10;
            int num2 = dynamic;

            dynamic = "ABC";
            string str = dynamic;

            // dynamic 객체

            // 이미 선언된 값의 대입이 불가능한 무명 형식 클래스
            var search = new { name = 30 };
            // search.name = 30;

            // 다이나믹 객체는 선언과 대입이 동시에 이루어진다.
            dynamic item = new ExpandoObject();
            item.name = "ABCD";
            item.level = 11;
            item.id = 1;

            // 함수 또한 삽입이 가능하다.
            item.ShowInfo = (Action)( () => Console.WriteLine($"name:{item.name}, level : {item.level}"));

            item.ShowInfo();


            // 멀티 쓰레드 제작
            Thread thread = new Thread(() => Task1());

            thread.Start();
            Task2();
            */
            // 하나의 쓰레드에서 병렬적처리를 하는것이 비동기
            // 복수의 쓰레드로 동시에 처리하는 것을 멀티 쓰레드

            // 멀티 쓰레드의 주의점
            // 복수의 쓰레드에서 한가지 매개를 다룰 때 동시에 접근하게 되면
            // 무한 루프에 빠지거나 안에 담긴 데이터가 변질될 우려가 있다.


            // lock
            // 위와 같은 문제 상황 발생을 방지하는 키워드
            // 어떠한 object에 접근하고 있는 쓰레드가 있다면(복수 사용의 상황) 사용이 끝날 때까지 대기하게한다.
            // 멀티 쓰레드에서 처리 순서를 정하는데에 사용한다.




            // async 비동기식
            // 먼저 시작한 작업이 끝나지 않아도 개별적으로 움직일 수 있다.
            // 비동기식 처리는 일반적인 흐름을 벗어나서 개별적으로 움직인다.
            /*
            while (true)
            {
                Timer();
                Counter();
                Console.Clear();
                Console.WriteLine(timer);
                Console.WriteLine(count);
            }
            */

            // 체크리스트 만들기
            // 할 일과 수행 여부를 매개 변수로 받고 false받은 값을 배열로 반환

            string[] todo = { "check", "ck", "ec", "he", "che", "cy" };
            bool[] fin = { true, false, true, false, true, false };
            // ck , he, cy
            todo = CheckList(todo, fin);
            foreach(string todoItem in todo)
            {
                Console.WriteLine(todoItem);
            }


        }
        /*
        static long current = 0; // 현재 다운 진행도를 나타낼 변수
        static long max = long.MaxValue; // 진행도 최대를 나타낼 변수

        static void Input()
        {



        }

        static void Process()
        {
            DownloaFromServer();

        }
        static void Render()
        {
            Console.Clear();
            Console.WriteLine($"{current}/{max} ({(current / (float)max * 100).ToString("F2")}%)");
        }

        // async는 하나 이상의 await를 포함할 수 있다.
        static async void DownloaFromServer()
        {
            Task task = Task.Run(() => Download());
            await task;
        }

        static Task Download()
        {
            while (true)
            {
                current++;
            }
        }
        */

        static string[] CheckList(string[] todo, bool[] fin)
        {
            // Zip : 두 열거자를 묶는 키워드
            // 이중으로 zip형태로 만드는 것 또한 가능하며 호출 형태는 Zip(zip(first,second),second) 형태로 이루어진다.
            // zip으로 묶인 열거형의 자료형은 따로 명시되지 않고 임시적으로 묶인 관계에 가깝다.
            // 람다식을 활용하여 매개 변수의 이름을 지정해줄수 있으며 적합한 형태의 클래스에 대입이 가능하다.

            var zip = todo.Zip(fin, (first,second) => new {schedule = first, isDone = second});
            foreach(var item in zip)
            {
                Console.WriteLine(item.schedule + item.isDone);
            }

            // Where 사용
            return todo.Where((todo,index) => !fin[index]).ToArray();
            
            List<string> list = new List<string>();
            list = todo.ToList();
            for(int i = todo.Length-1; i >= 0; i--)
            {
                if (fin[i])
                {
                    list.RemoveAt(i);
                }
            }

            return list.ToArray();


        }

        static int timer;
        static async void Timer()
        {
            // Task : 하나의 절차(일)
            Task task = Task.Run(() => {
            
                timer += 1;
            });
            await task;
        }

        static int count;
        static void Counter()
        {
            Console.ReadKey();
            count += 1;
        }

        static void Task1()
        {
            for(int i = 0; i < 100000; i++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.WriteLine($"Task1 : {i}");         
            }
        }
        static void Task2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.WriteLine(i);
            }
        }
    }
}