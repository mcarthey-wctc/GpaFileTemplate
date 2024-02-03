namespace CourseGPAFile.Tests;

public class CourseGpaFileUnitTests
{
    [Fact]
    public void CalculateGrades_ComputesCorrectGPA_ForGradeLetters()
    {
        // Arrange
        var grades = new string[] { "A", "B", "C", "D", "F" };
        var expectedOutput = "GPA: 2.00\r\n"; // Adjust based on your system's newline character

        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        Program.CalculateGrades(grades); 

        // Assert
        var result = sw.ToString();
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void ReadFile_ReadsGradesCorrectly_FromFile()
    {
        // Arrange
        var fileName = Path.GetTempFileName();
        var expectedGrades = new[] { "A", "B", "C", "D", "F" };
        File.WriteAllLines(fileName, new[] { "Header", "Course1,A", "Course2,B", "Course3,C", "Course4,D", "Course5,F" });

        // Act
        var grades = Program.ReadFile(fileName);

        // Assert
        Assert.Equal(expectedGrades, grades);

        // Cleanup
        File.Delete(fileName);
    }
}