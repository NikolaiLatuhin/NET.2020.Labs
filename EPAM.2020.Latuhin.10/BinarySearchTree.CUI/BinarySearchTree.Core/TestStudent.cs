using System;

namespace BinarySearchTree.Core
{
    public class TestStudent : IComparable<TestStudent>
    {
        public string NameStudent { get; set; }
        public string NameTest { get; set; }
        public DateTime DatePassing { get; set; }
        public int Score { get; set; }

        public TestStudent(string nameStudent, string nameTest, DateTime datePassing, int score)
        {
            NameStudent = nameStudent;
            NameTest = nameTest;
            DatePassing = datePassing;
            Score = score;
        }

        /// <summary>
        /// Сравнить с информацию студентов на основе оценок
        /// </summary>
        /// <param name="other">Студент, который будет сравниваться</param>
        /// <returns>Возвращает 1 в случае, если сравниваемый студент имеет меньший балл за тест, 1 в случае большего балла,
        /// 0 в остальных случаях</returns>
        public int CompareTo(TestStudent other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            if (other.Score < Score)
            {
                return 1;
            }

            if (other.Score > Score)
            {
                return -1;
            }

            return 0;
        }
    }
}
