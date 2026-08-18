// add using directives for the class to be tested
using CultureList.Helpers;

namespace CultureList.Tests.Helpers;

// Add TestClass attribute to the class
[TestClass]
public class PathHelpersTests
{
    // Add TestMethod attribute to the method
    // Method name should describe the test scenario in the format MethodName_Scenario_ExpectedResult
    [TestMethod]
    public void AnonymizePath_IsUserProfilePath_AnonymizedPath()
    {
        string result = PathHelpers.AnonymizePath("C:\\Users\\kenne\\Documents\\file.txt");
        Assert.AreEqual("%USERPROFILE%\\Documents\\file.txt", result);
    }

    [TestMethod]
    public void AnonymizePath_IsUserProfilePath_AnonymizePathNotSame()
    {
        var result = PathHelpers.AnonymizePath("C:\\Users\\kenne\\Documents\\file.txt");
        Assert.AreNotEqual("C:\\users\\kenne\\Documents\\file.txt", result);
    }


    [TestMethod]
    public void AnonymizePath_NotUserProfilePath_NotAnonymized()
    {
        var result = PathHelpers.AnonymizePath("C:\\Users\\public\\Documents\\file.txt");
        Assert.AreNotEqual("%USERPROFILE%\\Documents\\file.txt", result);
    }
}
