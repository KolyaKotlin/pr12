using MarkForTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGradeExcellent()
        {
            // Arrange
            int task1 = 10;
            int task2 = 50;
            int task3 = 30;
            int task4 = 10;

            // Act
            var (totalScore, grade) = GradeCalculator.CalculateGrade(task1, task2, task3, task4);

            // Assert
            Assert.AreEqual(100, totalScore);  // Сумма баллов должна быть 100
            Assert.AreEqual("5 (Отлично)", grade);  // Оценка должна быть "5 (Отлично)"
        }

        [TestMethod]
        public void TestGradeGood()
        {
            // Arrange
            int task1 = 8;
            int task2 = 40;
            int task3 = 20;
            int task4 = 5;

            // Act
            var (totalScore, grade) = GradeCalculator.CalculateGrade(task1, task2, task3, task4);

            // Assert
            Assert.AreEqual(73, totalScore);  // Сумма баллов должна быть 73
            Assert.AreEqual("5 (Отлично)", grade);  // Оценка должна быть "5 (Отлично)"
        }

        [TestMethod]
        public void TestGradeSatisfactory()
        {
            // Arrange
            int task1 = 5;
            int task2 = 30;
            int task3 = 15;
            int task4 = 5;

            // Act
            var (totalScore, grade) = GradeCalculator.CalculateGrade(task1, task2, task3, task4);

            // Assert
            Assert.AreEqual(55, totalScore);  // Сумма баллов должна быть 55
            Assert.AreEqual("4 (Хорошо)", grade);  // Оценка должна быть "4 (Хорошо)"
        }

        [TestMethod]
        public void TestGradeUnsatisfactory()
        {
            // Arrange
            int task1 = 3;
            int task2 = 10;
            int task3 = 5;
            int task4 = 1;

            // Act
            var (totalScore, grade) = GradeCalculator.CalculateGrade(task1, task2, task3, task4);

            // Assert
            Assert.AreEqual(19, totalScore);  // Сумма баллов должна быть 19
            Assert.AreEqual("2 (Неудовлетворительно)", grade);  // Оценка должна быть "2 (Неудовлетворительно)"
        }
    }
}
