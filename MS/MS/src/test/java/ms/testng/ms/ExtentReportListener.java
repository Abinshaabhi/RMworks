package ms.testng.ms;

import com.aventstack.extentreports.ExtentReports;
import com.aventstack.extentreports.ExtentTest;
import com.aventstack.extentreports.Status;
import com.aventstack.extentreports.markuputils.ExtentColor;
import com.aventstack.extentreports.markuputils.MarkupHelper;
import org.testng.ITestContext;
import org.testng.ITestListener;
import org.testng.ITestResult;

public class ExtentReportListener implements ITestListener {
    private ExtentReports extent = ExtentManager.createInstance();
    private ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();

    
    public void onTestStart(ITestResult result) {
        ExtentTest extentTest = extent.createTest(result.getMethod().getMethodName());
        test.set(extentTest);
    }

    
    public void onTestSuccess(ITestResult result) {
        test.get().pass("Test passed");
    }

    
    public void onTestFailure(ITestResult result) {
        test.get().fail(result.getThrowable());
    }

    
    public void onTestSkipped(ITestResult result) {
        test.get().skip(result.getThrowable());
    }

    
    public void onStart(ITestContext context) {
        // Not implemented
    }

    
    public void onFinish(ITestContext context) {
        extent.flush();
    }
}
