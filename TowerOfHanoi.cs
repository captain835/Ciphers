using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TowerOfHanoi T = new TowerOfHanoi();
            Console.Write("Enter the number of discs: ");
            int towerNumDiscs = int.Parse(Console.ReadLine());
            var startTime = DateTime.Now.TimeOfDay;
            T.HanoiTowerRecursion(towerNumDiscs, 1, 3, 2);
            //Console.WriteLine(T.counter);
            var endTime = DateTime.Now.TimeOfDay;
            Console.WriteLine(endTime - startTime);
        }
    }
    class TowerOfHanoi
    {
        int mNumDiscs;
        public TowerOfHanoi()
        {
            numdiscs = 0;
        }
        public TowerOfHanoi(int newVal)
        {
            numdiscs = newVal;
        }
        public int counter = -1;
        public int numdiscs
        {
            get
            {
                return mNumDiscs;
            }
            set
            {
                if (value > 0)
                    mNumDiscs = value;
            }
        }
        public int HanoiTowerRecursion(int disk, int source, int destination, int aux)
        {
            if (disk <= 0)
            {
                this.counter++;
                return 0;
            }
            else
            {
                HanoiTowerRecursion(disk - 1, source, aux, destination);
                //Console.WriteLine("Move disk [{0}] from tower [{1}] to tower [{2}]", disk, source, destination);
                return (HanoiTowerRecursion(disk - 1, aux, destination, source));
            }
        }
    }
}
