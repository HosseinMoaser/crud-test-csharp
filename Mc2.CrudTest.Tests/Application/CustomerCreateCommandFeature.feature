Feature: CustomerCreateCommandFeature
	In order to create a customer and save it in data base
	As a crud application consumer
	I want to be able create customer using CreateCustomerCommandHanler

Scenario: Creating customer with valid data
	Given that we have a valid inputs for customer factory
	And created customer  does not exists in a database
	When I call HandleAsync method of command hanler
	Then created customer should be added to the database
	And no exception should be thrown
