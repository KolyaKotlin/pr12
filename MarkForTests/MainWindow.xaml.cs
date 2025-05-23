using System;
using System.Windows;

namespace MarkForTests
{
    /// <summary>
    /// Главный класс окна приложения для ввода баллов и расчета оценки.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор, инициализирующий компоненты окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик клика по кнопке для вычисления результата.
        /// Вводит баллы за задания и отображает суммарный результат с оценкой.
        /// </summary>
        /// <param name="sender">Объект, который вызвал событие.</param>
        /// <param name="e">Параметры события.</param>
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Преобразуем введенные строки в целые числа
                int task1Score = int.Parse(Task1TextBox.Text);
                int task2Score = int.Parse(Task2TextBox.Text);
                int task3Score = int.Parse(Task3TextBox.Text);
                int task4Score = int.Parse(Task4TextBox.Text);

                // Проверка на допустимость значений баллов
                if (task1Score < 0 || task1Score > 10 || task2Score < 0 || task2Score > 50 ||
                    task3Score < 0 || task3Score > 30 || task4Score < 0 || task4Score > 10)
                {
                    MessageBox.Show("Введены некорректные значения. Пожалуйста, проверьте баллы.");
                    return;
                }

                // Расчет итогового балла и оценки с использованием GradeCalculator
                var (totalScore, grade) = GradeCalculator.CalculateGrade(task1Score, task2Score, task3Score, task4Score);

                // Отображаем результат в TextBlock
                ResultTextBlock.Text = $"Сумма баллов: {totalScore}\nОценка: {grade}";
            }
            catch (FormatException)
            {
                // Если введены некорректные данные (не числа)
                MessageBox.Show("Пожалуйста, введите корректные числа в поля.");
            }
        }
    }

    /// <summary>
    /// Класс для расчета итогового балла и оценки на основе введенных баллов.
    /// </summary>
    public class GradeCalculator
    {
        /// <summary>
        /// Метод для вычисления суммы баллов и определения оценки.
        /// </summary>
        /// <param name="task1">Баллы за задание 1 (0-10).</param>
        /// <param name="task2">Баллы за задание 2 (0-50).</param>
        /// <param name="task3">Баллы за задание 3 (0-30).</param>
        /// <param name="task4">Баллы за задание 4 (0-10).</param>
        /// <returns>Возвращает кортеж, состоящий из итогового балла и оценки.</returns>
        /// <exception cref="ArgumentException">Бросает исключение, если баллы выходят за пределы допустимого диапазона.</exception>
        public static (int TotalScore, string Grade) CalculateGrade(int task1, int task2, int task3, int task4)
        {
            // Проверка на допустимость значений баллов
            if (task1 < 0 || task1 > 10 || task2 < 0 || task2 > 50 || task3 < 0 || task3 > 30 || task4 < 0 || task4 > 10)
                throw new ArgumentException("Баллы должны быть в допустимом диапазоне.");

            // Расчет общей суммы баллов
            int totalScore = task1 + task2 + task3 + task4;

            // Определение оценки в зависимости от суммы баллов
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
