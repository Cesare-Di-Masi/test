namespace DishesLib
{
    public class Restaurant
    {
        private string _name;
        private Dish[] _dishes;

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("illegal restaurant name");

                _name = value;
            }
        }

        public Dish[] Dishes
        {
            get
            {
                return _dishes;
            }
        }

        public Restaurant(string name, Dish[] dishes)
        {

            for (int i = 0; i < dishes.Length - 1; i++)
            {
                if (dishes[i].Equals(dishes[i + 1]) || dishes[i].Name == dishes[i + 1].Name)
                    throw new ArgumentException("cannot have same dish or same dishes name");
            }

            Name = name;

        }

        public void ModifyDish(int dishPos, Dish newDish)
        {
            if (dishPos < 1 || dishPos > _dishes.Length)
                throw new ArgumentOutOfRangeException("illegal position of dish");

            for (int i = 0; i < _dishes.Length; i++)
            {
                if (Dishes[i].Equals(newDish) || Dishes[i].Name == newDish.Name)
                    throw new ArgumentException("cannot have same dish or same dishes name");
            }

            _dishes[dishPos - 1] = newDish;

        }

        public bool NameIsComposedByMultipleWords()
        {
            return Name.Split(' ').Length > 1;
        }

        public int[] LowestPriceForEveryCourse()
        {

            int[] priceList = new int[5];

            for (int i = 0; i < _dishes.Length; i++)
            {
                TypeOfCourse currCourse = _dishes[i].Course;
                int currPrice = _dishes[i].Price;

                if (currCourse == TypeOfCourse.Appetizer)
                {
                    if (priceList[0] > currPrice)
                        priceList[0] = currPrice;

                }
                else if (currCourse == TypeOfCourse.FirstCourse)
                {
                    if (priceList[1] > currPrice)
                        priceList[1] = currPrice;
                }
                else if (currCourse == TypeOfCourse.SecondCourse)
                {
                    if (priceList[2] > currPrice)
                        priceList[2] = currPrice;
                }
                else if (currCourse == TypeOfCourse.Countour)
                {
                    if (priceList[3] > currPrice)
                        priceList[3] = currPrice;
                }
                else if (currCourse == TypeOfCourse.Dessert)
                {
                    if (priceList[4] > currPrice)
                        priceList[4] = currPrice;
                }

            }

            return priceList;

        }

        public Dish DishWithLongestName()
        {

            Dish longestNameDish = _dishes[0];

            for (int i = 1; i < _dishes.Length; i++)
            {

                if (String.Compare(longestNameDish.Name, _dishes[i].Name) == 1)
                {
                    longestNameDish = _dishes[i];
                }

            }

            return longestNameDish;

        }


    }
}
