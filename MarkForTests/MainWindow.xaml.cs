using System;
using System.Windows;

namespace MarkForTests
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int task1Score = int.Parse(Task1TextBox.Text);
                int task2Score = int.Parse(Task2TextBox.Text);
                int task3Score = int.Parse(Task3TextBox.Text);
                int task4Score = int.Parse(Task4TextBox.Text);

                if (task1Score < 0 || task1Score > 10 || task2Score < 0 || task2Score > 50 ||
                    task3Score < 0 || task3Score > 30 || task4Score < 0 || task4Score > 10)
                {
                    MessageBox.Show("Введены некорректные значения. Пожалуйста, проверьте баллы.");
                    return;
                }

                var (totalScore, grade) = GradeCalculator.CalculateGrade(task1Score, task2Score, task3Score, task4Score);

                ResultTextBlock.Text = $"Сумма баллов: {totalScore}\nОценка: {grade}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числа в поля.");
            }
        }
    }

    public class GradeCalculator
    {
        public static (int TotalScore, string Grade) CalculateGrade(int task1, int task2, int task3, int task4)
        {
            if (task1 < 0 || task1 > 10 || task2 < 0 || task2 > 50 || task3 < 0 || task3 > 30 || task4 < 0 || task4 > 10)
                throw new ArgumentException("Баллы должны быть в допустимом диапазоне.");

            int totalScore = task1 + task2 + task3 + task4;

            string grade;
            if (totalScore >= 70)
                grade = "5 (Отлично)";
            else if (totalScore >= 40)
                grade = "4 (Хорошо)";
            else if (totalScore >= 20)
                grade = "3 (Удовлетворительно)";
            else
                grade = "2 (Неудовлетворительно)";

            return (totalScore, grade);
        }
    }

}
