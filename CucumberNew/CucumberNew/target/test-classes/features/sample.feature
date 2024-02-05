Feature: Indeed

  Scenario: Indeed Search
    Given Home page of Indeed
    When I Search for job
    Then I should see the Job Posts