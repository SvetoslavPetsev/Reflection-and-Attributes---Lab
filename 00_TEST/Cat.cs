namespace _00_TEST
{
    public class Cat : Animal, IMovable
    {
        private string gander = "female";
        private int id;
        public Cat(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Cat(string name, int age, int id)
            :this(name,age)
        {
            this.id = id;
        }
        public int Age { get; set; }

        public bool isSleeping()
        {
            return false;
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public int GetID()
        {
            return this.id;
        }
    }
}
