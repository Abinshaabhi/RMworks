package StepDefinitions;


import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Then;

public class StepDefinitions {
	
	WebDriver driver = new ChromeDriver();
    @Given("Home page of Indeed")
    public void givenHomePage() {
    	driver.get("https://in.indeed.com/?r=us");
    }

    @When("I Search for job")
    public void whenSearchJob() {
    	driver.findElement(By.id("text-input-what")).click();
	    driver.findElement(By.id("text-input-what")).clear();
	    driver.findElement(By.id("text-input-what")).sendKeys("software testing");
	    driver.findElement(By.xpath("//button[@type='submit']")).click();
    }

    @Then("I should see the Job Posts")
    public void thenShouldSeeJobPost() throws InterruptedException {
    	Thread.sleep(500);
	    driver.quit();
    }
}