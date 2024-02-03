namespace CourseGPAFile.Tests;

public class CourseGpaFileUnitTests : IDisposable
{
    private readonly TextWriter _originalOut;
    private readonly StringWriter _capturedConsoleOut;

    public CourseGpaFileUnitTests()
    {
        // Arrange - Redirect Console.Out in the constructor (setup)
        _capturedConsoleOut = new StringWriter();
        _originalOut = Console.Out;
        Console.SetOut(_capturedConsoleOut);
    }

    public void Dispose()
    {
        // Reset Console.Out in the Dispose method (teardown)
        Console.SetOut(_originalOut);
        _capturedConsoleOut.Dispose();
    }

    [Fact]
    public void CalculateGrades_ComputesCorrectGPA_ForGradeLetters()
    {
        // Arrange
        var grades = new[] {"A", "B", "C", "D", "F"};
        var expectedOutput = "GPA: 2.00\r\n"; // Adjust based on your system's newline character

        // Act
        Program.CalculateGrades(grades);

        // Assert
        var result = _capturedConsoleOut.ToString();
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void ReadFile_ReadsGradesCorrectly_FromFile()
    {
        // Arrange
        var fileName = Path.GetTempFileName();
        var expectedGrades = new[] {"A", "B", "C", "D", "F"};
        File.WriteAllLines(fileName, new[] {"Header", "Course1,A", "Course2,B", "Course3,C", "Course4,D", "Course5,F"});

        // Act
        var grades = Program.ReadFile(fileName);

        // Assert
        Assert.Equal(expectedGrades, grades);

        // Cleanup
        File.Delete(fileName);
    }
}
