using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PractiseAss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            countLabel.Content = Convert.ToString(_carCount);

            verticalSlider.Minimum = 0;
            verticalSlider.Maximum = paperCanvas.Height;

            horizontalSlider.Minimum = 0;
            horizontalSlider.Maximum = paperCanvas.Width;

            verticalLabel.Content = Convert.ToString(verticalSlider.Value);
            horizontalLabel.Content = Convert.ToString(horizontalSlider.Value);

            CreateEllipse();

            _number = 1;
            resultNumberLabel.Content = Convert.ToString(_number);

            celciusToFahreinheitSlider.Minimum = 0;
            celciusToFahreinheitSlider.Maximum = 100;
        }
        private void calculateMonthlyPaymentButton_Click(object sender, RoutedEventArgs e)
        {

            double monthlyPayment;
            double loanAmount;
            double yearlyRent;
            int duration;

            loanAmount = Convert.ToDouble(loanAmountTextBox.Text);
            yearlyRent = CalculateYearlyRent();
            duration = CalculateDuration();
            monthlyPayment = CalculateMonthlyPayment(loanAmount, yearlyRent, duration);
            resultMonthlyPayment.Content = monthlyPayment.ToString("F2") + " euros";
        }

        private double CalculateYearlyRent() 
        { 
         return Convert.ToDouble(yearlyRentTextBox.Text) / 12 / 100;
        }

        private int CalculateDuration()
        {
            return Convert.ToInt32(durationTextBox.Text) * 12;
        }

        private double CalculateMonthlyPayment(double loanAmount, double yearlyRent, int duration) 
        {
            return loanAmount * (yearlyRent * Math.Pow(1 + yearlyRent, duration)) / (Math.Pow(1 + yearlyRent, duration) - 1);
        }

        private void calculateBmiButton_Click(object sender, RoutedEventArgs e)
        {
            double length;
            double weight;
            double resultBmi;

            length = Convert.ToDouble(lengthTextBox.Text);
            weight = CalculateWeight();
            resultBmi = CalculateResultBmi(length, weight);

            resultBmiLabel.Content = resultBmi.ToString("F2");
        }

        private double CalculateWeight()
        {
            return Convert.ToDouble(weightTextBox.Text) / 100;
        }

        private double CalculateResultBmi(double length, double weight)
        {
            return weight / (length * length);
        }

        private void calculateIngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            double flour, sugar, butter;
            int eggs = 1;
            double portionSize;

            portionSize = Convert.ToDouble(portionsTextBox.Text);
            flour = CalculateFlour(portionSize);
            sugar = CalculateSugar(portionSize);
            butter = CalculateButter(portionSize);
            eggs = CalculateEggs(portionSize);

            DisplayIngredients(flour, sugar, butter, eggs); 

        }
        private double CalculateFlour(double portionSize )
        {
            return 100 * portionSize;
        }

        private double CalculateSugar(double portionSize)
        {
            return 50 * portionSize;
        }

        private double CalculateButter(double portionSize)
        {
            return 50 * portionSize;
        }

        private int CalculateEggs(double portionSize)
        {
            return (int)(1 * portionSize);
        }

        private void DisplayIngredients(double flour, double butter, double sugar, int eggs)
        {
            flourLabel.Content = flour.ToString() + " grams";
            butterLabel.Content = butter.ToString() + " grams";
            sugarLabel.Content = sugar.ToString() + " grams";
            eggsLabel.Content = eggs.ToString() + " piece(s)";
        }

        private void calculatePizzaIngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            int numberOfPizzas = Convert.ToInt32(numberOfPizzasTextBox.Text);
            double pizzaDiameter = Convert.ToDouble(pizzaDiameterTextBox.Text);

            double flour = CalculateFlourOfPizza(numberOfPizzas, pizzaDiameter);
            double cheese = CalculateCheeseOfPizza(numberOfPizzas, pizzaDiameter);
            double tomatoSauce = CalculateTomatoSauceOfPizza(numberOfPizzas, pizzaDiameter);

            ShowIngredientsOfPizza(flour, cheese, tomatoSauce);
        }

        private double CalculateFlourOfPizza(int numberOfPizzas, double pizzaDiameter)
        {
            return numberOfPizzas * (150 + (pizzaDiameter * 0.5));
        }

        private double CalculateCheeseOfPizza(int numberOfPizzas, double pizzaDiameter)
        {
            return numberOfPizzas * (100 + (pizzaDiameter * 0.3));
        }

        private double CalculateTomatoSauceOfPizza(int numberOfPizzas, double pizzaDiameter)
        {
            return numberOfPizzas * (200 + (pizzaDiameter * 0.4));
        }

        private void ShowIngredientsOfPizza(double flour, double cheese, double tomatoSauce)
        {
            flourPizzaLabel.Content = $"Flour: {flour:F2} grams";
            cheesePizzaLabel.Content = $"Cheese: {cheese:F2} grams";
            tomatoSaucePizzaLabel.Content = $"Tomato Sauce: {tomatoSauce:F2} ml";
        }

        private void calculateCafeTotalButton_Click(object sender, RoutedEventArgs e)
        {
            int numberOfCoffees = Convert.ToInt32(coffeesTextBox.Text);
            double coffeePrice = Convert.ToDouble(coffeePriceTextBox.Text);
            int numberOfTeas = Convert.ToInt32(teasTextBox.Text);
            double teaPrice = Convert.ToDouble(teaPriceTextBox.Text);
            int numberOfJuices = Convert.ToInt32(juicesTextBox.Text);
            double juicePrice = Convert.ToDouble(juicePriceTextBox.Text);

            double totalCoffeeCost = CalculateTotalCoffeeCost(numberOfCoffees, coffeePrice);
            double totalTeaCost = CalculateTotalTeaCost(numberOfTeas, teaPrice);
            double totalJuiceCost = CalculateTotalJuiceCost(numberOfJuices, juicePrice);
            double grandTotal = CalculateGrandTotal(totalCoffeeCost, totalTeaCost, totalJuiceCost);

            ShowTotalCostOfOrder(totalCoffeeCost, totalTeaCost, totalJuiceCost, grandTotal);
        }

        private double CalculateTotalCoffeeCost(int numberOfCoffees, double coffeePrice)
        {
            return numberOfCoffees * coffeePrice;
        }

        private double CalculateTotalTeaCost(int numberOfTeas, double teaPrice)
        {
            return numberOfTeas * teaPrice;
        }

        private double CalculateTotalJuiceCost(int numberOfJuices, double juicePrice)
        {
            return numberOfJuices * juicePrice;
        }

        private double CalculateGrandTotal(double totalCoffeeCost, double totalTeaCost, double totalJuiceCost)
        {
            return totalCoffeeCost + totalTeaCost + totalJuiceCost;
        }
        private void ShowTotalCostOfOrder(double totalCoffeeCost, double totalTeaCost, double totalJuiceCost, double grandTotal)
        {
            totalCoffeeLabel.Content = $"Total Coffee Cost: {totalCoffeeCost:F2} euros";
            totalTeaLabel.Content = $"Total Tea Cost: {totalTeaCost:F2} euros";
            totalJuiceLabel.Content = $"Total Juice Cost: {totalJuiceCost:F2} euros";
            grandTotalLabel.Content = $"Grand Total: {grandTotal:F2} euros";
        }

        private void resultInputNameButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName;
            string lastName;

            firstName = firstNameTextBox.Text;
            lastName = lastNameTextBox.Text;

            //ShowName(firstName);
            ShowNames(firstName, lastName);
        }

        private void ShowName(string firstName)
        {
            MessageBox.Show("Your first name is: " + firstName);
        }
        private void ShowNames(string firstName, string lastName)
        {
            MessageBox.Show("Your first name is: " + firstName + " and your last name is: " + lastName);
        }

        private void resultTotalIncomeButton_Click(object sender, RoutedEventArgs e)
        {
            double yearlySalary;
            int workedYears;
            double totalIncome;

            workedYears = Convert.ToInt32(yearsWorkedTextBox.Text);
            yearlySalary = Convert.ToDouble(yearlySalaryTextBox.Text);
            totalIncome = CalculateTotalIncome(yearlySalary, workedYears);

           ShowTotalIncome(totalIncome);

        }

        private double CalculateTotalIncome(double yearlySalary, int workedYears)
        {
            return yearlySalary * workedYears;
        }

        private void ShowTotalIncome(double totalIncome)
        {
            MessageBox.Show("Your income over the past years is " + totalIncome);
        }

        private int _carCount = 0;
        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            _carCount = _carCount + 1;
            countLabel.Content = _carCount;
        }

        private void leavingButton_Click(object sender, RoutedEventArgs e)
        {
            _carCount = _carCount - 1;
            countLabel.Content = _carCount;
        }

        private void horizontalSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int horizontal = Convert.ToInt32(horizontalSlider.Value);
            horizontalLabel.Content = Convert.ToString(horizontal);
            UpdateEllipse();
        }

        private void verticalSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int vertical = Convert.ToInt32(verticalSlider.Value);
            verticalLabel.Content = Convert.ToString(vertical);
            UpdateEllipse();
        }

        private Ellipse _ellipse;
        private void CreateEllipse()
        {
            _ellipse = new Ellipse();
            _ellipse.Width = horizontalSlider.Value;
            _ellipse.Height = verticalSlider.Value;
            _ellipse.Stroke = new SolidColorBrush(Colors.Blue);
            _ellipse.Fill = new SolidColorBrush(Colors.Pink);
            _ellipse.Margin = new Thickness(0, 0, 0, 0);
            paperCanvas.Children.Add(_ellipse);
        }

        private void UpdateEllipse()
        {
            _ellipse.Width = horizontalSlider.Value;
            _ellipse.Height = verticalSlider.Value;
        }

        private void changeSliderValueButton_Click(object sender, RoutedEventArgs e)
        {
           double max = Convert.ToDouble(maximumTextBox.Text);
           double min = Convert.ToDouble(minimumTextBox.Text);

            minMaxSlider.Minimum = min;
            minMaxSlider.Maximum = max;

        }

        private void minMaxSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double max;
            double min;

            min = minMaxSlider.Minimum;
            max = minMaxSlider.Maximum;

            ShowMinMaxValueSlider(min, max);
        }

        private void ShowMinMaxValueSlider(double max, double min)
        {
            MessageBox.Show("The slider max is: " + max + " The slider min is: " + min);
        }

        private int _number;
        private void increaseNumberButton_Click(object sender, RoutedEventArgs e)
        {
            _number++;
            resultNumberLabel.Content = Convert.ToString(_number);
        }

        private int _rolledNumber;
        private int _sumOfNumbers;
        private int _averageOfNumbers;
        private int _countOfNumbers;
        private void randomNumberButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            _rolledNumber = random.Next(200, 400);

            CalculateSumOfNumbers(_rolledNumber);
            _countOfNumbers++;
            CalculateAverageOfNumbers(_sumOfNumbers, _countOfNumbers);

            ShowRandomNumberResults(_rolledNumber, _sumOfNumbers, _averageOfNumbers);
        }

        private int CalculateSumOfNumbers(int rolledNumber)
        {
            return _sumOfNumbers += rolledNumber;
        }

        private int CalculateAverageOfNumbers(int sumOfNumbers, int countOfNumbers)
        {
            return _averageOfNumbers = sumOfNumbers / countOfNumbers;
        }

        private void ShowRandomNumberResults(int rolledNumber, int sumOfNumbers, int averageOfNumbers)
        {
            randomNumberLabel.Content = rolledNumber.ToString();
            totalSumOfNumbersLabel.Content = sumOfNumbers.ToString();
            averageNumberLabel.Content = averageOfNumbers.ToString();
        }

        private double _celcius;
        private double _fahrenheit;

        private void celciusToFahreinheitButton_Click(object sender, RoutedEventArgs e)
        {
            _celcius = Convert.ToInt32(inputCelciusTextBox.Text);
            _fahrenheit = _celcius * 9 / 5 + 32;

            celciusToFahreinheitSlider.Minimum = _celcius;
            celciusToFahreinheitSlider.Maximum = _fahrenheit;

            resultCelciusToFahrenheitLabel.Content = Convert.ToString(_fahrenheit);

        }

        private void celciusToFahreinheitSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            celciusToFahreinheitSlider.Minimum = _celcius;
            celciusToFahreinheitSlider.Maximum = _fahrenheit;
        }
    }
}
