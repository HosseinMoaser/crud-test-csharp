Feature: CustomerDeleteCommandFeature
	In order to delete a customer information and from data base
	As a crud application consumer
	I want to be able to delete customer using DeleteCustomerCommandHanler


Scenario: Deleting existing customer with ID
	Given that a customer exists in database
	When I call HandleAsync method of delete command handler
	Then customer information should be deleted from database
	And no exception should be thrown while data is deleting

Scenario: Deleting non-existing customer with ID
	Given that a customer does not exists in database
	When I call HandleAsync method of delete command handler
	Then exception should be thrown
	And type of exception should be CustomerNotFoundException