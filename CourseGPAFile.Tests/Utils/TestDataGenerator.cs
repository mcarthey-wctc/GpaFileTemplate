using CourseGPAFile.Tests.Models;

namespace CourseGPAFile.Tests.Utils;

public static class TestDataGenerator
{
    public static IEnumerable<object[]> TestDataForCalculateGrades()
    {
        yield return new object[] {new TestData {Grades = new[] {"A", "B", "C"}, ExpectedGPA = "3.00"}};
        yield return new object[] {new TestData {Grades = new[] {"A", "B", "C"}, ExpectedGPA = "3.00"}};
        yield return new object[] {new TestData {Grades = new[] {"A", "A", "B"}, ExpectedGPA = "3.67"}};
        yield return new object[] {new TestData {Grades = new[] {"B", "B", "B", "C"}, ExpectedGPA = "2.75"}};
        yield return new object[] {new TestData {Grades = new[] {"A", "A", "A"}, ExpectedGPA = "4.00"}};
        yield return new object[] {new TestData {Grades = new[] {"A"}, ExpectedGPA = "4.00"}};
        yield return new object[] {new TestData {Grades = new[] {"B"}, ExpectedGPA = "3.00"}};
        yield return new object[] {new TestData {Grades = new[] {"C"}, ExpectedGPA = "2.00"}};
        yield return new object[] {new TestData {Grades = new[] {"D"}, ExpectedGPA = "1.00"}};
        yield return new object[] {new TestData {Grades = new[] {"F"}, ExpectedGPA = "0.00"}};
        // Add more test cases with different data and expected results here
    }
}
