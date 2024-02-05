package ms.testng.ms;

import org.testng.annotations.Listeners;
import java.lang.Thread;
import org.testng.annotations.Test;
import org.testng.AssertJUnit;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.interactions.Actions;

@Listeners(ExtentReportListener.class)
public class NewTest {
	ChromeDriver driver = new ChromeDriver();
  @Test
  public void keyDown() throws InterruptedException {
	  
	  driver.get("https://www.selenium.dev/selenium/web/single_text_input.html");

      new Actions(driver)
              .keyDown(Keys.SHIFT)
              .sendKeys("a")
              .perform();

      WebElement textField = driver.findElement(By.id("textInput"));
      AssertJUnit.assertEquals("A", textField.getAttribute("value"));
      Thread.sleep(500);
  }
  
  @Test
  public void keyUp() {
      driver.get("https://www.selenium.dev/selenium/web/single_text_input.html");

      new Actions(driver)
              .keyDown(Keys.SHIFT)
              .sendKeys("a")
              .keyUp(Keys.SHIFT)
              .sendKeys("b")
              .perform();

      WebElement textField = driver.findElement(By.id("textInput"));
      AssertJUnit.assertEquals("Ab", textField.getAttribute("value"));
  }

  @Test
  public void sendKeysToActiveElement() {
      driver.get("https://www.selenium.dev/selenium/web/single_text_input.html");

      new Actions(driver)
              .sendKeys("abc")
              .perform();

      WebElement textField = driver.findElement(By.id("textInput"));
      AssertJUnit.assertEquals("abc", textField.getAttribute("value"));
  }

  @Test
  public void sendKeysToDesignatedElement() {
      driver.get("https://www.selenium.dev/selenium/web/single_text_input.html");
      driver.findElement(By.tagName("body")).click();

      WebElement textField = driver.findElement(By.id("textInput"));
      new Actions(driver)
              .sendKeys(textField, "Selenium!")
              .perform();

      AssertJUnit.assertEquals("Selenium!", textField.getAttribute("value"));
      
  }

  
}
