Feature: Indeed

Search for jobs

@IndeedSearch
Scenario: Software Tester
	Given Indeed Home Page
	When Search for Software Tester job post
	Then related Results Should display

@IndeedSearch
Scenario: Software Developer
	Given Indeed Home Page
	When Search for Software Developer job post
	Then related Results Should display