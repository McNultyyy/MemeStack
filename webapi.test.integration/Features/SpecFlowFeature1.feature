Feature: MyApiSteps
	A simple test

Scenario: Request the root endpoint
	When I send a 'GET' request to '/'
	Then StatusCode should be '200'
	And content equals to 'Hello World'