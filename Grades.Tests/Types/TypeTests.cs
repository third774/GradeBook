using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;

            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "Kevin";
            name = name.ToUpper();

            Assert.AreEqual("KEVIN", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);
            Assert.AreEqual(x, 46);
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            Gradebook book1 = new Gradebook();
            Gradebook book2 = book1;

            GiveBookAName(book2);

            Assert.AreEqual("A GradeBook", book2.Name);
        }

        private void GiveBookAName(Gradebook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Kevin";
            string name2 = "kevin";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

        }

        [TestMethod]
        public void ObjectsAreStoredWithAReference()
        {
            Gradebook g1 = new Gradebook();
            Gradebook g2 = g1;
            
            g1.Name = "Scott's gradebook";
            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void ValuesAreStoredDirectly()
        {
            int a = 2;
            int b = a;

            a = 3;
            Assert.AreNotEqual(a, b);
        }
    }
}
