using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
